import Home from "components/Home";
import ChatApp from "components/ChatApp";
import { HOME_ROUTE } from "actions";

export const routes = [
    {
        path: "/", component: ChatApp, indexRoute: { component: Home },
        childRoutes: [
            { path: HOME_ROUTE, component: Home }
        ]
    }
];