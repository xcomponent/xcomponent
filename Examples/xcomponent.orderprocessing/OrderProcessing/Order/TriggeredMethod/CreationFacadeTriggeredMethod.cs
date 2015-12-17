namespace XComponent.Order.TriggeredMethod
{
	using System;
	using XComponent.Common.ApiContext;
	using XComponent.Common.Timeouts;
	using XComponent.Order.Common.Senders;
	using XComponent.Order.Common;


	public static class CreationFacadeTriggeredMethod
	{

		/// <summary>
		/// Executing triggeredMethod ExecuteOn_Created_Through_PublishOrderCreation
		/// </summary>
		public static void ExecuteOn_Created_Through_PublishOrderCreation(XComponent.Order.UserObject.OrderCreation orderCreation_TriggeringEvent, XComponent.Order.UserObject.OrderCreation orderCreation_PublicMember, object object_InternalMember, Context context, IPublishOrderCreationOrderCreationOnCreatedCreationFacadeSenderInterface sender)
		{
			XComponent.Common.Clone.XCClone.Clone(orderCreation_TriggeringEvent, orderCreation_PublicMember);
		}
	}
}
