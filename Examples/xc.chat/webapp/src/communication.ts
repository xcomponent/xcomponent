import { promiseSession } from "xcomponent";
import { Dispatch } from "redux";
import { addRoomEvent, removeRoomEvent, addMessageEvent } from "actions";
import { RoomsState, Room } from "reducers/rooms";
import * as uuid from "uuid";

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

                        let publisher = session.createPublisher();
                        let historyManagerComponent = "HistoryManager";
                        let historyManagerStateMachine = "HistoryManager";
                        let publishedHistoryStateMachine = "PublishedHistory";
                        let historyRequestType = "XComponent.HistoryManager.UserObject.HistoryRequest";
                        let historyResponseType = "XComponent.HistoryManager.UserObject.PublishedHistory";

                        console.log("Trying to retrieve room history...", chatRoom.jsonMessage.Name);
                        if (publisher.canPublish(historyManagerComponent, historyManagerStateMachine, historyRequestType)) {
                            let privateTopic = uuid();

                            console.log("Creating private topic for response...", privateTopic);
                            session.addPrivateTopic(privateTopic);
                            if (subscriber.canSubscribe(historyManagerComponent, publishedHistoryStateMachine)) {
                                subscriber
                                    .getStateMachineUpdates(historyManagerComponent, publishedHistoryStateMachine)
                                    .subscribe(jsonData => {
                                        console.log("Received json data", jsonData);
                                        let messages: {Room: string, User: string, Message: string, DateTime: string}[] = jsonData.jsonMessage.Messages;

                                        messages.forEach(message => {
                                            dispatch(addMessageEvent(message.Room, message.DateTime, message.Message, message.User));
                                        });

                                        console.log("Removing private topic... ", privateTopic);
                                        session.removePrivateTopic(privateTopic);
                                    });
                            } else {
                                console.error("History manager subscriber not available on the API!");
                            }

                            console.log("Sending history request...");
                            publisher.send(historyManagerComponent, historyManagerStateMachine, historyRequestType, {
                                "RoomName": chatRoom.jsonMessage.Name,
                                "ResponseTopic": privateTopic
                            });
                        } else {
                            console.error("History manager publisher not available on the API!");
                        }
                    }
                });
            });
        const messagesSubscriberCollection = subscriber.getStateMachineUpdates(chatComponentName, publishedMessageMachineName)
            .subscribe(jsonData => {
                dispatch(addMessageEvent(jsonData.jsonMessage.Room, jsonData.jsonMessage.DateTime, jsonData.jsonMessage.Message, jsonData.jsonMessage.User));
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
        const visibility = false;

        const publisher = session.createPublisher();
        publisher.sendWithStateMachineRef(room.reference, messageType, jsonMessage, visibility, null);

    })
        .catch((error) => {
            console.log(error);
        });
};

export const createRoom = (roomName: string, host: string, port: number) => {
    promiseSession(host, port).then(session => {
        const jsonMessage = { "Name": roomName };
        const messageType = "XComponent.ChatManager.UserObject.CreateChatroom";
        const visibility = false;

        const publisher = session.createPublisher();
        publisher.send("ChatManager", "ChatManager", messageType, jsonMessage, visibility, null);

    })
        .catch((error) => {
            console.log(error);
        });
};

export const closeRoom = (room: Room, host: string, port: number) => {
    promiseSession(host, port).then(session => {
        const jsonMessage = {};
        const messageType = "XComponent.ChatManager.UserObject.CloseRoom";
        const visibility = false;

        const publisher = session.createPublisher();
        publisher.sendWithStateMachineRef(room.reference, messageType, jsonMessage, visibility, null);
    })
        .catch((error) => {
            console.log(error);
        });
};