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

    public static class LoopTriggeringRuleBenchTriggeredMethod
    {

        /// <summary>
        /// Executing triggeredMethod ExecuteOn_Benching_Through_TriggerTransition
        /// </summary>
        public static void ExecuteOn_Benching_Through_TriggerTransition(XComponent.BenchSimpleFork.UserObject.TriggerTransition triggerTransition, object object_PublicMember, XComponent.BenchSimpleFork.UserObject.LoopTriggeringRuleBench loopTriggeringRuleBench, RuntimeContext context, ITriggerTransitionTriggerTransitionOnBenchingLoopTriggeringRuleBenchSenderInterface sender)
        {
            TriggeredMethodContext.Instance.IncrementInstances();
            if (triggerTransition.IsLast)
            {
                TriggeredMethodContext.Instance.StopBench();
                sender.SendEvent(StdEnum.BenchManager, new BenchResult
                {
                    TotalTimeMilliseconds = TriggeredMethodContext.Instance.TotalTimeMilliseconds,
                    NbInstances = TriggeredMethodContext.Instance.NbInstances
                });
                sender.Finalize_LoopTriggeringRuleBench(context, new UserObject.Finalize());
            }
        }

        /// <summary>
        /// Executing triggeredMethod ExecuteOn_Benching_Through_StartLoopRuleBench
        /// </summary>
        public static void ExecuteOn_Benching_Through_StartLoopRuleBench(XComponent.BenchSimpleFork.UserObject.StartLoopRuleBench startLoopRuleBench, object object_PublicMember, XComponent.BenchSimpleFork.UserObject.LoopTriggeringRuleBench loopTriggeringRuleBench, RuntimeContext context, IStartLoopRuleBenchStartLoopRuleBenchOnBenchingLoopTriggeringRuleBenchSenderInterface sender)
        {
            loopTriggeringRuleBench.Id = new Random().Next();
            TriggerTransition trigger = new TriggerTransition { Id = loopTriggeringRuleBench.Id };
            for (int i = 0; i < startLoopRuleBench.NbInstances - 1; i++)
            {
                sender.SendEvent(StdEnum.LoopTriggeringRuleBench, trigger);
            }
            trigger = new TriggerTransition
            {
                Id = loopTriggeringRuleBench.Id,
                IsLast = true
            };
            sender.SendEvent(StdEnum.LoopTriggeringRuleBench, trigger);
            TriggeredMethodContext.Instance.StartBench();
        }
    }
}