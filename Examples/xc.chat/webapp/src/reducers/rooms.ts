import { Reducer, Action } from "redux";
import { ADD_ROOM_EVENT, REMOVE_ROOM_EVENT, SELECT_ROOM_EVENT, ADD_MESSAGE_EVENT, RoomDetailsAction, MessageDetailsAction } from "actions";

export interface RoomsState {
    availableRooms: string[];
    selectedRoom: string;
    messages: string[];
}

export const rooms: Reducer<RoomsState> = (state: RoomsState = { availableRooms: [], selectedRoom: "", messages: [] }, action: Action) => {
    switch (action.type) {
        case ADD_ROOM_EVENT:
            const addRoomAction = <RoomDetailsAction>action;
            if (state.availableRooms.filter(room => room === addRoomAction.roomName).length === 0) {
                return {
                    ...state,
                    availableRooms: [...state.availableRooms, addRoomAction.roomName]
                };
            }
            else {
                return state;
            }
        case REMOVE_ROOM_EVENT:
            const removeRoomAction = <RoomDetailsAction>action;
            const roomToRemoveIndex = state.availableRooms.findIndex(room => room === removeRoomAction.roomName);
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
            return {
                ...state,
                selectedRoom: selectRoomAction.roomName,
                messages: []
            };
        case ADD_MESSAGE_EVENT:
            const messagesAction = <MessageDetailsAction>action;
            if (messagesAction.room === state.selectedRoom) {
                return {
                    ...state,
                    messages: [...state.messages, messagesAction.user + " : " + messagesAction.message]
                };
            }
            else {
                return state;
            }
        default:
            return state;
    }
};