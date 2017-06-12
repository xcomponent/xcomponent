import { promiseSession } from "xcomponent";
import { Dispatch } from "redux";
import { addRoomEvent, removeRoomEvent, addMessageEvent } from "actions";
import { RoomsState } from "reducers/rooms";

export const startListener = (dispatch: Dispatch<RoomsState>) => {
    promiseSession.then(session => {
        const chatComponentName = "ChatManager";
        const chatRoomStateMachineName = "Chatroom";
        const publishedMessageMachineName = "PublishedMessage";
        const subscriber = session.createSubscriber();
            subscriber.getSnapshot(chatComponentName, chatRoomStateMachineName, function (items) {
                items.forEach(function(chatRoom) {
                    dispatch(addRoomEvent(chatRoom.jsonMessage.Name));
                });
            });
        const messagesSubscriberCollection = subscriber.getStateMachineUpdates(chatComponentName, publishedMessageMachineName)
            .subscribe(jsonData => {
                dispatch(addMessageEvent(jsonData.jsonMessage.Room, jsonData.jsonMessage.Message, jsonData.jsonMessage.User));
            });
        const subscriberCollection = subscriber.getStateMachineUpdates(chatComponentName, chatRoomStateMachineName)
            .subscribe(jsonData => {
                dispatch(addRoomEvent(jsonData.jsonMessage.Name));
            });
    })
        .catch((error) => {
            console.log(error);
        });
};

export const sendMessage = (room: string, user: string, message: string) => {
    promiseSession.then(session => {
        const chatComponentName = "ChatManager";
        const chatRoomStateMachineName = "Chatroom";
        const jsonMessage = { "User": user, "Message": message, };
        const messageType = "XComponent.ChatManager.UserObject.SentMessage";
        const visibility = true;

        const publisher = session.createPublisher();
        console.error("Plop");

        publisher.send(chatComponentName, chatRoomStateMachineName, messageType, jsonMessage, visibility);

    })
        .catch((error) => {
            console.log(error);
        });
};