using System;
using XComponent.BenchSimpleFork.Common;
using XComponent.BenchSimpleFork.Common.Senders;
using XComponent.Common.ApiContext;
using XComponent.Common.Timeouts;

namespace XComponent.BenchSimpleFork.TriggeredMethod
{
    using System;
    using XComponent.Common.ApiContext;
    using XComponent.Common.Timeouts;
    using XComponent.BenchSimpleFork.Common.Senders;
    using XComponent.BenchSimpleFork.Common;
    using UserObject;

    public static class BenchManagerTriggeredMethod
    {

        /// <summary>
        /// Executing triggeredMethod ExecuteOn_BenchReady_Through_StartBench
        /// </summary>
        public static void ExecuteOn_BenchReady_Through_StartSimpleForkBench(XComponent.BenchSimpleFork.UserObject.StartSimpleForkBench startSimpleForkBench, object object_PublicMember, object object_InternalMember, Context context, IStartSimpleForkBenchStartSimpleForkBenchOnBenchReadyBenchManagerSenderInterface sender)
        {
            CreateChild child;


            //child = new CreateChild { IsFirst = true };
            //sender.CreateChild(context, child);

            child = new CreateChild();
            for (int i = 0; i < startSimpleForkBench.NbInstances - 1; i++)
            {
                sender.CreateChild(context, child);
            }
            child = new CreateChild { IsLast = true };
            sender.CreateChild(context, child);
            TriggeredMethodContext.Instance.StartBench();
        }

        /// <summary>
        /// Executing triggeredMethod ExecuteOn_BenchReady_Through_StartTriggeringRulesBench
        /// </summary>
        public static void ExecuteOn_BenchReady_Through_StartTriggeringRulesBench(XComponent.BenchSimpleFork.UserObject.StartTriggeringRulesBench startTriggeringRulesBench, object object_PublicMember, object object_InternalMember, Context context, IStartTriggeringRulesBenchStartTriggeringRulesBenchOnBenchReadyBenchManagerSenderInterface sender)
        {
            CreateInstance createInstance;
            for (int i = 0; i < startTriggeringRulesBench.NbInstances - 1; i++)
            {
                createInstance = new CreateInstance { Id = i };
                sender.CreateInstance(context, createInstance);
            }
            createInstance = new CreateInstance { Id = startTriggeringRulesBench.NbInstances - 1 };
            createInstance.IsLast = true;
            sender.CreateInstance(context, createInstance);
        }
    }
}