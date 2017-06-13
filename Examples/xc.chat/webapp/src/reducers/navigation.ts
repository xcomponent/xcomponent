import { navActivate, NAV_ACTIVATE, ROOM_CREATION, NavigationAction } from "actions";
import { Reducer } from "redux";

export interface NavigationState {
    active: boolean;
    creatingRoom: boolean;
}

export const navigation: Reducer<NavigationState> = (state: NavigationState = { active: false, creatingRoom: false }, action: NavigationAction) => {
    switch (action.type) {
        case NAV_ACTIVATE:
            return {
                ...state,
                active: action.status
             };
        case ROOM_CREATION:
            return {
                ...state,
                creatingRoom: action.creatingRoom
            };
        default:
            return state;
    }
};