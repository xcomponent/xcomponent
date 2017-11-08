using System;
using XComponent.Common.ApiContext;
using XComponent.Common.Timeouts;
using XComponent.LoggerComponent.Common;
using XComponent.LoggerComponent.Common.Senders;
using XComponent.Shared;

namespace XComponent.LoggerComponent.TriggeredMethod
{
    public static class LoggerComponentTriggeredMethod
    {
        public static void ExecuteOn_Up_Through_LogMessage(XComponent.ChatManager.UserObject.PublishedMessage publishedMessage, object object_PublicMember, object object_InternalMember, Context context, ILogMessagePublishedMessageOnUpLoggerComponentSenderInterface sender)
        {
            Console.WriteLine($"Message published: {publishedMessage.DateTime}: {publishedMessage.Room} {publishedMessage.User}: {publishedMessage.Message}");
        }
    }
}