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

    session.getSnapshot(chatComponentName, chatRoomStateMachineName).then(items =>
      items.forEach(chatRoom => {
        if (chatRoom.stateMachineRef.StateName === "Created") {
          dispatch(addRoomEvent(chatRoom.jsonMessage.Name, chatRoom.stateMachineRef));

          const historyManagerComponent = "HistoryManager";
          const historyManagerStateMachine = "HistoryManager";
          const publishedHistoryStateMachine = "PublishedHistory";
          const historyRequestType = "XComponent.HistoryManager.UserObject.HistoryRequest";
          const historyResponseType = "XComponent.HistoryManager.UserObject.PublishedHistory";

          console.log("Trying to retrieve room history...", chatRoom.jsonMessage.Name);
          if (session.canSend(historyManagerComponent, historyManagerStateMachine, historyRequestType)) {
            if (session.canSubscribe(historyManagerComponent, publishedHistoryStateMachine)) {
              session
                .getStateMachineUpdates(historyManagerComponent, publishedHistoryStateMachine)
                .subscribe(jsonData => {
                    console.log("Received json data", jsonData);
                    const messages: {Room: string, User: string, Message: string, DateTime: string}[] = jsonData.jsonMessage.Messages;

                    messages.forEach(message => {
                      if (message.Room === chatRoom.jsonMessage.Name) {
                        dispatch(addMessageEvent(message.Room, message.DateTime, message.Message, message.User));
                      }
                    });
                });
            } else {
              console.error("Can't subscribe to history manager subscriber!");
            }

            console.log("Sending history request...");
            session.send(
              historyManagerComponent,
              historyManagerStateMachine,
              historyRequestType,
              {
                "RoomName": chatRoom.jsonMessage.Name,
                "ResponseTopic": session.privateTopics.getDefaultPublisherTopic()
              });
          } else {
            console.error("Can't sent messages to history manager!");
          }
        }
      })
    );
    const messagesSubscriberCollection = session.getStateMachineUpdates(chatComponentName, publishedMessageMachineName)
      .subscribe(jsonData => {
        dispatch(addMessageEvent(jsonData.jsonMessage.Room, jsonData.jsonMessage.DateTime, jsonData.jsonMessage.Message, jsonData.jsonMessage.User));
      });
    const subscriberCollection = session.getStateMachineUpdates(chatComponentName, chatRoomStateMachineName)
      .subscribe(jsonData => {
        if (jsonData.stateMachineRef.StateName === "Created") {
          dispatch(addRoomEvent(jsonData.jsonMessage.Name, jsonData.stateMachineRef));
        } else {
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

    room.reference.send(messageType, jsonMessage, visibility, null);
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

    session.send("ChatManager", "ChatManager", messageType, jsonMessage, visibility, null);
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

    room.reference.send(messageType, jsonMessage, visibility);
  })
  .catch((error) => {
    console.log(error);
  });
};
