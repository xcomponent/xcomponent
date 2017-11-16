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
        public static void InitializePublicMember(XComponent.HistoryManager.UserObject.PublishedHistory publishedHistory_ParentPublicMember, object object_ParentInternalMember, XComponent.HistoryManager.UserObject.PublishedHistory publishedHistory_PublicMember, object object_InternalMember)
        {
            XCClone.Clone(publishedHistory_ParentPublicMember, publishedHistory_PublicMember);
        }
    }
}