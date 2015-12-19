using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using System.Text;
using System.Threading;
using XCClientAPICommon.Client;
using XCClientAPICommon.ApiExtensions;
using XComponent.authenticationservice.authenticationserviceApi;
using XComponent.authenticationservice.authenticationserviceApi.Authentication;
using XComponent.Authentication.UserObject;
using XComponent.Common.ApiHelper;


namespace AuthenticationConsoleApp
{
	class Program
	{
		static void AnalyseReport(InitReport report)
		{
            if( !string.IsNullOrEmpty(report.Message) )
            {
      	    Console.WriteLine("Init failed : {0}", report.Message);
            }
			foreach (var componentName in report.ComponentsInitSucceeded)
			{
				Console.WriteLine("Init succeeded : {0}", componentName);
			}
			foreach (var componentName in report.ComponentsInitFailed)
			{
				Console.WriteLine("Init failed : {0}", componentName);
			}
		}

		static void Main(string[] args)
		{
			// Initialize the interfaces
			 using(var myauthenticationserviceApi = new ApiWrapper<authenticationserviceApi>())
			 {
				ClientApiOptions clientApiOptions = new ClientApiOptions(); //fill this object to override default xcApi parameters
 
				if(myauthenticationserviceApi.Init(myauthenticationserviceApi.Api.DefaultXcApiFileName, clientApiOptions))
				{

                    var entryPoint = myauthenticationserviceApi.Api.Authentication_Component.GetEntryPoint();
				    if (entryPoint.StateCode == (int)Authentication_StateMachine.AuthenticationStateEnum.Up)
				    {
                        string requestId1 = Guid.NewGuid().ToString();
                        string requestId2 = Guid.NewGuid().ToString();
				        using (AutoResetEvent resetEvent = new AutoResetEvent(false))
				        {
                            myauthenticationserviceApi.Api.Authentication_Component.LoginStatus_StateMachine.LoginError_State.InstanceUpdated +=
                              delegate (LoginStatusInstance instance)
                              {
                                  if (instance.PublicMember.RequestId == requestId1 ||
                                      instance.PublicMember.RequestId == requestId2)
                                  {
                                      Console.WriteLine("Authentication failed");
                                      resetEvent.Set();
                                  }
                              };

                            myauthenticationserviceApi.Api.Authentication_Component.LoginStatus_StateMachine.LoginSuccess_State.InstanceUpdated +=
                               delegate (LoginStatusInstance instance)
                               {
                                   if (instance.PublicMember.RequestId == requestId1 ||
                                       instance.PublicMember.RequestId == requestId2)
                                   {
                                       Console.WriteLine("Authentication succeeded");
                                       resetEvent.Set();
                                   }
                               };

                            var checkLogin = new CheckLogin()
                            {
                                RequestId = requestId1,
                                Login = "Luke.Skywalker",
                                Password = "noforce"
                            };
                            Console.WriteLine("Authenticate as {0} with password: {1}", checkLogin.Login, checkLogin.Password);
                            myauthenticationserviceApi.Api.Authentication_Component.Authentication_StateMachine.SendEvent(entryPoint.Context, checkLogin);
                            resetEvent.WaitOne();

                            checkLogin = new CheckLogin()
                            {
                                RequestId = requestId1,
                                Login = "Luke.Skywalker",
                                Password = "force"
                            };

                            Console.WriteLine("Authenticate as {0} with password: {1}", checkLogin.Login, checkLogin.Password);
                            myauthenticationserviceApi.Api.Authentication_Component.Authentication_StateMachine.SendEvent(entryPoint.Context, checkLogin);

                            resetEvent.WaitOne();
                        }
                    }
				    else
				    {
				        Console.WriteLine("Authentication service is not up.");
				    }



                }
				else			
				{
					AnalyseReport(myauthenticationserviceApi.Report);
				}
			}

		    Console.WriteLine("");
            Console.WriteLine("Type any key to leave...");
		    Console.ReadKey();
		}
	}
}