# Authentication: project details

This document is not a step by step tutorial. If you want a step by step tutorial, you can refer to the `Hello World` project. 
The objective of this tutorial is to explain how to use `TriggeredMethodContext` and file resources.

## Overview

In this project, there are 3 elements:
* An `Authentication` component
* An Api: `authenticationserviceApi`
* A console application

## Authentication component

The `Authentication` component loads a list of users (login and password) from an xml file. It receives requests to check if login/password couple is valid or not.

![Authentication component](images/Authentication_Image.png)

When the component starts, the `OnComponentInitialized()` method of the class `TriggeredMethodContext` is called by the XComponent runtime.
On this method, you can initialize your component. On this project, we load a file which is stored as a resource of the component.

> Note: To add a file resource in XComponent, you can use the following screen: 
> ![Authentication component](images/fileresource.png)

XComponent provides a useful Api to load files resources of a component. This Api is: `ComponentManager.Resources`.

The code below is the implementation of the `OnComponentInitialized` method:
```cs
        public void OnComponentInitialized()
        {
            XmlDocument xmlDocument = new XmlDocument();
            xmlDocument.LoadXml(componentManager.Resources.GetResourceAllText("users.xml"));

            XmlNodeList usersList = xmlDocument.SelectNodes("//user");
            List<User> users = new List<User>();
            foreach (XmlNode userNode in usersList)
            {
                User user = new User();
                user.Name = userNode.SelectSingleNode("name").InnerXml;
                user.Password = userNode.SelectSingleNode("password").InnerXml;
                users.Add(user);
            }

            Users = users;
        }
```

The `TriggeredMethodContext` class can be used to store data shared by several state machines. Indeed, `TriggeredMethodContext` is a singleton.

> Note: When you decide to store some data in the `TriggeredMethodContext`, you should managed concurrency by yourself.

You can easily extend `ICustomTriggeredMethodContext` interface by adding your own properties. In this project, we have extended the interface this way:
```cs
    public partial interface ICustomTriggeredMethodContext : ITriggeredMethodContext
    {
        IEnumerable<User> Users { get; }
    }
```

The implementation of the `ICustomTriggeredMethodContext` is the `TriggeredMethodContext` class.

Once you have added your own properties on the `TriggeredMethodContext`, you can easily call them from any triggered method.
```cs
    //Pseudo code
    var value = TriggeredMethodContext.Instance.MyProperty;
```

### Authentication state machine
The authentication state machine contains the entry point of the component. 
On the `Initializing` state we check if the list of user is not empty. If the list is not empty, the state machine goes to the `Up` state.

### LoginStatus state machine
This state machine receives login/password requests. If the login/password couple is valid, the state machine goes to state `LoginSucess` otherwise the state machine goes to state `LoginError`.


## Authentication Console Application
The console application sends 2 events. The first one to test login failure and the second one to test login success.

```cs		
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
                                Login = "Luc.Skywalker",
                                Password = "noforce"
                            };
                            Console.WriteLine("Authenticate as {0} with password: {1}", checkLogin.Login, checkLogin.Password);
                            myauthenticationserviceApi.Api.Authentication_Component.Authentication_StateMachine.SendEvent(entryPoint.Context, checkLogin);
                            resetEvent.WaitOne();

                            checkLogin = new CheckLogin()
                            {
                                RequestId = requestId1,
                                Login = "Luc.Skywalker",
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
 ```
 
 > Note: You may notice the usage of `AutoResetEvent`. Because, all events are received asynchronously in XComponent, you should use this kind of Api the main thread with the messages thread of the XComponent's Api.

* Run your console application. You should end up with the following output: 

![consoleapp output](images/consoleoutput.png)

## Questions?

If you have any questions about this sample, please [create a Github issue for us](https://github.com/xcomponent/issues)!
