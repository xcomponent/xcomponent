import { navActivate, NAV_ACTIVATE, NavigationAction } from "actions";
import { Reducer } from "redux";

export interface NavigationState {
    active: boolean;
}

export const navigation: Reducer<NavigationState> = (state: NavigationState = { active: false }, action: NavigationAction) => {
    switch (action.type) {
        case NAV_ACTIVATE:
            return { active: action.status };
        default:
            return state;
    }
};