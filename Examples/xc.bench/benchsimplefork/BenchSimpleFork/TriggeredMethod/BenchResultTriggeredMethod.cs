using System;
using XComponent.BenchSimpleFork.Common;
using XComponent.BenchSimpleFork.Common.Senders;
using XComponent.Common.ApiContext;
using XComponent.Common.Timeouts;
using XComponent.Shared;

namespace XComponent.BenchSimpleFork.TriggeredMethod
{
    using System;
    using XComponent.Common.ApiContext;
    using XComponent.Common.Timeouts;
    using XComponent.BenchSimpleFork.Common.Senders;
    using XComponent.BenchSimpleFork.Common;


    public static class BenchResultTriggeredMethod
    {

        /// <summary>
        /// Executing triggeredMethod ExecuteOn_Published_Through_PublishResult
        /// </summary>
        public static void ExecuteOn_Published_Through_PublishResult(XComponent.BenchSimpleFork.UserObject.BenchResult benchResult_TriggeringEvent, XComponent.BenchSimpleFork.UserObject.BenchResult benchResult_PublicMember, object object_InternalMember, RuntimeContext context, IPublishResultBenchResultOnPublishedBenchResultSenderInterface sender)
        {
            // Uncomment the following line if you want to copy benchResult_TriggeringEvent properties values into benchResult_PublicMember
            XComponent.Shared.XCClone.Clone(benchResult_TriggeringEvent, benchResult_PublicMember);
        }
    }
}