namespace XComponent.DealCapture.TriggeredMethod
{
	using System;

	using XComponent.DealCapture.Common.Senders;
	using XComponent.DealCapture.Common;


	// var logger1 =  ComponentLoggerManager<LogKeyEnum>.GetComponentLogger(LogKeyEnum.Key1, ComponentHelper.COMPONENT_NAME);
	// 
	// var logger2 =  ComponentLoggerManager<LogKeyEnum>.GetComponentLogger(LogKeyEnum.Key2, ComponentHelper.COMPONENT_NAME);
	// logger1.Trace("Message");
	// logger2.Error(new Exception("Error message..."));
	// 
	// if(logger1.IsTrace)
	// {
	//     logger1.Trace("Message");
	// }
	// 
	// if(logger2.IsError)
	// {
	//     logger2.Error(new Exception("Error message..."));
	// }
	// 
	// 
	// EXAMPLE OF INTERNAL INTERFACE USE
	// 
	// One can send an event to the state machine.
	// sender.SendEvent(new MyEvent());
	// 
	// One can try and trigger a transition in the state machine by giving the current context.
	// sender.MyTransition(context);
	// 
	public class GetInstrumentSnapshotTriggeredMethod : AbstractTriggeredMethod
	{

		/// <summary>
		/// Executing triggeredMethod ExecuteOn_SnapshotAvailable_Through_GetSnapshot
		/// </summary>

	}
}
