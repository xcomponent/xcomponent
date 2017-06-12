import { combineReducers } from "redux";
import { navigation } from "reducers/navigation";
import { rooms } from "reducers/rooms";
import {reactScrollCollapse} from "react-scroll-collapse";

export const xcomponentcChatReducer = combineReducers({
    nav: navigation,
    chatRoom: rooms,
    reactScrollCollapse: reactScrollCollapse,
});