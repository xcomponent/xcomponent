// include Fake lib
#r @"../packages/FAKE/tools/FakeLib.dll"
#r "System.Xml.Linq"

open Fake
open Fake.XMLHelper
open System
open System.Text.RegularExpressions
open System.IO
open System.Xml.Linq
open System.Text

// parameters and constants definition
let buildDir = "./build/"
let buildTradeSenderAppDir = Path.Combine(buildDir, "tradeSenderApp")
let buildTradeBlotterAppDir = Path.Combine(buildDir, "tradeBlotterApp")
let generatedDir = "./dealcaptureservice/generated/"
let exportDir = Path.Combine(buildDir, "exportMicroservice")
let studioScriptPath = "./xcstudio.cmd"
let startDealMicroserviceScriptPath = Path.Combine(buildDir, "startDealService.cmd")
let startReferentialMicroserviceScriptPath = Path.Combine(buildDir, "startReferentialService.cmd")
let startTradeSenderScriptPath = Path.Combine(buildDir, "startTradeSenderGui.cmd")
let startTradeBlotterScriptPath = Path.Combine(buildDir, "startTradeBlotterGui.cmd")
let xctools = "../packages/xcomponent.community/tools/XCStudio\XCTools/XComponent.XCTools.exe"
let timeoutExec = 5.0


Target "Clean" (fun _ ->
    trace "Cleaning..."
    CleanDir buildDir
    CleanDir generatedDir
    CleanDir exportDir
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
                    info.Arguments <- "--build --project=\"dealcaptureservice\\DealcaptureCore\\DealCapture_Model.xcml\""
                    ) 
                    (TimeSpan.FromMinutes timeoutExec)
  
    if result <> 0 then failwithf "xctools returned with a non-zero exit code"

    ensureDirectory buildTradeSenderAppDir

    !! "dealcaptureservice/Apps/TradeSender/TradeSender.sln"
    |> MSBuildRelease buildTradeSenderAppDir "Build"
    |> Log "TradeSender client application build output: "
    
    ensureDirectory buildTradeBlotterAppDir
    
    !! "dealcaptureservice/Apps/TransactionBlotter/TransactionBlotter.sln"
    |> MSBuildRelease buildTradeBlotterAppDir "Build"
    |> Log "TransactionBlotter client application build output: "


)

Target "Generate" (fun _ ->
    let parentDirectory = Directory.GetParent(__SOURCE_DIRECTORY__).FullName
    //Generate xcstudio.cmd
    trace("Generating xcstudio.cmd")
    let studioScriptContents = [| "pushd %~dp0"
        ;"cd /d  \"" + Path.Combine(parentDirectory, "packages\\xcomponent.community\\tools\XCStudio") + "\""
        ;"start \"\" XCStudio.exe \"" + Path.Combine(__SOURCE_DIRECTORY__, "dealcaptureService\\DealcaptureCore\\DealCapture_Model.xcml") + "\""
        ;"popd" |]
    File.WriteAllLines(studioScriptPath, studioScriptContents)    

    //Generate startDealService.cmd
    trace("Generating startDealService.cmd")
    let startDealMicroserviceScriptContents = [| "pushd %~dp0"
        ;"cd /d \"" + Path.Combine(parentDirectory, "packages\\xcomponent.community\\tools\XCStudio\XCRuntime") + "\""
        ;"start \"\" XCRuntime.exe \"" + Path.Combine(__SOURCE_DIRECTORY__, "build\\exportMicroservice\\xcassemblies\\DealCapture-dealService.xcr") + "\""
        ;"popd"|]
    File.WriteAllLines(startDealMicroserviceScriptPath, startDealMicroserviceScriptContents)    

//Generate startReferentialService.cmd
    trace("Generating startReferentialService.cmd")
    let startReferentialMicroserviceScriptContents = [| "pushd %~dp0"
        ;"cd /d \"" + Path.Combine(parentDirectory, "packages\\xcomponent.community\\tools\XCStudio\XCRuntime") + "\""
        ;"start \"\" XCRuntime.exe \"" + Path.Combine(__SOURCE_DIRECTORY__, "build\\exportMicroservice\\xcassemblies\\DealCapture-ReferentialService.xcr") + "\""
        ;"popd"|]
    File.WriteAllLines(startReferentialMicroserviceScriptPath, startReferentialMicroserviceScriptContents)    
    
    //Generate startTradeSenderGui.cmd
    trace("Generating startTradeSenderGui.cmd")
    let startConsoleAppScriptContents = [| "pushd %~dp0"
        ;"cd /d \"" + Path.Combine(__SOURCE_DIRECTORY__, "build\\tradeBlotterApp") + "\""
        ;"start \"\" TradeSender.exe"
        ;"popd"|]
    File.WriteAllLines(startTradeSenderScriptPath, startConsoleAppScriptContents)    

    //Generate TransactionBlotter.cmd
    trace("Generating startTradeBlotterGui.cmd")
    let startConsoleAppScriptContents = [| "pushd %~dp0"
        ;"cd /d \"" + Path.Combine(__SOURCE_DIRECTORY__, "build\\tradeBlotterApp") + "\""
        ;"start \"\" DealCapture.exe"
        ;"popd"|]
    File.WriteAllLines(startTradeBlotterScriptPath, startConsoleAppScriptContents)    
)
  
// Default target
Target "Help" (fun _ ->
    List.iter printfn [
      "xcomponent.dealcapture build usage: "      
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