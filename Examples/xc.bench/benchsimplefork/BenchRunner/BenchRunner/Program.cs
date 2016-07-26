using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using XCClientAPICommon.Client;
using XCClientAPICommon.ApiExtensions;
using XComponent.BenchSimpleFork.BenchSimpleForkApi;
using XComponent.BenchSimpleFork.UserObject;
using XComponent.BenchSimpleFork.BenchSimpleForkApi.BenchSimpleFork;

namespace BenchRunner
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

            int nbFork = 1000000;

            // Initialize the interfaces
            using (var myBenchSimpleForkApi = new ApiWrapper<BenchSimpleForkApi>())
            {
                ClientApiOptions clientApiOptions = new ClientApiOptions(); //fill this object to override default xcApi parameters

                if (myBenchSimpleForkApi.Init(myBenchSimpleForkApi.Api.DefaultXcApiFileName, clientApiOptions))
                {

                    myBenchSimpleForkApi.Api.BenchSimpleFork_Component.BenchResult_StateMachine.InstanceUpdated += BenchResult_StateMachine_InstanceUpdated;

                    BenchManagerInstance ep = myBenchSimpleForkApi.Api.BenchSimpleFork_Component.GetEntryPoint();
                    StartBench startBench = new StartBench() { NbInstances = nbFork };
                    myBenchSimpleForkApi.Api.BenchSimpleFork_Component.BenchManager_StateMachine.BenchReady_State.StartBench(ep.Context, startBench);



                    //CreateChild child = new CreateChild() { IsFirst = true };
                    //myBenchSimpleForkApi.Api.BenchSimpleFork_Component.BenchManager_StateMachine.BenchReady_State.CreateChild(ep.Context, child);
                    //child = new CreateChild();
                    //for (int i = 0; i < nbFork - 2; i++)
                    //{
                    //    myBenchSimpleForkApi.Api.BenchSimpleFork_Component.BenchManager_StateMachine.BenchReady_State.CreateChild(ep.Context, child);
                    //}
                    //child = new CreateChild() { IsLast = true };
                    //myBenchSimpleForkApi.Api.BenchSimpleFork_Component.BenchManager_StateMachine.BenchReady_State.CreateChild(ep.Context, child);

                    //myBenchSimpleForkApi.Api.BenchSimpleFork_Component.BenchResult_StateMachine.InstanceUpdated += BenchResult_StateMachine_InstanceUpdated;


                    Console.ReadLine();
                }
                else
                {
                    AnalyseReport(myBenchSimpleForkApi.Report);
                }
            }
        }

        private static void BenchResult_StateMachine_InstanceUpdated(BenchResultInstance obj)
        {
            Console.WriteLine("----------- Bench finished -----------");
            Console.WriteLine($"Instance received: {obj.PublicMember.NbInstances}");
            Console.WriteLine($"Total time: {obj.PublicMember.TotalTimeMilliseconds}ms");
        }
    }
}