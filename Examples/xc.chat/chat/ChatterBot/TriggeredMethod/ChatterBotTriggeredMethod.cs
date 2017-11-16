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
        public static void ExecuteOn_Up_Through_Receive(XComponent.ChatManager.UserObject.PublishedMessage publishedMessage, XComponent.ChatterBot.UserObject.ChatterBot chatterBot, object object_InternalMember, Context context, IReceivePublishedMessageOnUpChatterBotSenderInterface sender)
        {
            if (publishedMessage.Message.Contains(chatterBot.Name))
            {
                TriggeredMethodContext.Instance.GetDefaultLogger().Info($"Message from {publishedMessage.User} in room {publishedMessage.Room} received");
                sender.Send(context, new SentMessage()
                {
                    Message = $"Hello {publishedMessage.User}!",
                    User = chatterBot.Name
                });
            }
        }

        public static void ExecuteOn_Up_Through_Init(XComponent.Common.Event.DefaultEvent defaultEvent, XComponent.ChatterBot.UserObject.ChatterBot chatterBot, object object_InternalMember, Context context, IInitDefaultEventOnUpChatterBotSenderInterface sender)
        {
            TriggeredMethodContext.Instance.GetDefaultLogger().Info("Chatter bot is up!");
            chatterBot.Name = "Marcos";
            TriggeredMethodContext.Instance.GetDefaultLogger().Info($"My name is {chatterBot.Name}");
        }
    }
}