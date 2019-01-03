#addin "Cake.XComponent"
#r "../tools/Cake.XComponent/Cake.XComponent.dll"
#addin nuget:?package=Cake.Yarn
#addin nuget:?package=Cake.DoInDirectory
#addin "Cake.FileHelpers&version=3.0.0"
#addin "Cake.Incubator"

var target = Argument("target", "Build");
var buildConfiguration = Argument("buildConfiguration", "Debug");
var modelPath = Argument("modelPath", "OrderProcessing/OrderProcessing_Model.xcml");
var toolsRoot = @"../tools/XComponent.Studio.Community/tools/XCStudio/";

SetXcBuildPath(toolsRoot + @"/XCBuild/xcbuild.exe");

Func<bool> IsRunningOnLinux = () => {
    return IsRunningOnUnix() && !DirectoryExists("/Applications");
};

Func<string> getXCBuildExtraParam = () => {
    if (IsRunningOnUnix()) {
      if (DirectoryExists("/Applications")) {
        return " --monoPath=\"/Library/Frameworks/Mono.framework/Versions/5.2.0/lib/mono/4.5/Facades/\"";
      }
      return " --monoPath=\"/usr/lib/mono/4.5/Facades/\"";
    }
    return "";
};

Func<MSBuildSettings> GetDefaultMSBuildSettings = () => {
    if (IsRunningOnLinux()){
        return new MSBuildSettings { ToolPath = new FilePath("/usr/bin/msbuild"), Configuration = buildConfiguration};
    }
    return new MSBuildSettings{Configuration = buildConfiguration};
};

Action<string> BuildNETSolution = (string solution) => {
   NuGetRestore(solution, new NuGetRestoreSettings { NoCache = true });   
   MSBuild(solution, GetDefaultMSBuildSettings());
};

Task("ExportRuntime")
  .Does(() =>
{
  XcBuildExportRuntimes(modelPath, @"./Runtime", buildConfiguration, "Dev", true, getXCBuildExtraParam());
});

Task("ExportInterface")
  .Does(() =>
{
  XcBuildExecuteCommand("--compilationmode=Debug --exportInterface --env=Dev --output=\""+MakeAbsolute(File("./Runtime/Api"))+"\" --project=\""+modelPath+"\"" + getXCBuildExtraParam());
});

Task("BuildNETSolution")
 .Does(() => {
   string solution = Argument("solution", "");
   BuildNETSolution(solution);
});

Task("BuildXComponent")
 .Does(() => {  
   string project = Argument("project", "");
   string component = Argument("component", "");

   XcBuildBuild(project, buildConfiguration, "Dev", "VS2015", "--framework=Framework451 --serializationtype=\"Json\" --logkeys=Common --component=" + component + getXCBuildExtraParam());
});

Task("Build")
  .Does(() =>
{
  foreach(var solution in GetFiles("./OrderProcessing/**/*.sln"))
  {
    NuGetRestore(solution, new NuGetRestoreSettings { NoCache = true });
  }
  XcBuildBuild("./" + modelPath, buildConfiguration, "Dev", "VS2015", getXCBuildExtraParam());

  RunTarget("ExportRuntime");
  RunTarget("ExportInterface");
  BuildNETSolution(@"OrderProcessing\OrderProcessingClient\OrderProcessingClient.sln");
  RunTarget("GenerateStudioCmd");
  RunTarget("GenerateRuntimeCmd");
});

Task("GenerateStudioCmd")
  .Does(() => {
    var xcStudioBinaryFilePath = MakeAbsolute(File(toolsRoot + "XCStudio.exe"));
    var modelFilePath = MakeAbsolute(File("./" + modelPath));

    FileWriteText(@"xcstudio.cmd", @"start " + xcStudioBinaryFilePath + " " + modelFilePath);
});

Task("GenerateRuntimeCmd")
  .Does(() => {
    var fileContents = "";
    foreach(var xcrFile in GetFiles("./Runtime/xcassemblies/*.xcr"))
    {
      var xcPropertiesPath = xcrFile.FullPath.Replace("xcr", "xcproperties");
      var xcRuntimeBinaryFilePath = MakeAbsolute(File(toolsRoot + @"XCBuild/XCRuntime/xcruntime.exe"));
      var runServiceCmd = "start " + xcRuntimeBinaryFilePath + " " + xcrFile.FullPath + " " + xcPropertiesPath + "\n";

      fileContents += runServiceCmd;
      FileWriteText("run-"+xcrFile.GetFilename()+".cmd", runServiceCmd);
    }

    var xcBridgeBinaryPath = MakeAbsolute(File(toolsRoot + @"XCBridge/XCWebSocketBridge.exe"));
    var xcSpyBinaryFilePath = MakeAbsolute(File(toolsRoot + @"XCSpy/xcspy.exe"));
    var xcAssembliesPath = MakeAbsolute(File("./Runtime/Api/xcassemblies"));
    var xcBridgeParameters = "--apipath=\"" + xcAssembliesPath + "\" --port=9443  --unsecure ";

    var runClientAppCmd = "";
    runClientAppCmd += "cd OrderProcessing/OrderProcessingClient/OrderProcessingClient/bin/Debug/\n";
    runClientAppCmd += "timeout /t 15\n";
    runClientAppCmd += "OrderProcessingClient.exe\n";
	FileWriteText("runClientApp.cmd", runClientAppCmd);

    var runSpyCmd = "";
    runSpyCmd += "cd " + xcAssembliesPath + "\n";
    runSpyCmd += xcSpyBinaryFilePath + " . --privateTopic=privateTopic\n";
    FileWriteText("runSpy.cmd", runSpyCmd);

    fileContents += "start runClientApp.cmd\n";
    fileContents += "start runSpy.cmd\n";
    FileWriteText(@"run.cmd", fileContents);
});
  
Task("Clean")
  .ContinueOnError() // some projects may exist only after compilation
  .Does(() =>
{
  foreach(var directory in GetDirectories("./**/xcassemblies"))
  {
    CleanDirectory(directory);
  }

  foreach(var directory in GetDirectories("./**/generated"))
  {
    CleanDirectory(directory);
  }
  
  foreach(var generatedDir in GetDirectories("./**/generated"))
  {
    CleanDirectory(generatedDir);
  }

  Func<IFileSystemInfo, bool> exclude_node_modules =
     fileSystemInfo => !fileSystemInfo.Path.FullPath.Contains(
         "node_modules");

  foreach(var solution in GetFiles("./**/*.sln", exclude_node_modules))
  {
    try {
      MSBuild(solution, new MSBuildSettings{Configuration = "Release"}.WithTarget("Clean"));
    } catch(Exception) {
      
    }
    try {
      MSBuild(solution, new MSBuildSettings{Configuration = "Debug"}.WithTarget("Clean"));
    } catch(Exception) {

    }
  }
});

RunTarget(target);
