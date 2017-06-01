using System;
using XComponent.ChatManager.Common;
using XComponent.ChatManager.Common.Senders;
using XComponent.Common.ApiContext;
using XComponent.Common.Timeouts;

namespace XComponent.ChatManager.TriggeredMethod
{
    public static class PublishedMessageTriggeredMethod
    {
        public static void ExecuteOn_Published_Through_PublishMessage(XComponent.ChatManager.UserObject.PublishedMessage publishedMessage, XComponent.ChatManager.UserObject.PublishedMessage publishedMessage_PublicMember, object object_InternalMember, Context context, IPublishMessagePublishedMessageOnPublishedPublishedMessageSenderInterface sender)
        {
            publishedMessage_PublicMember.Message = publishedMessage.Message;
            publishedMessage_PublicMember.Room = publishedMessage.Room;
            publishedMessage_PublicMember.User = publishedMessage.User;
        }
    }
}