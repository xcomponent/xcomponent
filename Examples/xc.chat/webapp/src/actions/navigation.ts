import { Action } from "redux";

export const NAV_ACTIVATE = "NAV_ACTIVATE";
export const ROOM_CREATION = "ROOM_CREATION";

export interface NavigationAction extends Action {
    type: any;
    status: boolean;
    creatingRoom: boolean;
}

export const navActivate = (isActivated: boolean) : NavigationAction => {
    return {
        type: NAV_ACTIVATE,
        status: isActivated,
        creatingRoom: false,
    };
};

export const roomCreation = (createRoom: boolean) : NavigationAction => {
    return {
        type: ROOM_CREATION,
        status: false,
        creatingRoom: createRoom,
    };
};