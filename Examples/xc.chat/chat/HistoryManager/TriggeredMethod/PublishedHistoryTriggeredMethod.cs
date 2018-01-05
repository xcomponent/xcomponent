using System;
using XComponent.Common.ApiContext;
using XComponent.Common.Timeouts;
using XComponent.HistoryManager.Common;
using XComponent.HistoryManager.Common.Senders;
using XComponent.Shared;

namespace XComponent.HistoryManager.TriggeredMethod
{
    public static class PublishedHistoryTriggeredMethod
    {
        public static void ExecuteOn_Published_Through_PublishRequestResponse(XComponent.HistoryManager.UserObject.HistoryResponse historyResponse, XComponent.HistoryManager.UserObject.PublishedHistory publishedHistory, XComponent.HistoryManager.UserObject.PublishedHistoryInternalMember publishedHistoryInternalMember, Context context, IPublishRequestResponseHistoryResponseOnPublishedPublishedHistorySenderInterface sender)
        {
            XCClone.Clone(historyResponse.PublishedHistory, publishedHistory);
            context.PrivateTopic = historyResponse.ResponseTopic;
        }
    }
}