using System;
using XComponent.ChatManager.Common;
using XComponent.ChatManager.Common.Senders;
using XComponent.ChatManager.UserObject;
using XComponent.Common.ApiContext;
using XComponent.Common.Timeouts;
using XComponent.Shared;

namespace XComponent.ChatManager.TriggeredMethod
{
    public static class ChatroomTriggeredMethod
    {
        public static void ExecuteOn_Created_Through_PublishMessage(XComponent.ChatManager.UserObject.SentMessage sentMessage, XComponent.ChatManager.UserObject.Chatroom chatroom, object object_InternalMember, Context context, IPublishMessageSentMessageOnCreatedChatroomSenderInterface sender)
        {
            sender.PublishMessage(context, new PublishedMessage
            {
                Message = sentMessage.Message,
                Room = chatroom.Name,
                User = sentMessage.User,
                DateTime = DateTime.Now
            });
            context.PublishNotification = false;
        }

        public static void ExecuteOn_Created_Through_CreateRoom(XComponent.ChatManager.UserObject.CreateChatroom createChatroom, XComponent.ChatManager.UserObject.Chatroom chatroom, object object_InternalMember, Context context, ICreateRoomCreateChatroomOnCreatedChatroomSenderInterface sender)
        {
            chatroom.Name = createChatroom.Name;
        }
    }
}