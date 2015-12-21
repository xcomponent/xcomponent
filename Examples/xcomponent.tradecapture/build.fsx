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
let buildTradeCreatorAppDir = Path.Combine(buildDir, "tradeCreatorApp")
let buildTradeValidatorAppDir = Path.Combine(buildDir, "tradeValidatorApp")
let generatedDir = "./tradecaptureservice/generated/"
let exportDir = Path.Combine(buildDir, "exportMicroservice")
let studioScriptPath = "./xcstudio.cmd"
let startTradeMicroserviceScriptPath = Path.Combine(buildDir, "startTradeService.cmd")
let startReferentialMicroserviceScriptPath = Path.Combine(buildDir, "startReferentialService.cmd")
let startTradeCreatorScriptPath = Path.Combine(buildDir, "startTradeCreatorGui.cmd")
let startTradeValidatorScriptPath = Path.Combine(buildDir, "startTradeValidatorGui.cmd")
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
                    info.Arguments <- "--build --project=\"Tradecaptureservice\\TradeCaptureCore\\TradeCapture_Model.xcml\""
                    ) 
                    (TimeSpan.FromMinutes timeoutExec)
  
    if result <> 0 then failwithf "xctools returned with a non-zero exit code"

    ensureDirectory buildTradeCreatorAppDir

    !! "TradeCaptureservice/Apps/TradeCreator/TradeCreator.sln"
    |> MSBuildRelease buildTradeCreatorAppDir "Build"
    |> Log "TradeCreator client application build output: "
    
    ensureDirectory buildTradeValidatorAppDir
    
    !! "TradeCaptureservice/Apps/TradeValidator/TradeValidator.sln"
    |> MSBuildRelease buildTradeValidatorAppDir "Build"
    |> Log "TradeValidator client application build output: "


)

Target "Generate" (fun _ ->
    let parentDirectory = Directory.GetParent(__SOURCE_DIRECTORY__).FullName
    //Generate xcstudio.cmd
    trace("Generating xcstudio.cmd")
    let studioScriptContents = [| "pushd %~dp0"
        ;"cd /d  \"" + Path.Combine(parentDirectory, "packages\\xcomponent.community\\tools\XCStudio") + "\""
        ;"start \"\" XCStudio.exe \"" + Path.Combine(__SOURCE_DIRECTORY__, "TradeCaptureService\\TradeCaptureCore\\TradeCapture_Model.xcml") + "\""
        ;"popd" |]
    File.WriteAllLines(studioScriptPath, studioScriptContents)    

    //Generate startTradeService.cmd
    trace("Generating startTradeService.cmd")
    let startTradeMicroserviceScriptContents = [| "pushd %~dp0"
        ;"cd /d \"" + Path.Combine(parentDirectory, "packages\\xcomponent.community\\tools\XCStudio\XCRuntime") + "\""
        ;"start \"\" XCRuntime.exe \"" + Path.Combine(__SOURCE_DIRECTORY__, "build\\exportMicroservice\\xcassemblies\\TradeCapture-tradeService.xcr") + "\""
        ;"popd"|]
    File.WriteAllLines(startTradeMicroserviceScriptPath, startTradeMicroserviceScriptContents)    

//Generate startReferentialService.cmd
    trace("Generating startReferentialService.cmd")
    let startReferentialMicroserviceScriptContents = [| "pushd %~dp0"
        ;"cd /d \"" + Path.Combine(parentDirectory, "packages\\xcomponent.community\\tools\XCStudio\XCRuntime") + "\""
        ;"start \"\" XCRuntime.exe \"" + Path.Combine(__SOURCE_DIRECTORY__, "build\\exportMicroservice\\xcassemblies\\TradeCapture-ReferentialService.xcr") + "\""
        ;"popd"|]
    File.WriteAllLines(startReferentialMicroserviceScriptPath, startReferentialMicroserviceScriptContents)    
    
    //Generate startTradeCreatorGui.cmd
    trace("Generating startTradeCreatorGui.cmd")
    let startConsoleAppScriptContents = [| "pushd %~dp0"
        ;"cd /d \"" + Path.Combine(__SOURCE_DIRECTORY__, "build\\tradeCreatorApp") + "\""
        ;"start \"\" TradeCreator.exe"
        ;"popd"|]
    File.WriteAllLines(startTradeCreatorScriptPath, startConsoleAppScriptContents)    

    //Generate startTradeValidatorGui.cmd
    trace("Generating startTradeValidatorGui.cmd")
    let startConsoleAppScriptContents = [| "pushd %~dp0"
        ;"cd /d \"" + Path.Combine(__SOURCE_DIRECTORY__, "build\\tradeValidatorApp") + "\""
        ;"start \"\" TradeValidator.exe"
        ;"popd"|]
    File.WriteAllLines(startTradeValidatorScriptPath, startConsoleAppScriptContents)    
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