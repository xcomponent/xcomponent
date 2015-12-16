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

// start build
RunTargetOrDefault "Help"