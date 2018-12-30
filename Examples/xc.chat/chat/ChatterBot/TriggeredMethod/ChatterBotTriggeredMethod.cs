using System;
using XComponent.ChatManager.UserObject;
using XComponent.ChatterBot.Common;
using XComponent.ChatterBot.Common.Senders;
using XComponent.Common.ApiContext;
using XComponent.Common.Timeouts;
using XComponent.Shared;

namespace XComponent.ChatterBot.TriggeredMethod
{
    public static class ChatterBotTriggeredMethod
    {
        public static void ExecuteOn_Up_Through_Receive(XComponent.ChatManager.UserObject.PublishedMessage publishedMessage, XComponent.ChatterBot.UserObject.ChatterBot chatterBot, object object_InternalMember, RuntimeContext context, IReceivePublishedMessageOnUpChatterBotSenderInterface sender)
        {
            if (publishedMessage.Message.Contains(chatterBot.Name))
            {
                TriggeredMethodContext.Instance.GetDefaultLogger().Info($"Message from {publishedMessage.User} in room {publishedMessage.Room} received");
                SendMessage($"Hello {publishedMessage.User}!", chatterBot, context, sender.Send);
            }
        }

        private static void SendMessage(string message, UserObject.ChatterBot chatterBot, RuntimeContext context,
            Action<RuntimeContext, SentMessage, string> sendMessageAction)
        {
            sendMessageAction(context, new SentMessage()
            {
                Message = message,
                User = chatterBot.Name
            }, null);
        }

        public static void ExecuteOn_Up_Through_Init(XComponent.Common.Event.DefaultEvent defaultEvent, XComponent.ChatterBot.UserObject.ChatterBot chatterBot, object object_InternalMember, RuntimeContext context, IInitDefaultEventOnUpChatterBotSenderInterface sender)
        {
            TriggeredMethodContext.Instance.GetDefaultLogger().Info("Chatter bot is up!");
            chatterBot.Name = "RealBot";
            TriggeredMethodContext.Instance.GetDefaultLogger().Info($"My name is {chatterBot.Name}");

            SendMessage("Hello world!", chatterBot, context, sender.Send);
        }
    }
}