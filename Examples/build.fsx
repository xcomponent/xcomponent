// include Fake lib
#r @"packages/FAKE/tools/FakeLib.dll"
#r "System.Xml.Linq"

open Fake
open Fake.XMLHelper
open System
open System.Text.RegularExpressions
open System.IO
open System.Xml.Linq
open System.Text


Target "HelloWorld" (fun _ ->    
    trace ("Building XComponent.HelloWorld")
    let timeoutExec = 5.0

    let result = ExecProcess (fun info ->
                    info.FileName <- "build.cmd"
                    info.WorkingDirectory <- Path.Combine(__SOURCE_DIRECTORY__, "xcomponent.helloworld") 
                    info.Arguments <- "All"
                    ) 
                    (TimeSpan.FromMinutes timeoutExec)
  
    if result <> 0 then failwithf "xcomponent.hello build returned with a non-zero exit code"    
)

Target "Authentication" (fun _ ->    
    trace ("Building XComponent.Authentication")
    let timeoutExec = 5.0

    let result = ExecProcess (fun info ->
                    info.FileName <- "build.cmd"
                    info.WorkingDirectory <- Path.Combine(__SOURCE_DIRECTORY__, "xcomponent.authentication") 
                    info.Arguments <- "All"
                    ) 
                    (TimeSpan.FromMinutes timeoutExec)
  
    if result <> 0 then failwithf "xcomponent.authentication build returned with a non-zero exit code"    
)
  
Target "OrderProcessing" (fun _ ->    
    trace ("Building XComponent.OrderProcessing")
    let timeoutExec = 5.0

    let result = ExecProcess (fun info ->
                    info.FileName <- "build.cmd"
                    info.WorkingDirectory <- Path.Combine(__SOURCE_DIRECTORY__, "xcomponent.orderprocessing") 
                    info.Arguments <- "All"
                    ) 
                    (TimeSpan.FromMinutes timeoutExec)
  
    if result <> 0 then failwithf "xcomponent.orderprocessing build returned with a non-zero exit code"    
)

Target "TradeCapture" (fun _ ->    
    trace ("Building Xcomponent.TradeCapture")
    let timeoutExec = 5.0

    let result = ExecProcess (fun info ->
                    info.FileName <- "build.cmd"
                    info.WorkingDirectory <- Path.Combine(__SOURCE_DIRECTORY__, "xcomponent.tradecapture") 
                    info.Arguments <- "All"
                    ) 
                    (TimeSpan.FromMinutes timeoutExec)
  
    if result <> 0 then failwithf "xcomponent.dealcapture build returned with a non-zero exit code"    
)

Target "RestApiClient" (fun _ ->    
    trace ("Building XComponent.RestApiClient")
    let timeoutExec = 5.0

    let result = ExecProcess (fun info ->
                    info.FileName <- "build.cmd"
                    info.WorkingDirectory <- Path.Combine(__SOURCE_DIRECTORY__, "xcomponent.restapiclient") 
                    info.Arguments <- "All"
                    ) 
                    (TimeSpan.FromMinutes timeoutExec)
  
    if result <> 0 then failwithf "xcomponent.restapiclient build returned with a non-zero exit code"    
)

// Default target
Target "Help" (fun _ ->
    List.iter printfn [
      "XComponent examples build usage: "      
      ""
      "build All"      
      ""                  
      ""]
)

Target "All" DoNothing

// Dependencies
"HelloWorld"  
  ==> "All"

"Authentication"    
  ==> "All"

"OrderProcessing"
  ==> "All"

"TradeCapture"
  ==> "All"
  
"RestApiClient"
  ==> "All"
  
// start build
RunTargetOrDefault "Help"