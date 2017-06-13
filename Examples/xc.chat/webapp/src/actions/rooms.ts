import { Action, Dispatch } from "redux";
import { ThunkAction } from "redux-thunk";
import { StateMachineRef } from "reactivexcomponent.js/lib/types/communication/xcomponentMessages";
import { startListener } from "coreListener";

export const ADD_ROOM_EVENT = "ADD_ROOM_EVENT";
export const REMOVE_ROOM_EVENT = "REMOVE_ROOM_EVENT";
export const SELECT_ROOM_EVENT = "SELECT_ROOM_EVENT";
export const ADD_MESSAGE_EVENT = "ADD_MESSAGE_EVENT";
export const CONNECT_EVENT = "CONNECT_EVENT";

export interface AddRoomDetailsAction extends RoomDetailsAction {
    roomReference: StateMachineRef;
}

export interface RoomDetailsAction extends Action {
    roomName: string;
}

export interface ConnectDetailsAction extends Action {
    host: string;
    port: number;
    login: string;
}

export interface MessageDetailsAction extends Action {
    room: string;
    message: string;
    user: string;
    dateTime: string;
}

export const saveSettingsEvent = (host: string, port: number, login: string): ConnectDetailsAction => {
    return {
        type: CONNECT_EVENT,
        host: host,
        port: port,
        login: login,
    };
};

export const connectEvent  = (host: string, port: number, login: string): ThunkAction<void, any, void> => {
    return (dispatch: Dispatch<any>) => {
        dispatch(saveSettingsEvent(host, port, login));
        startListener(dispatch, host, port);
    };
};

export const addRoomEvent = (roomName: string, roomReference: StateMachineRef): AddRoomDetailsAction => {
    return {
        type: ADD_ROOM_EVENT,
        roomName: roomName,
        roomReference: roomReference,
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

export const addMessageEvent = (room: string, dateTime: string, message: string, user: string): MessageDetailsAction => {
    return {
        type: ADD_MESSAGE_EVENT,
        room: room,
        message: message,
        user: user,
        dateTime: dateTime
    };
};