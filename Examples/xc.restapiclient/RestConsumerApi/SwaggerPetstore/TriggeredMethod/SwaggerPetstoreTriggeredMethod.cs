using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using XComponent.Common.ApiContext;
using XComponent.Common.Timeouts;
using XComponent.Shared;
using XComponent.SwaggerPetstore.Common;
using XComponent.SwaggerPetstore.Common.Senders;
using XComponent.SwaggerPetstore.TriggeredMethod.ServiceClient;
using XComponent.SwaggerPetstore.UserObject;
using XComponent.SwaggerPetstore.UserObject.Models;

namespace XComponent.SwaggerPetstore.TriggeredMethod
{
    public static class SwaggerPetstoreTriggeredMethod
    {
        public static void ExecuteOn_Up_Through_Init(XComponent.Common.Event.DefaultEvent defaultEvent, object object_PublicMember, object object_InternalMember, RuntimeContext context, IInitDefaultEventOnUpSwaggerPetstoreSenderInterface sender)
        {

        }

        public static void ExecuteOn_Up_Through_AddPet(XComponent.SwaggerPetstore.UserObject.AddPet addPet, object object_PublicMember, object object_InternalMember, RuntimeContext context, IAddPetAddPetOnUpSwaggerPetstoreSenderInterface sender)
        {
            sender.CreateAddPetHttpRequest(context, new AddPetOperation { Event = addPet });

        }

        public static void ExecuteOn_Up_Through_UpdatePet(XComponent.SwaggerPetstore.UserObject.UpdatePet updatePet, object object_PublicMember, object object_InternalMember, RuntimeContext context, IUpdatePetUpdatePetOnUpSwaggerPetstoreSenderInterface sender)
        {
            sender.CreateUpdatePetHttpRequest(context, new UpdatePetOperation { Event = updatePet });

        }

        public static void ExecuteOn_Up_Through_FindPetsByStatus(XComponent.SwaggerPetstore.UserObject.FindPetsByStatus findPetsByStatus, object object_PublicMember, object object_InternalMember, RuntimeContext context, IFindPetsByStatusFindPetsByStatusOnUpSwaggerPetstoreSenderInterface sender)
        {
            sender.CreateFindPetsByStatusHttpRequest(context, new FindPetsByStatusOperation { Event = findPetsByStatus });

        }

        public static void ExecuteOn_Up_Through_FindPetsByTags(XComponent.SwaggerPetstore.UserObject.FindPetsByTags findPetsByTags, object object_PublicMember, object object_InternalMember, RuntimeContext context, IFindPetsByTagsFindPetsByTagsOnUpSwaggerPetstoreSenderInterface sender)
        {
            sender.CreateFindPetsByTagsHttpRequest(context, new FindPetsByTagsOperation { Event = findPetsByTags });

        }

        public static void ExecuteOn_Up_Through_GetPetById(XComponent.SwaggerPetstore.UserObject.GetPetById getPetById, object object_PublicMember, object object_InternalMember, RuntimeContext context, IGetPetByIdGetPetByIdOnUpSwaggerPetstoreSenderInterface sender)
        {
            sender.CreateGetPetByIdHttpRequest(context, new GetPetByIdOperation { Event = getPetById });

        }

        public static void ExecuteOn_Up_Through_UpdatePetWithForm(XComponent.SwaggerPetstore.UserObject.UpdatePetWithForm updatePetWithForm, object object_PublicMember, object object_InternalMember, RuntimeContext context, IUpdatePetWithFormUpdatePetWithFormOnUpSwaggerPetstoreSenderInterface sender)
        {
            sender.CreateUpdatePetWithFormHttpRequest(context, new UpdatePetWithFormOperation { Event = updatePetWithForm });

        }

        public static void ExecuteOn_Up_Through_DeletePet(XComponent.SwaggerPetstore.UserObject.DeletePet deletePet, object object_PublicMember, object object_InternalMember, RuntimeContext context, IDeletePetDeletePetOnUpSwaggerPetstoreSenderInterface sender)
        {
            sender.CreateDeletePetHttpRequest(context, new DeletePetOperation { Event = deletePet });

        }

        public static void ExecuteOn_Up_Through_UploadFile(XComponent.SwaggerPetstore.UserObject.UploadFile uploadFile, object object_PublicMember, object object_InternalMember, RuntimeContext context, IUploadFileUploadFileOnUpSwaggerPetstoreSenderInterface sender)
        {
            sender.CreateUploadFileHttpRequest(context, new UploadFileOperation { Event = uploadFile });

        }

        public static void ExecuteOn_Up_Through_GetInventory(XComponent.SwaggerPetstore.UserObject.GetInventory getInventory, object object_PublicMember, object object_InternalMember, RuntimeContext context, IGetInventoryGetInventoryOnUpSwaggerPetstoreSenderInterface sender)
        {
            sender.CreateGetInventoryHttpRequest(context, new GetInventoryOperation { Event = getInventory });

        }

