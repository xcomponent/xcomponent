const xcfunctions = require('./xcfunctions.js');

/*const CalculatorManagerExecuter = setInterval(function()
{
   getTask('Calculator', 'CalculatorManager', function(err, taskObj)
    {
        if (err && err != nullBodyError) {
            console.error(err);
            return;
        }
        if( taskObj != null)
        {
            console.log("Getting Task: ", taskObj);
            var jsonResponse;
            if( taskObj.FunctionName === "ExecuteOn_EntryPoint") // DONE
            {
               jsonResponse = {
                   "ComponentName":taskObj.ComponentName,
                   "StateMachineName":taskObj.StateMachineName,
                   "Senders" :  
                    [
                        {
                            "SenderName" : "Init",
                        }
                    ],
                   "RequestId":taskObj.RequestId
               };

               console.log("Response : ", jsonResponse);
               postResult(postOptions, JSON.stringify(jsonResponse));
            }
            else if( taskObj.FunctionName === "ExecuteOn_Ready_From_Up_Through_Prepare") // DONE
            {
                jsonResponse = {
                    "ComponentName":taskObj.ComponentName,
                    "StateMachineName":taskObj.StateMachineName,
                    "Senders" :  
                    [
                         {
                             "SenderName" : "Calculate",
                             "SenderParameter" : { "Number1" : 5, "Number2" : 3},
                             "UseContext" : true
                         }, 
                         {
                             "SenderName" : "Relaunch"
                         }
                     ] ,
                    "RequestId":taskObj.RequestId
                };
 
                console.log("Response : ", jsonResponse);
                postResult(postOptions, JSON.stringify(jsonResponse));
            }
            else
            {
                console.error("Unknown task : ", taskObj);
            }
       }
   });
}, 1000);

//Execute on calculor 
 setInterval(function()
 {
    getTask('Calculator', 'Calculator', function(err, taskObj)
    {
        if (err && err != nullBodyError) {
            console.error(err);
            return;
        } 
        else 
        {
            clearTimeout(CalculatorManagerExecuter);
            if( taskObj != null)
            {
                console.log("Getting Task: ", taskObj);
                var result = 0;
                var jsonResponse;
                if( taskObj.FunctionName === "InitializePublicMember") // DONE
                    {
                        jsonResponse = JSON.stringify({
                            "ComponentName":taskObj.ComponentName,
                            "StateMachineName":taskObj.StateMachineName,
                            "PublicMember": {"Result" : 10},
                            "Senders" : [],
                            "RequestId":taskObj.RequestId
                        });
        
                        console.log("Response : ", jsonResponse);
                        postResult(postOptions, jsonResponse);
                    }
                else if( taskObj.FunctionName === "ExecuteOn_Calculating_From_Ready_Through_Calculate")
                {
                    var number1 = taskObj.Event.Number1;
                    var number2 = taskObj.Event.Number2;
                    var result = number1 * number2;
                    if(result >= 0)
                    {
                        jsonResponse = JSON.stringify({
                            "ComponentName":taskObj.ComponentName,
                            "StateMachineName":taskObj.StateMachineName,
                            "PublicMember": {"Result" : result},
                            "Senders" : 
                            [
                                {
                                    "SenderName" : "Finished",
                                    "UseContext" : true,
                                    "SenderParameter": {
                                        "Result" : result,
                                    }
                                }
                            ] ,
                            "RequestId":taskObj.RequestId
                        });
                    }
                    else
                    {
                        jsonResponse = JSON.stringify({
                            "ComponentName":taskObj.ComponentName,
                            "StateMachineName":taskObj.StateMachineName,
                            "PublicMember": { "ErrorMessage" : "Bad value" },
                            "Senders" : 
                            [
                                {
                                    "SenderName" : "Error",
                                    "UseContext" : true,
                                    "SenderParameter": {
                                        "Result" : taskObj.Value,
                                    }
                                }
                            ] ,
                            "RequestId":taskObj.RequestId
                        });
                    }
    
                    console.log("Response : ", jsonResponse);
                    postResult(postOptions, jsonResponse);
                }
                else if( taskObj.FunctionName === "ExecuteOn_Done_From_Calculating_Through_Finished")
                {
                    var result = taskObj.Event.Result;
                    jsonResponse = JSON.stringify({
                        "ComponentName":taskObj.ComponentName,
                        "StateMachineName":taskObj.StateMachineName,
                        "PublicMember": {"Result" : result},
                        "Senders" : [],
                        "RequestId":taskObj.RequestId
                    });
    
                    console.log("Response : ", jsonResponse);
                    postResult(postOptions, jsonResponse);
                }
                else
                {
                    console.error("Unknown task : ", taskObj);
                }
            }        
        }
    });
 }, 1000); */

 

xcfunctions.registerTriggeredMethod('Calculator', 'CalculatorManager', 'ExecuteOn_EntryPoint', () => {
        return { 'Senders' :  [ { 'SenderName' : 'Init' } ] };
    });

xcfunctions.registerTriggeredMethod('Calculator', 'CalculatorManager', 'ExecuteOn_Ready_From_Up_Through_Prepare', () => {
        return {
                    "Senders" :  
                    [
                         {
                             "SenderName" : "Calculate",
                             "SenderParameter" : { "Number1" : 5, "Number2" : 3},
                             "UseContext" : true
                         }, 

                         {
                             "SenderName" : "Relaunch"
                         }
                     ]
                 };
    });

xcfunctions.registerTriggeredMethod('Calculator', 'Calculator', 'InitializePublicMember', () => {
        return {"PublicMember": {"Result" : 10}};
    });

xcfunctions.startEventQueue();

