using System;
using XComponent.ChatterBot.Common;
using XComponent.ChatterBot.Common.Senders;
using XComponent.Common.ApiContext;
using XComponent.Common.Timeouts;
using XComponent.Shared;

namespace XComponent.ChatterBot.TriggeredMethod
{
    public static class SentMessageTriggeredMethod
    {
        public static void ExecuteOn_Published_Through_Send(XComponent.ChatManager.UserObject.SentMessage sentMessage, XComponent.ChatManager.UserObject.SentMessage sentMessage_PublicMember, object object_InternalMember, Context context, ISendSentMessageOnPublishedSentMessageSenderInterface sender)
        {
            XCClone.Clone(sentMessage, sentMessage_PublicMember);
        }
    }
}