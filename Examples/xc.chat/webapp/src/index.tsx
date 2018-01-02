import "scss/index.scss";

import * as React from "react";
import * as ReactDOM from "react-dom";
import { createStore, applyMiddleware } from "redux";
import * as App from "grommet/components/App";
import { Provider } from "react-redux";
import { Router, Route, browserHistory, IndexRoute } from "react-router";
import { routes } from "routes";
import { routeChanged } from "actions";
import { createAndInitStore } from "store";
import { xcomponentcChatReducer } from "reducers/xcomponentChat";
import { Store } from "redux";
import { IntlProvider } from "react-intl";
import { getLocalizedResources } from "locales/localeConfiguration";

const render = (store: Store<{}>) => {
  ReactDOM.render(
    <Provider store={store} >
      <IntlProvider locale="en" messages={getLocalizedResources()}>
        <Router routes={routes} history={browserHistory}>
        </Router>
      </IntlProvider>
    </Provider>,
    document.getElementById("app")
  );
};

const store = createAndInitStore(xcomponentcChatReducer, render, browserHistory);

// listen for history changes and initiate routeChanged actions for them
browserHistory.listen(function (location) {
  store.dispatch(routeChanged(window.location.pathname));
});