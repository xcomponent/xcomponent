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
    using UserObject;

    public static class TriggeringRuleBenchTriggeredMethod
    {

        /// <summary>
        /// Executing triggeredMethod ExecuteOn_Done_Through_TriggerTransition
        /// </summary>
        public static void ExecuteOn_Done_Through_TriggerTransition(XComponent.BenchSimpleFork.UserObject.TriggerTransition triggerTransition, object object_PublicMember, XComponent.BenchSimpleFork.UserObject.TriggeringRuleBench triggeringRuleBench, Context context, ITriggerTransitionTriggerTransitionOnDoneTriggeringRuleBenchSenderInterface sender)
        {
            TriggeredMethodContext.Instance.IncrementInstances();
            if (triggeringRuleBench.IsLast)
            {
                TriggeredMethodContext.Instance.StopBench();
                sender.SendEvent(StdEnum.BenchManager, new BenchResult
                {
                    TotalTimeMilliseconds = TriggeredMethodContext.Instance.TotalTimeMilliseconds,
                    NbInstances = TriggeredMethodContext.Instance.NbInstances
                });
            }
        }

        /// <summary>
        /// Executing triggeredMethod ExecuteOn_Benching_Through_CreateInstance
        /// </summary>
        public static void ExecuteOn_Benching_Through_CreateInstance(XComponent.BenchSimpleFork.UserObject.CreateInstance createInstance, object object_PublicMember, XComponent.BenchSimpleFork.UserObject.TriggeringRuleBench triggeringRuleBench, Context context, ICreateInstanceCreateInstanceOnBenchingTriggeringRuleBenchSenderInterface sender)
        {
            triggeringRuleBench.Id = createInstance.Id;
            triggeringRuleBench.IsLast = createInstance.IsLast;
            if (triggeringRuleBench.IsLast)
            {
                sender.TransitionTrigger(context, new TransitionTrigger { NbInstances = triggeringRuleBench.Id + 1 });
            }
        }
    }
}