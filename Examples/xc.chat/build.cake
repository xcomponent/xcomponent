#addin "Cake.XComponent"
#r "../tools/Cake.XComponent/Cake.XComponent.dll"
#addin "Cake.Yarn&version=0.3.7"
#addin "Cake.DoInDirectory&version=3.1.0"
#addin "Cake.FileHelpers&version=3.0.0"
#addin "Cake.Incubator"

var target = Argument("target", "Build");
var buildConfiguration = Argument("buildConfiguration", "Debug");
var modelPath = Argument("modelPath", "chat/chat_Model.xcml");
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

Task("BuildWebapp")
  .Does(() => {
    DoInDirectory(@"webapp", () => {
      Yarn.Install();
      Yarn.RunScript("build:prod");
    });
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


Task("BuildApp")
  .Does(() =>
{
  foreach(var solution in GetFiles("./chat/**/*.sln"))
  {
    NuGetRestore(solution, new NuGetRestoreSettings { NoCache = true });
  }
	XcBuildBuild("./" + modelPath, buildConfiguration, "Dev", "VS2015", getXCBuildExtraParam());
  RunTarget("ExportRuntime");
  RunTarget("ExportInterface");
  RunTarget("GenerateStudioCmd");
  RunTarget("GenerateRuntimeCmd");
});

Task("Build")
  .IsDependentOn("BuildWebapp")
  .IsDependentOn("BuildApp")
  .Does(() =>
{
});

Task("RunWebapp")
  .Does(() => {
    DoInDirectory(@"webapp", () => {
      Yarn.RunScript("start");
    });
});

Task("GenerateStudioCmd")
  .Does(() => {
    var xcStudioBinaryFilePath = MakeAbsolute(File(@"../tools/XComponent.Community/tools/XCStudio/XCStudio.exe"));
    var modelFilePath = MakeAbsolute(File("./" + modelPath));

    FileWriteText(@"xcstudio.cmd", @"start " + xcStudioBinaryFilePath + " " + modelFilePath);
});

Task("GenerateRuntimeCmd")
  .Does(() => {
    var fileContents = "";
    foreach(var xcrFile in GetFiles("./Runtime/xcassemblies/*.xcr"))
    {
      var xcPropertiesPath = xcrFile.FullPath.Replace("xcr", "xcproperties");
      var xcRuntimeBinaryFilePath = MakeAbsolute(File(@"../tools/XComponent.Community/tools/XCStudio/XCBuild/XCRuntime/xcruntime.exe"));
      var runServiceCmd = "start " + xcRuntimeBinaryFilePath + " " + xcrFile.FullPath + " " + xcPropertiesPath + "\n";

      fileContents += runServiceCmd;
      FileWriteText("run-"+xcrFile.GetFilename()+".cmd", runServiceCmd);
    }

    fileContents += "cd webapp\n";
    fileContents += "start npm run start:dev\n";
    fileContents += "cd ..\n";

    var xcBridgeBinaryPath = MakeAbsolute(File(@"../tools/XComponent.Community/tools/XCStudio/XCBridge/XCWebSocketBridge.exe"));
    var xcBridgeParameters = "--apipath=\""+MakeAbsolute(File("./Runtime/Api/xcassemblies"))+"\" --port=9443  --unsecure";

    var runBridgeCmd = "start " + xcBridgeBinaryPath + " " + xcBridgeParameters + "\n";
    FileWriteText("runBridge.cmd", runBridgeCmd);

    fileContents += runBridgeCmd;
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
