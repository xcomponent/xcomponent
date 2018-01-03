/* jshint esversion: 6 */

const xcfunctions = require('./xcfunctions.js');

xcfunctions.registerTriggeredMethod('Calculator', 'CalculatorManager', 'ExecuteOn_EntryPoint', 
    () => {
        return { Senders:  [ { SenderName: 'Init' } ] };
    });

xcfunctions.registerTriggeredMethod('Calculator', 'CalculatorManager', 'ExecuteOn_Ready_From_Up_Through_Prepare', 
    () => {
        return {
                    Senders:  
                    [
                         {
                             SenderName: 'Calculate',
                             SenderParameter: { Number1: 5, Number2: 3},
                             UseContext: true
                         }, 

                         {
                             SenderName: 'Relaunch'
                         }
                     ]
                 };
    });

xcfunctions.registerTriggeredMethod('Calculator', 'Calculator', 'InitializePublicMember', 
    () => {
        return { PublicMember: { Result: 10 } };
    });

xcfunctions.registerTriggeredMethod('Calculator', 'Calculator', 'ExecuteOn_Calculating_From_Ready_Through_Calculate', 
    (event) => {
        const result = event.Number1 * event.Number2;

        if (result >= 0) {
            return {
                PublicMember: { Result : result },
                Senders: [ 
                    {
                        SenderName: 'Finished',
                        UseContext: true,
                        SenderParameter: { Result: result }
                    }
                ]
            };
        } else {
            return {
                PublicMember: { ErrorMessage: 'Bad value' },
                Senders: [
                    {
                        SenderName: 'Finished',
                        UseContext: true,
                        SenderParameter: { Result: result }
                    }
                ]
            };
        }
    });

xcfunctions.registerTriggeredMethod('Calculator', 'Calculator', 'ExecuteOn_Done_From_Calculating_Through_Finished', 
    (event) => {
        return { PublicMember: { Result: event.Result } };
    });

xcfunctions.startEventQueue();

