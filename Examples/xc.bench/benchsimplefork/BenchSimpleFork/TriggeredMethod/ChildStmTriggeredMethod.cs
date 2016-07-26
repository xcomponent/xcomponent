namespace XComponent.BenchSimpleFork.TriggeredMethod
{
	using System;
	using XComponent.Common.ApiContext;
	using XComponent.Common.Timeouts;
	using XComponent.BenchSimpleFork.Common.Senders;
	using XComponent.BenchSimpleFork.Common;
	using UserObject;

	public static class ChildStmTriggeredMethod
	{

		/// <summary>
		/// Executing triggeredMethod ExecuteOn_Done_Through_CreateChild
		/// </summary>
		public static void ExecuteOn_Done_Through_CreateChild(XComponent.BenchSimpleFork.UserObject.CreateChild createChild, object object_PublicMember, object object_InternalMember, Context context, ICreateChildCreateChildOnDoneChildStmSenderInterface sender)
		{
			if (createChild.IsFirst) {
				TriggeredMethodContext.Instance.StartBench();
			}
			TriggeredMethodContext.Instance.IncrementInstances();
			if (createChild.IsLast) {
				TriggeredMethodContext.Instance.StopBench();
				sender.SendEvent(StdEnum.BenchManager, new BenchResult {
					TotalTimeMilliseconds = TriggeredMethodContext.Instance.TotalTimeMilliseconds,
					NbInstances = TriggeredMethodContext.Instance.NbInstances
				});
			}
		}
	}
}