        public static void ExecuteOn_Up_Through_PlaceOrder(XComponent.SwaggerPetstore.UserObject.PlaceOrder placeOrder, object object_PublicMember, object object_InternalMember, RuntimeContext context, IPlaceOrderPlaceOrderOnUpSwaggerPetstoreSenderInterface sender)
        {
            sender.CreatePlaceOrderHttpRequest(context, new PlaceOrderOperation { Event = placeOrder });

        }

        public static void ExecuteOn_Up_Through_GetOrderById(XComponent.SwaggerPetstore.UserObject.GetOrderById getOrderById, object object_PublicMember, object object_InternalMember, RuntimeContext context, IGetOrderByIdGetOrderByIdOnUpSwaggerPetstoreSenderInterface sender)
        {
            sender.CreateGetOrderByIdHttpRequest(context, new GetOrderByIdOperation { Event = getOrderById });

        }

        public static void ExecuteOn_Up_Through_DeleteOrder(XComponent.SwaggerPetstore.UserObject.DeleteOrder deleteOrder, object object_PublicMember, object object_InternalMember, RuntimeContext context, IDeleteOrderDeleteOrderOnUpSwaggerPetstoreSenderInterface sender)
        {
            sender.CreateDeleteOrderHttpRequest(context, new DeleteOrderOperation { Event = deleteOrder });

        }

        public static void ExecuteOn_Up_Through_CreateUser(XComponent.SwaggerPetstore.UserObject.CreateUser createUser, object object_PublicMember, object object_InternalMember, RuntimeContext context, ICreateUserCreateUserOnUpSwaggerPetstoreSenderInterface sender)
        {
            sender.CreateCreateUserHttpRequest(context, new CreateUserOperation { Event = createUser });

        }

        public static void ExecuteOn_Up_Through_CreateUsersWithArrayInput(XComponent.SwaggerPetstore.UserObject.CreateUsersWithArrayInput createUsersWithArrayInput, object object_PublicMember, object object_InternalMember, RuntimeContext context, ICreateUsersWithArrayInputCreateUsersWithArrayInputOnUpSwaggerPetstoreSenderInterface sender)
        {
            sender.CreateCreateUsersWithArrayInputHttpRequest(context, new CreateUsersWithArrayInputOperation { Event = createUsersWithArrayInput });

        }

        public static void ExecuteOn_Up_Through_CreateUsersWithListInput(XComponent.SwaggerPetstore.UserObject.CreateUsersWithListInput createUsersWithListInput, object object_PublicMember, object object_InternalMember, RuntimeContext context, ICreateUsersWithListInputCreateUsersWithListInputOnUpSwaggerPetstoreSenderInterface sender)
        {
            sender.CreateCreateUsersWithListInputHttpRequest(context, new CreateUsersWithListInputOperation { Event = createUsersWithListInput });

        }

        public static void ExecuteOn_Up_Through_LoginUser(XComponent.SwaggerPetstore.UserObject.LoginUser loginUser, object object_PublicMember, object object_InternalMember, RuntimeContext context, ILoginUserLoginUserOnUpSwaggerPetstoreSenderInterface sender)
        {
            sender.CreateLoginUserHttpRequest(context, new LoginUserOperation { Event = loginUser });

        }

        public static void ExecuteOn_Up_Through_LogoutUser(XComponent.SwaggerPetstore.UserObject.LogoutUser logoutUser, object object_PublicMember, object object_InternalMember, RuntimeContext context, ILogoutUserLogoutUserOnUpSwaggerPetstoreSenderInterface sender)
        {
            sender.CreateLogoutUserHttpRequest(context, new LogoutUserOperation { Event = logoutUser });

        }

        public static void ExecuteOn_Up_Through_GetUserByName(XComponent.SwaggerPetstore.UserObject.GetUserByName getUserByName, object object_PublicMember, object object_InternalMember, RuntimeContext context, IGetUserByNameGetUserByNameOnUpSwaggerPetstoreSenderInterface sender)
        {
            sender.CreateGetUserByNameHttpRequest(context, new GetUserByNameOperation { Event = getUserByName });

        }

        public static void ExecuteOn_Up_Through_UpdateUser(XComponent.SwaggerPetstore.UserObject.UpdateUser updateUser, object object_PublicMember, object object_InternalMember, RuntimeContext context, IUpdateUserUpdateUserOnUpSwaggerPetstoreSenderInterface sender)
        {
            sender.CreateUpdateUserHttpRequest(context, new UpdateUserOperation { Event = updateUser });

        }

        public static void ExecuteOn_Up_Through_DeleteUser(XComponent.SwaggerPetstore.UserObject.DeleteUser deleteUser, object object_PublicMember, object object_InternalMember, RuntimeContext context, IDeleteUserDeleteUserOnUpSwaggerPetstoreSenderInterface sender)
        {
            sender.CreateDeleteUserHttpRequest(context, new DeleteUserOperation { Event = deleteUser });

        }
    }
}