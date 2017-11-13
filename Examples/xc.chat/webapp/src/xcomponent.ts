import * as promisify from "es6-promisify";
import xcapi from "reactivexcomponent.js";
import { chatApiName } from "settings";
import { xcLogLevels } from "reactivexcomponent.js";

export const promiseCreateSession = promisify(xcapi.createSession, xcapi);
xcapi .setLogLevel(xcLogLevels.DEBUG);

let session;

const create = (host: string, port: number) => {
    xcapi.setLogLevel(xcLogLevels.INFO);
    return promiseCreateSession(chatApiName, `ws://${host}:${port}`);
};

export const promiseSession = (host: string, port: number) => {
    if (!session) {
        session = create(host, port);
    }

    return session;
};