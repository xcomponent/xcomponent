namespace XComponent.SwaggerPetstore.TriggeredMethod
{
	using XComponent.SwaggerPetstore.UserObject.Models;
	using XComponent.SwaggerPetstore.UserObject;
	using XComponent.SwaggerPetstore.TriggeredMethod.ServiceClient;
	using System.Collections.Generic;
	using System.Threading.Tasks;
	using System;
	using XComponent.Common.ApiContext;
	using XComponent.Common.Timeouts;
	using XComponent.SwaggerPetstore.Common.Senders;
	using XComponent.SwaggerPetstore.Common;


	public static class SwaggerPetstoreTriggeredMethod
	{

		/// <summary>
		/// Executing triggeredMethod ExecuteOn_Up_Through_Init
		/// </summary>
		public static void ExecuteOn_Up_Through_Init(XComponent.Common.Event.DefaultEvent defaultEvent, object object_PublicMember, object object_InternalMember, Context context, IInitDefaultEventOnUpSwaggerPetstoreSenderInterface sender)
		{

		}

		/// <summary>
		/// Executing triggeredMethod ExecuteOn_Up_Through_AddPet
		/// </summary>
		public static void ExecuteOn_Up_Through_AddPet(XComponent.SwaggerPetstore.UserObject.AddPet addPet, object object_PublicMember, object object_InternalMember, Context context, IAddPetAddPetOnUpSwaggerPetstoreSenderInterface sender)
		{
			sender.CreateAddPetHttpRequest(context, new AddPetOperation { Event = addPet });

		}

		/// <summary>
		/// Executing triggeredMethod ExecuteOn_Up_Through_GetPetById
		/// </summary>
		public static void ExecuteOn_Up_Through_GetPetById(XComponent.SwaggerPetstore.UserObject.GetPetById getPetById, object object_PublicMember, object object_InternalMember, Context context, IGetPetByIdGetPetByIdOnUpSwaggerPetstoreSenderInterface sender)
		{
			sender.CreateGetPetByIdHttpRequest(context, new GetPetByIdOperation { Event = getPetById });

		}
	}
}
