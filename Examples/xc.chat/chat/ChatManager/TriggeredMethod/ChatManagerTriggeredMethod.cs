using System;
using XComponent.ChatManager.Common;
using XComponent.ChatManager.Common.Senders;
using XComponent.ChatManager.UserObject;
using XComponent.Common.ApiContext;
using XComponent.Common.Timeouts;
using XComponent.Shared;

namespace XComponent.ChatManager.TriggeredMethod
{
    public static class ChatManagerTriggeredMethod
    {
        public static void ExecuteOn_Up_Through_Init(XComponent.Common.Event.DefaultEvent defaultEvent, object object_PublicMember, object object_InternalMember, RuntimeContext context, IInitDefaultEventOnUpChatManagerSenderInterface sender)
        {
            sender.CreateRoom(context, new CreateChatroom() { Name = "general" });
        }
    }
}