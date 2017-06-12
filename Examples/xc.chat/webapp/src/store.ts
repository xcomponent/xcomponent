import thunkMiddleware from "redux-thunk";
import { createStore, applyMiddleware } from "redux";
import { routeChanged } from "actions";
import { HOME_ROUTE } from "actions";
import { startListener } from "coreListener";

export const createAndInitStore = (mainReducer, render, browserHistory) => {

    const middlewares = [
        thunkMiddleware
    ];

    if (process.env.NODE_ENV !== `production`) {
        const createLogger = require(`redux-logger`);
        const logger = createLogger();
        middlewares.push(logger);
    }

    const store = createStore(mainReducer, applyMiddleware(...middlewares));

    render(store);

    startListener(store.dispatch);

    return store;
};