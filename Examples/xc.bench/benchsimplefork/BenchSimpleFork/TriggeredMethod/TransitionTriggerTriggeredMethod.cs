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


    public static class TransitionTriggerTriggeredMethod
    {

        /// <summary>
        /// Executing triggeredMethod ExecuteOn_Done_Through_TransitionTrigger
        /// </summary>
        public static void ExecuteOn_Done_Through_TransitionTrigger(XComponent.BenchSimpleFork.UserObject.TransitionTrigger transitionTrigger, object object_PublicMember, object object_InternalMember, RuntimeContext context, ITransitionTriggerTransitionTriggerOnDoneTransitionTriggerSenderInterface sender)
        {
            TriggeredMethodContext.Instance.StartBench();
            for (int i = 0; i < transitionTrigger.NbInstances; i++)
            {
                sender.SendEvent(StdEnum.TriggeringRuleBench, new UserObject.TriggerTransition { Id = i });
            }
        }
    }
}