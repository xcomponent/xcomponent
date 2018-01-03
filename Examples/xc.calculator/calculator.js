/* jshint esversion: 6 */

const xcfunctions = require('./xcfunctions.js');

xcfunctions.registerTriggeredMethod('Calculator', 'CalculatorManager', 'ExecuteOn_EntryPoint', 
    (event, publicMember, internalMember, context, sender) => {
        sender.Init();
    });

xcfunctions.registerTriggeredMethod('Calculator', 'CalculatorManager', 'ExecuteOn_Ready_From_Up_Through_Prepare', 
    (event, publicMember, internalMember, context, sender) => {
        sender.Calculate({ Number1: 5, Number2: 3}, true);
        sender.Relaunch();
    });

xcfunctions.registerTriggeredMethod('Calculator', 'Calculator', 'InitializePublicMember', 
    (event, publicMember) => {
        publicMember.Result = 10;
    });

xcfunctions.registerTriggeredMethod('Calculator', 'Calculator', 'ExecuteOn_Calculating_From_Ready_Through_Calculate', 
    (event, publicMember, internalMember, context, sender) => {
        const result = event.Number1 * event.Number2;

        if (result >= 0) {
            publicMember.Result = result;
            sender.Finished({ Result: result }, true);
        } else {
            publicMember.ErrorMessage = 'Bad value';
            sender.Finished({ Result: result }, true);
        }
    });

xcfunctions.registerTriggeredMethod('Calculator', 'Calculator', 'ExecuteOn_Done_From_Calculating_Through_Finished', 
    (event, publicMember) => {
        publicMember.Result = event.Result;
    });

xcfunctions.startEventQueue();

