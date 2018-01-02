var http = require('http');

function getOptions(stmPath) {
    return {
        host:"127.0.0.1",
        port: 9676,
        path: stmPath,
        method: 'GET'
    }
}
var postheaders = {
    'Content-Type' : 'application/json',
};
var postOptions = {
    host:"127.0.0.1",
    port: 9676,
    path:'/api/Functions',
    method: 'POST',
    headers : postheaders
};

function getTask(options, cb)
{
    http.request(options, function(res)
    {
        var body = '';
        res.on('data', function(chunk){
                body += chunk;
        });
        res.on("end", function()
        {
            if( body == "null")
            {
                cb("Body is null", null);
                return;
            }
            var taskObj = JSON.parse(body);
           
            cb(null, taskObj);
        });
        res.on('error', cb);
    }
    )
    .on('error', cb)
    .end();
}

function postResult(options, jsonResponse)
{
   
    var post_req = http.request(options, function(res) {
        res.on('data', function (chunk) {
            console.info('POST result:\n');
            process.stdout.write(chunk);
            console.info('\n\nPOST completed');
        });
    });
  
    // post the data
    post_req.write(jsonResponse);
    post_req.end();
    post_req.on('error', function(e) {
        console.error(e);
    });
    
  
}

//Excute on CalculatorManager
var CalculatorManagerExecuter = setInterval(function()
{
   getTask(getOptions('/api/Functions?componentName=Calculator&stateMachineName=CalculatorManager'), function(err, taskObj)
    {
        if( taskObj != null)
        {
            console.log("Getting Task: ", taskObj);
            var jsonResponse;
            if( taskObj.FunctionName === "ExecuteOn_EntryPoint")
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
            else if( taskObj.FunctionName === "ExecuteOn_Ready_From_Up_Through_Prepare")
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
    getTask(getOptions('/api/Functions?componentName=Calculator&stateMachineName=Calculator'), function(err, taskObj)
    {
        if (err) {
            console.error(err);
        } 
        else 
        {
            clearTimeout(CalculatorManagerExecuter);
            if( taskObj != null)
            {
                console.log("Getting Task: ", taskObj);
                var result = 0;
                var jsonResponse;
                if( taskObj.FunctionName === "InitializePublicMember")
                    {
                        var result = taskObj.Event.Result;
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
 }, 1000);

 



