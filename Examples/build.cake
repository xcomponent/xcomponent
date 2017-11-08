#addin "Cake.FileHelpers"
#addin "Cake.XComponent"

var target = Argument("target", "Build");
var buildConfiguration = Argument("buildConfiguration", "Release");
var msBuildSettings = new MSBuildSettings { Configuration = buildConfiguration };

Setup((ICakeContext cakeContext) =>
{
	XcStudioAliases.XcStudioCreateLauncher(cakeContext, "xc.chat/chat/chat_Model.xcml", System.IO.Path.Combine(System.IO.Directory.GetCurrentDirectory(), "xc.chat"));
});

Task("NuGetRestore")
  .Does(() =>
{
  var solutions = GetFiles("./**/*.sln");
  foreach(var solution in solutions)
  {
    Information("Restoring packages for {0}", solution);
    NuGetRestore(solution, new NuGetRestoreSettings { NoCache = true });
  }
});

Task("Clean")
  .IsDependentOn("Clean Chat");

Task("Build")
  .IsDependentOn("NuGetRestore")
  .IsDependentOn("Build Chat");

#region Chat

Task("Clean Chat")
  .Does(() =>
{
});


Task("Build Chat")
  .IsDependentOn("Clean Chat")
  .Does(() =>
{
});

#endregion


RunTarget(target);