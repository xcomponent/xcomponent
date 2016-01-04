using System;
using XCClientAPICommon.ApiExtensions;
using XCClientAPICommon.Client;
using XComponent.helloworld.helloworldApi;
using XComponent.HelloWorld.UserObject;

namespace HelloWorldClientApplication
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

        private static string GetName()
        {
            Console.WriteLine("Enter your name / or enter to exit");
            return Console.ReadLine();
        }

        static void Main(string[] args)
        {
            // Initialize the interfaces
            using (var myhelloworldApi = new ApiWrapper<helloworldApi>())
            {
                ClientApiOptions clientApiOptions = new ClientApiOptions(); //fill this object to override default xcApi parameters

                myhelloworldApi.Api.HelloWorld_Component.HelloResponse_StateMachine.InstanceUpdated += instance => Console.WriteLine(instance.PublicMember.Text);

                if (myhelloworldApi.Init(myhelloworldApi.Api.DefaultXcApiFileName, clientApiOptions))
                {
                    var context = myhelloworldApi.Api.HelloWorld_Component.GetEntryPoint().Context;

                    var name = GetName();
                    while (!string.IsNullOrWhiteSpace(name))
                    {
                        myhelloworldApi.Api.HelloWorld_Component.HelloWorldManager_StateMachine.EntryPoint_State.SayHello(context, new SayHello { Name = name });
                        name = GetName();
                    }
                }
                else
                {
                    AnalyseReport(myhelloworldApi.Report);
                }
            }            
        }
    }
}