import { XComponent } from "reactivexcomponent.js";
import { chatApiName } from "settings";
import { LogLevel } from "reactivexcomponent.js";

const xcomponent = new XComponent();

xcomponent.setLogLevel(LogLevel.DEBUG);

let session;

const create = (host: string, port: number) => {
    xcomponent.setLogLevel(LogLevel.INFO);
    const serverUrl =  `ws://${host}:${port}`;
    return xcomponent
        .connect(serverUrl)
        .then(connection => connection.createSession(chatApiName));
};

export const promiseSession = (host: string, port: number) => {
    if (!session) {
        session = create(host, port);
    }

    return session;
};
