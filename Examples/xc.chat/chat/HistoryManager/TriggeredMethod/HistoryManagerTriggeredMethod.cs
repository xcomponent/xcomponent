using System;
using System.Collections.Generic;
using System.Linq;
using XComponent.ChatManager.UserObject;
using XComponent.Common.ApiContext;
using XComponent.Common.Timeouts;
using XComponent.HistoryManager.Common;
using XComponent.HistoryManager.Common.Senders;
using XComponent.HistoryManager.UserObject;
using XComponent.Shared;

namespace XComponent.HistoryManager.TriggeredMethod
{
    public static class HistoryManagerTriggeredMethod
    {
        public static void ExecuteOn_Up_Through_MessageReceived(XComponent.ChatManager.UserObject.PublishedMessage publishedMessage, XComponent.HistoryManager.UserObject.PublishedHistory publishedHistory, object object_InternalMember, Context context, IMessageReceivedPublishedMessageOnUpHistoryManagerSenderInterface sender)
        {
            // Notice: No concurrency here, thanks to our bus + akka core.
            publishedHistory.Messages.Add(publishedMessage);
        }

        public static void ExecuteOn_Up_Through_Up(XComponent.Common.Event.DefaultEvent defaultEvent, XComponent.HistoryManager.UserObject.PublishedHistory publishedHistory, object object_InternalMember, Context context, IUpDefaultEventOnUpHistoryManagerSenderInterface sender)
        {
            TriggeredMethodContext.Instance.GetDefaultLogger().Info("History manager started!");
        }

        public static void ExecuteOn_Up_Through_HistoryRequestReceived(XComponent.HistoryManager.UserObject.HistoryRequest historyRequest, XComponent.HistoryManager.UserObject.PublishedHistory publishedHistory, object object_InternalMember, Context context, IHistoryRequestReceivedHistoryRequestOnUpHistoryManagerSenderInterface sender)
        {
            TriggeredMethodContext.Instance.GetDefaultLogger().Info($"Request received for messages in room {historyRequest.RoomName}...");
            TriggeredMethodContext.Instance.GetDefaultLogger().Info($"Sending response in private topic {historyRequest.ResponseTopic}...");

            sender.PublishRequestResponse(context,
                new PublishedHistory()
                {
                    Messages = new List<PublishedMessage>(
                        publishedHistory
                            .Messages
                            .Where(message => message.Room == historyRequest.RoomName))
                },
                historyRequest.ResponseTopic);
        }
    }
}