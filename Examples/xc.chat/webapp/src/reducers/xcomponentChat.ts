import { combineReducers } from "redux";
import { navigation } from "reducers/navigation";
import { rooms } from "reducers/rooms";

export const xcomponentcChatReducer = combineReducers({
    nav: navigation,
    chatRoom: rooms,
});