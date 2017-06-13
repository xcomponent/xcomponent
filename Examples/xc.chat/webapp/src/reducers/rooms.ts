import { Reducer, Action } from "redux";
import { promiseSession } from "xcomponent";
import { ADD_ROOM_EVENT, REMOVE_ROOM_EVENT, SELECT_ROOM_EVENT, ADD_MESSAGE_EVENT, CONNECT_EVENT, AddRoomDetailsAction, RoomDetailsAction, MessageDetailsAction, ConnectDetailsAction } from "actions";
import { StateMachineRef } from "reactivexcomponent.js/lib/types/communication/xcomponentMessages";

export interface RoomsState {
    availableRooms: Room[];
    selectedRoom: Room;
    messages: string[];
    settings: Settings;
}

export interface Room {
    reference: StateMachineRef;
    name: string;
}

export interface Settings {
    host: string;
    port: number;
    login: string;
}

export const rooms: Reducer<RoomsState> = (state: RoomsState = { availableRooms: [], selectedRoom: null, messages: [], settings: {host: "localhost", port: 443, login: ""} }, action: Action) => {
    switch (action.type) {
        case ADD_ROOM_EVENT:
            const addRoomAction = <AddRoomDetailsAction>action;
            if (state.availableRooms.filter(room => room.name === addRoomAction.roomName).length === 0) {
                let newRoom = { name: addRoomAction.roomName, reference: addRoomAction.roomReference };
                return {
                    ...state,
                    availableRooms: [...state.availableRooms, newRoom],
                    selectedRoom: state.selectedRoom  ? state.selectedRoom : newRoom
                };
            }
            else {
                return state;
            }
        case REMOVE_ROOM_EVENT:
            const removeRoomAction = <RoomDetailsAction>action;
            const roomToRemoveIndex = state.availableRooms.findIndex(room => room.name === removeRoomAction.roomName);
            const updatedRooms = [
                ...state.availableRooms.slice(0, roomToRemoveIndex),
                ...state.availableRooms.slice(roomToRemoveIndex + 1)
            ];
            return {
                ...state,
                availableRooms: updatedRooms
            };
        case SELECT_ROOM_EVENT:
            const selectRoomAction = <RoomDetailsAction>action;
            if (state.selectedRoom !== null && state.selectedRoom.name === selectRoomAction.roomName) {
                return state;
            }
            else {
                return {
                    ...state,
                    selectedRoom: state.availableRooms.find(availableRoom => availableRoom.name === selectRoomAction.roomName),
                    messages: []
                };
            }
        case ADD_MESSAGE_EVENT:
            const messagesAction = <MessageDetailsAction>action;
            if (state.selectedRoom !== null && messagesAction.room === state.selectedRoom.name) {
                return {
                    ...state,
                    messages: [...state.messages,  messagesAction.dateTime + " [" + messagesAction.user + "] : " + messagesAction.message]
                };
            }
            else {
                return state;
            }
        case CONNECT_EVENT:
            const connectAction = <ConnectDetailsAction>action;
            return {
                ...state,
                settings: {host: connectAction.host, port: connectAction.port, login: connectAction.login},
            };
        default:
            return state;
    }
};