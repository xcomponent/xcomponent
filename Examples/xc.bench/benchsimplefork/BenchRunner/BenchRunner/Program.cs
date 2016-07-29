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

            int nbFork = 100000;

            // Initialize the interfaces
            using (var myBenchSimpleForkApi = new ApiWrapper<BenchSimpleForkApi>())
            {
                ClientApiOptions clientApiOptions = new ClientApiOptions(); //fill this object to override default xcApi parameters

                if (myBenchSimpleForkApi.Init(myBenchSimpleForkApi.Api.DefaultXcApiFileName, clientApiOptions))
                {

                    Queue<Action> benchs = new Queue<Action>();

                    myBenchSimpleForkApi.Api.BenchSimpleFork_Component.BenchResult_StateMachine.InstanceUpdated +=
                        benchResultInstance =>
                        {
                            Console.WriteLine("----------- Bench finished -----------");
                            Console.WriteLine($"Instances received: {benchResultInstance.PublicMember.NbInstances}");
                            Console.WriteLine($"Total time: {benchResultInstance.PublicMember.TotalTimeMilliseconds}ms");
                            if (benchs.Count > 0)
                                benchs.Dequeue()();
                        };

                    BenchManagerInstance ep = myBenchSimpleForkApi.Api.BenchSimpleFork_Component.GetEntryPoint();

                    benchs.Enqueue(() =>
                    {
                        Console.WriteLine("Starting simple fork bench...");
                        StartSimpleForkBench startBench = new StartSimpleForkBench() { NbInstances = nbFork };
                        myBenchSimpleForkApi.Api.BenchSimpleFork_Component.BenchManager_StateMachine.BenchReady_State.StartSimpleForkBench(ep.Context, startBench);
                    }
                    );

                    benchs.Enqueue(() =>
                    {
                        Console.WriteLine("Starting loop fork bench...");
                        StartLoopBench startLoopBench = new StartLoopBench() { NbInstances = nbFork };
                        myBenchSimpleForkApi.Api.BenchSimpleFork_Component.BenchManager_StateMachine.BenchReady_State.StartLoopBench(ep.Context, startLoopBench);
                    }
                    );

                    benchs.Enqueue(() =>
                    {
                        Console.WriteLine("Starting triggering rules loop bench...");
                        StartLoopRuleBench startloopruleBench = new StartLoopRuleBench() { NbInstances = nbFork };
                        myBenchSimpleForkApi.Api.BenchSimpleFork_Component.BenchManager_StateMachine.BenchReady_State.StartLoopRuleBench(ep.Context, startloopruleBench);
                    }
                    );

                    benchs.Enqueue(() =>
                    {
                        Console.WriteLine("Starting triggering rules bench...");
                        StartTriggeringRulesBench startTriggeringBench = new StartTriggeringRulesBench() { NbInstances = nbFork };
                        myBenchSimpleForkApi.Api.BenchSimpleFork_Component.BenchManager_StateMachine.BenchReady_State.StartTriggeringRulesBench(ep.Context, startTriggeringBench);
                    }
                    );


                    benchs.Dequeue()();


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
    }
}