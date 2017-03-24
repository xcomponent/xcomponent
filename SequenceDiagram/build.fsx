// include Fake lib
#r @"../Examples/packages/FAKE/tools/FakeLib.dll"
#r "System.Xml.Linq"

open Fake
open Fake.XMLHelper
open System
open System.Text.RegularExpressions
open System.IO
open System.Xml.Linq
open System.Text

// parameters and constants definition
let studioScriptPath = "./xcstudio.cmd"
let xctools = "../Examples/packages/xcomponent.community/tools/XCStudio\XCTools/XComponent.XCTools.exe"
let timeoutExec = 5.0


Target "Clean" (fun _ ->
    trace "Cleaning..."
    DeleteFile studioScriptPath

    !! "./**/*.csproj"
    |> MSBuildRelease "" "Clean"
    |> Log "MSBuild clean Output: "
)

Target "Compile" (fun _ ->    
    trace ("Compiling XComponent project")

    let result = ExecProcess (fun info ->
                    info.FileName <- xctools
                    info.WorkingDirectory <- __SOURCE_DIRECTORY__ 
                    info.Arguments <- "--compilationmode=Debug --build --env=Dev --vs=VS2015 --project=\"SequenceDiagramProject_Model.xcml\""
                    ) 
                    (TimeSpan.FromMinutes timeoutExec)
  
    if result <> 0 then failwithf "xctools returned with a non-zero exit code"

    result = ExecProcess (fun info ->
                    info.FileName <- xctools
                    info.WorkingDirectory <- __SOURCE_DIRECTORY__ 
                    info.Arguments <- "--compilationmode=Debug --buildsln=\"App\SequenceDiagramViewer/SequenceDiagramViewer.sln\""
                    ) 
                    (TimeSpan.FromMinutes timeoutExec)
    if result <> 0 then failwithf "xctools SequenceDiagramViewer project generation returned with a non-zero exit code"


  
    
)

Target "Generate" (fun _ ->
    let parentDirectory = Directory.GetParent(__SOURCE_DIRECTORY__).FullName + "/Examples"
    //Generate xcstudio.cmd
    trace("Generating xcstudio.cmd")
    let studioScriptContents = [| "pushd %~dp0"
    ;"cd /d \"" + Path.Combine(parentDirectory, "packages\\xcomponent.community\\tools\XCStudio") + "\""
    ;"start \"\" XCStudio.exe \"" + Path.Combine(__SOURCE_DIRECTORY__, "SequenceDiagramProject_Model.xcml") + "\""
    ;"popd" |]
    File.WriteAllLines(studioScriptPath, studioScriptContents)    
    trace("Generating sequencediagram.cmd")
    let diagramScriptPath = "./sequencediagram.cmd"
    let diagramScriptContents = [| "start \"\" " +  "\"" + Path.Combine(__SOURCE_DIRECTORY__,"App/SequenceDiagramViewer/SequenceDiagramViewer/bin/Debug/SequenceDiagramViewer.exe") + "\"" |]
    File.WriteAllLines(diagramScriptPath, diagramScriptContents)    


)
  
// Default target
Target "Help" (fun _ ->
    List.iter printfn [
      "xcomponent.helloworld build usage: "      
      ""
      "build All"      
      ""                  
      ""]
)

Target "All" DoNothing

// Dependencies
"Clean"  
  ==> "Generate"
  ==> "Compile"    
  ==> "All"

// start build
RunTargetOrDefault "Help"