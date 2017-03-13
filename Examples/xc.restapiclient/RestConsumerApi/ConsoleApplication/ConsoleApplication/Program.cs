using System;
using System.Collections.Generic;
using System.Threading;
using XCClientAPICommon.Client;
using XCClientAPICommon.ApiExtensions;
using XComponent.RestConsumerApi.RestConsumerApiApi;
using XComponent.RestConsumerApi.RestConsumerApiApi.SwaggerPetstore;
using XComponent.SwaggerPetstore.UserObject;
using XComponent.SwaggerPetstore.UserObject.Models;


namespace ConsoleApplication
{
    class Program
    {
        static void AnalyseReport(InitReport report)
        {
            if (!string.IsNullOrEmpty(report.Message))
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
            using (var myRestConsumerApiApi = new ApiWrapper<RestConsumerApiApi>())
            {
                ClientApiOptions clientApiOptions = new ClientApiOptions();
                    //fill this object to override default xcApi parameters

                if (myRestConsumerApiApi.Init(myRestConsumerApiApi.Api.DefaultXcApiFileName, clientApiOptions))
                {
                    RunPetStore(myRestConsumerApiApi);
                }
                else
                {
                    AnalyseReport(myRestConsumerApiApi.Report);
                }
            }
        }

        private static void RunPetStore(ApiWrapper<RestConsumerApiApi> myRestConsumerApi)
        {
            var petName = "Juan";

            var addOperationDone = new ManualResetEvent(false);
            var getOperationDone = new ManualResetEvent(false);

            myRestConsumerApi.Api.SwaggerPetstore_Component.AddPetOperation_StateMachine.InstanceUpdated +=
                instance =>
                {
                    Console.WriteLine(string.Format("AddPetOperation current state: {0}", instance.StateName));

                    if (instance.StateCode ==
                        (int) AddPetOperation_StateMachine.AddPetOperationStateEnum.SuccessResponseReceived
                        ||
                        instance.StateCode ==
                        (int) AddPetOperation_StateMachine.AddPetOperationStateEnum.ErrorResponseReceived)
                    {
                        addOperationDone.Set();
                    }
                };

            myRestConsumerApi.Api.SwaggerPetstore_Component.GetPetByIdOperation_StateMachine.InstanceUpdated +=
                instance =>
                {
                    if (instance.StateCode ==
                        (int) GetPetByIdOperation_StateMachine.GetPetByIdOperationStateEnum.SuccessResponseReceived)
                    {
                        Console.WriteLine(string.Format("Found pet called {0}",
                            instance.PublicMember.OperationResult.Name));
                        getOperationDone.Set();
                    }
                    else if (instance.StateCode ==
                             (int) GetPetByIdOperation_StateMachine.GetPetByIdOperationStateEnum.ErrorResponseReceived)
                    {
                        Console.WriteLine(string.Format("An error occured: {0}", instance.PublicMember.Message));
                        getOperationDone.Set();
                    }
                };

            myRestConsumerApi.Api.SwaggerPetstore_Component.SwaggerPetstore_StateMachine.SendEvent(new AddPet()
            {
                body = new Pet(petName, new List<string>(), 1001)
            });

            Console.WriteLine(string.Format("Adding a new pet called {0}..", petName));
            addOperationDone.WaitOne();
            Console.WriteLine("Add operation done");

            Console.WriteLine("Asking for info about a pet..");
            myRestConsumerApi.Api.SwaggerPetstore_Component.SwaggerPetstore_StateMachine.SendEvent(new GetPetById()
            {
                petId = 1001
            });

            getOperationDone.WaitOne();
            Console.ReadLine();
        }
}

}