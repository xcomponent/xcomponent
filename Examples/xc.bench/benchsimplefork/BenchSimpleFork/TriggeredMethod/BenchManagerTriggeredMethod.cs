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
		public static void ExecuteOn_BenchReady_Through_StartBench(XComponent.BenchSimpleFork.UserObject.StartBench startBench, object object_PublicMember, object object_InternalMember, Context context, IStartBenchStartBenchOnBenchReadyBenchManagerSenderInterface sender)
		{
			CreateChild child = new CreateChild { IsFirst = true };
			sender.CreateChild(context, child);
			child = new CreateChild();
			for (int i = 0; i < startBench.NbInstances - 2; i++) {
				sender.CreateChild(context, child);
			}
			child = new CreateChild { IsLast = true };
			sender.CreateChild(context, child);
		}
	}
}
