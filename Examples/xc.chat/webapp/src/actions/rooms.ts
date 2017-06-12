import { Action, Dispatch } from "redux";
import { ThunkAction } from "redux-thunk";

export const ADD_ROOM_EVENT = "ADD_ROOM_EVENT";
export const REMOVE_ROOM_EVENT = "REMOVE_ROOM_EVENT";
export const SELECT_ROOM_EVENT = "SELECT_ROOM_EVENT";
export const ADD_MESSAGE_EVENT = "ADD_MESSAGE_EVENT";

export interface RoomDetailsAction extends Action {
    roomName: string;
}

export interface MessageDetailsAction extends Action {
    room: string;
    message: string;
    user: string;
}

export const addRoomEvent = (roomName: string): RoomDetailsAction => {
    return {
        type: ADD_ROOM_EVENT,
        roomName: roomName
    };
};

export const removeRoomEvent = (roomName: string): RoomDetailsAction => {
    return {
        type: REMOVE_ROOM_EVENT,
        roomName: roomName
    };
};

export const selectRoomEvent = (roomName: string): RoomDetailsAction => {
    return {
        type: SELECT_ROOM_EVENT,
        roomName: roomName
    };
};

export const addMessageEvent = (room: string, message: string, user: string): MessageDetailsAction => {
    return {
        type: ADD_MESSAGE_EVENT,
        room: room,
        message: message,
        user: user,
    };
};