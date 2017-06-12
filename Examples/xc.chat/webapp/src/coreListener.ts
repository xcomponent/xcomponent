import { promiseSession } from "xcomponent";
import { Dispatch } from "redux";
import { addRoomEvent, removeRoomEvent, addMessageEvent } from "actions";
import { RoomsState, Room } from "reducers/rooms";

export const startListener = (dispatch: Dispatch<RoomsState>, host: string, port: number) => {
    promiseSession(host, port).then(session => {
        const chatComponentName = "ChatManager";
        const chatRoomStateMachineName = "Chatroom";
        const publishedMessageMachineName = "PublishedMessage";
        const subscriber = session.createSubscriber();
            subscriber.getSnapshot(chatComponentName, chatRoomStateMachineName, function (items) {
                items.forEach(function(chatRoom) {
                    if (chatRoom.stateMachineRef.StateName === "Created") {
                        dispatch(addRoomEvent(chatRoom.jsonMessage.Name, chatRoom.stateMachineRef));
                    }
                });
            });
        const messagesSubscriberCollection = subscriber.getStateMachineUpdates(chatComponentName, publishedMessageMachineName)
            .subscribe(jsonData => {
                dispatch(addMessageEvent(jsonData.jsonMessage.Room, jsonData.jsonMessage.Message, jsonData.jsonMessage.User));
            });
        const subscriberCollection = subscriber.getStateMachineUpdates(chatComponentName, chatRoomStateMachineName)
            .subscribe(jsonData => {
                if (jsonData.stateMachineRef.StateName === "Created") {
                    dispatch(addRoomEvent(jsonData.jsonMessage.Name, jsonData.stateMachineRef));
                }
                else {
                    dispatch(removeRoomEvent(jsonData.jsonMessage.Name));
                }
            });
    })
        .catch((error) => {
            console.log(error);
        });
};

export const sendMessage = (room: Room, user: string, message: string, host: string, port: number) => {
    promiseSession(host, port).then(session => {
        const jsonMessage = { "User": user, "Message": message, };
        const messageType = "XComponent.ChatManager.UserObject.SentMessage";
        const visibility = true;

        const publisher = session.createPublisher();
        publisher.sendWithStateMachineRef(room.reference, messageType, jsonMessage, visibility, null);

    })
        .catch((error) => {
            console.log(error);
        });
};