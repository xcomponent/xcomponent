namespace XComponent.BenchSimpleFork.TriggeredMethod
{
	using System;
	using XComponent.Common.ApiContext;
	using XComponent.Common.Timeouts;
	using XComponent.BenchSimpleFork.Common.Senders;
	using XComponent.BenchSimpleFork.Common;
	using UserObject;

	public static class LoopBenchmarkTriggeredMethod
	{

		/// <summary>
		/// Executing triggeredMethod ExecuteOn_Benching_Through_TriggerLoopTransition
		/// </summary>
		public static void ExecuteOn_Benching_Through_TriggerLoopTransition(XComponent.BenchSimpleFork.UserObject.TriggerLoopTransition triggerLoopTransition, object object_PublicMember, object object_InternalMember, Context context, ITriggerLoopTransitionTriggerLoopTransitionOnBenchingLoopBenchmarkSenderInterface sender)
		{
			TriggeredMethodContext.Instance.IncrementInstances();
			if (triggerLoopTransition.IsLast) {
				TriggeredMethodContext.Instance.StopBench();
				sender.SendEvent(StdEnum.BenchManager, new BenchResult {
					TotalTimeMilliseconds = TriggeredMethodContext.Instance.TotalTimeMilliseconds,
					NbInstances = TriggeredMethodContext.Instance.NbInstances
				});
				sender.Finalize(context, new UserObject.Finalize());
			}
		}

		/// <summary>
		/// Executing triggeredMethod ExecuteOn_Benching_Through_StartLoopBench
		/// </summary>
		public static void ExecuteOn_Benching_Through_StartLoopBench(XComponent.BenchSimpleFork.UserObject.StartLoopBench startLoopBench, object object_PublicMember, object object_InternalMember, Context context, IStartLoopBenchStartLoopBenchOnBenchingLoopBenchmarkSenderInterface sender)
		{
			TriggerLoopTransition trigger = new TriggerLoopTransition();
			for (int i = 0; i < startLoopBench.NbInstances - 1; i++) {
				sender.TriggerLoopTransition(context, trigger);
			}
			trigger = new TriggerLoopTransition { IsLast = true };
			sender.TriggerLoopTransition(context, trigger);
			TriggeredMethodContext.Instance.StartBench();
		}
	}
}
