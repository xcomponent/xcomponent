using System;
using System.Linq;
using XComponent.Authentication.Common;
using XComponent.Authentication.Common.Senders;
using XComponent.Common.ApiContext;
using XComponent.Common.Timeouts;
using XComponent.Shared;

namespace XComponent.Authentication.TriggeredMethod
{
    using XComponent.Authentication.Common.Senders;

    public class LoginStatusTriggeredMethod
    {

        public static void ExecuteOn_CheckingLogin_Through_CheckLogin(XComponent.Authentication.UserObject.CheckLogin checkLogin_TriggeringEvent, XComponent.Authentication.UserObject.CheckLogin checkLogin_PublicMember, object object_InternalMember, Context context, ICheckLoginCheckLoginOnCheckingLoginLoginStatusSenderInterface sender)
        {
            checkLogin_PublicMember.Login = checkLogin_TriggeringEvent.Login;
            checkLogin_PublicMember.Password = checkLogin_TriggeringEvent.Password;
            checkLogin_PublicMember.RequestId = checkLogin_TriggeringEvent.RequestId;

            User user = TriggeredMethodContext.Instance.Users.FirstOrDefault(e => e.Name == checkLogin_PublicMember.Login && e.Password == checkLogin_PublicMember.Password);

            if (user != null)
            {
                sender.LoginSuccess(context);
            }
            else
            {
                sender.LoginError(context);
            }
        }
    }
}