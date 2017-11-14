using System;
using XComponent.bot.Common;
using XComponent.bot.Common.Senders;
using XComponent.Common.ApiContext;
using XComponent.Common.Timeouts;
using XComponent.Shared;

namespace XComponent.bot.TriggeredMethod
{
    public static class botTriggeredMethod
    {
        public static void ExecuteOn_Up_Through_MessageReceived(XComponent.ChatManager.UserObject.PublishedMessage publishedMessage, XComponent.ChatManager.UserObject.PublishedMessage publishedMessage_PublicMember, object object_InternalMember, Context context, IMessageReceivedPublishedMessageOnUpbotSenderInterface sender)
        {
            const string botName = "bot";

            if (publishedMessage.User != botName)
            {
                Console.WriteLine("Bot received: " + publishedMessage.Message);
                publishedMessage_PublicMember.Message = "Hello " + publishedMessage.Message;
                publishedMessage_PublicMember.User = botName;
                publishedMessage_PublicMember.DateTime = DateTime.Now;
                publishedMessage_PublicMember.Room = publishedMessage.Room;
                context.PublishNotification = true;
            }
            else
            {
                context.PublishNotification = false;
            }
        }
    }
}