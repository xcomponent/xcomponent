import { Action } from "redux";
export const NAV_ACTIVATE = "NAV_ACTIVATE";

export interface NavigationAction extends Action {
    type: any;
    status: boolean;
}

export const navActivate = (isActivated: boolean) : NavigationAction => {
    return {
        type: NAV_ACTIVATE,
        status: isActivated
    };
};