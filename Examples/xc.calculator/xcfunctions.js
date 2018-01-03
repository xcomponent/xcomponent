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
};

exports.startEventQueue= () => {
    console.log('Registered triggered methods: ', triggeredMethods);
    setInterval(eventQueue, 1000);
    console.log('Waiting for tasks...');
};

function processTaskResponse(error, result) {
    if (error) {
        console.error(error);
        return;
    }
}

function senderHandler(target, name) {
    return (parameter, useContext) => {
        target.Senders.push({
            SenderName: name,
            SenderParameter: parameter || {},
            UseContext: useContext || false
        });
    };
}

function eventQueue() {
    for(const componentName in triggeredMethods) {
        for(const stateMachineName in triggeredMethods[componentName]) {
            getTask(componentName, stateMachineName, (error, task) => 
                {
                    if (error) {
                        if (error !== nullBodyError && !(error.code && error.code === 'ECONNREFUSED') ) {
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
                    const sendersList = [];
                    const sender = new Proxy({ Senders: sendersList }, { get: senderHandler });

                    triggeredMethod(task.Event, task.PublicMember, task.InternalMember, task.Context, sender);
                    
                    if (!error) {
                        const augmentedResponse = {
// jshint ignore:start
                            Senders: sendersList,
                            PublicMember: task.PublicMember,
                            InternalMember: task.InternalMember,
                            ComponentName: task.ComponentName,
                            StateMachineName: task.StateMachineName,
                            RequestId: task.RequestId
// jshint ignore:end
                        }

                        console.log('Posted response: ', augmentedResponse);
                        postResult(augmentedResponse);
                    }
                });
        }
    }
}
