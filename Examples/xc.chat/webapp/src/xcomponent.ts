import * as promisify from "es6-promisify";
import xcapi from "reactivexcomponent.js";
import { xcomponentServerUrl, chatApiName } from "settings";
import { xcLogLevels } from "reactivexcomponent.js";

export const promiseCreateSession = promisify(xcapi.createSession, xcapi);

const create = () => {
    xcapi.setLogLevel(xcLogLevels.INFO);
    return promiseCreateSession(chatApiName, xcomponentServerUrl);
};

export const promiseSession = create();