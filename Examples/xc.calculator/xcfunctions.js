/* jshint esversion: 6 */

const http = require('http');

const nullBodyError = 'Body is null';

function getTask(componentName, stateMachineName, callback) {
    const getOptions = (componentName, stateMachineName) => { 
        return {
            host: '127.0.0.1',
            port: 9676,
            path: '/api/Functions?componentName='+escape(componentName)+'&stateMachineName='+escape(stateMachineName),
            method: 'GET'
        };
    };

    http
        .request(getOptions(componentName, stateMachineName), function(response)
        {
            let body = '';
            response.on('data',(data) => {
                body += data;
            });
            response.on('end',() => 
                {
                    if(body === 'null')
                    {
                        callback(nullBodyError, null);
                        return;
                    }

                    try {
                        callback(null, JSON.parse(body));
                    } catch(e) {
                        callback(e, null);
                    }
                });
            response.on('error', callback);
        })
        .on('error', callback)
        .end();
}

function postResult(responseObject, callback) {
    const postOptions = {
        host: '127.0.0.1',
        port: 9676,
        path: '/api/Functions',
        method: 'POST',
        headers : {
            'Content-Type' : 'application/json',
        }
    };

    const request = http.request(postOptions, function(response) {
        response.on('data', (data) => callback(null, data));
    });
  
    request.on('error', function(error) {
        callback(error);
    });

    request.write(JSON.stringify(responseObject));
    request.end();
}

const triggeredMethods = { };

exports.registerTriggeredMethod = (componentName, stateMachineName, triggeredMethodName, triggeredMethodFunction) => {
    if (!(componentName in triggeredMethods)) {
        triggeredMethods[componentName] = { };
    }
    if (!(stateMachineName in triggeredMethods[componentName])) {
        triggeredMethods[componentName][stateMachineName] = { };
    }

    if (!(triggeredMethodName in triggeredMethods[componentName][stateMachineName])) {
        triggeredMethods[componentName][stateMachineName][triggeredMethodName] = triggeredMethodFunction;
    }
}

exports.startEventQueue= () => {
    console.log(triggeredMethods);
    setInterval(eventQueue, 1000);
}

function processTaskResponse(error, result) {
    if (error) {
        console.error(error);
        return;
    }
}

function eventQueue() {
    for(const componentName in triggeredMethods) {
        for(const stateMachineName in triggeredMethods[componentName]) {
            getTask(componentName, stateMachineName, (error, task) => 
                {
                    if (error) {
                        if (error !== nullBodyError) {
                            console.error(error);
                        }
                        return;
                    }

                    console.log('Received task: ', task);

                    if (!(task.FunctionName in triggeredMethods[componentName][stateMachineName])) {
                        console.error('Received task for unregistered function', task.FunctionName);
                        clearTimeout(eventQueue);
                        return;
                    }

                    const triggeredMethod = triggeredMethods[componentName][stateMachineName][task.FunctionName];
                    const response = triggeredMethod();
                    
                    if (!error && response) {
                        const augmentedResponse = {
                            ...response,
                            'ComponentName': task.ComponentName,
                            'StateMachineName': task.StateMachineName,
                            'RequestId': task.RequestId
                        };

                        console.log('Posted response: ', augmentedResponse);
                        postResult(augmentedResponse);
                    }
                });
        }
    }
}
