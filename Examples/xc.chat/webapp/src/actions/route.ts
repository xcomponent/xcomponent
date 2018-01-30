import { ThunkAction } from "redux-thunk";
import { Dispatch } from "redux";

export const HOME_ROUTE = "home";

export const routeChanged  = (pathName: string): ThunkAction<void, any, void> => {
    return (dispatch: Dispatch<any>) => { };
};