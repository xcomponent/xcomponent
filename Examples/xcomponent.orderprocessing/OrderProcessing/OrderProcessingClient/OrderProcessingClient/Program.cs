using System;
using System.Threading;
using XCClientAPICommon.Client;
using XCClientAPICommon.ApiExtensions;
using XComponent.OrderProcessing.OrderProcessingApi;
using XComponent.Order.UserObject;
using XComponent.OrderProcessing.OrderProcessingApi.Order;
using XComponent.OrderProcessing.OrderProcessingApi.Trade;


namespace OrderProcessingClient
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
            using (var myOrderProcessingApi = new ApiWrapper<OrderProcessingApi>())
            {
                ClientApiOptions clientApiOptions = new ClientApiOptions(); //fill this object to override default xcApi parameters

                if (myOrderProcessingApi.Init(myOrderProcessingApi.Api.DefaultXcApiFileName, clientApiOptions))
                {
                    int orderId = 0;
                    using (var waitOrderCreation = new AutoResetEvent(false))
                    using (var waitOrderExecution = new AutoResetEvent(false))
                    {

                        // Subscribe to new order instances
                        myOrderProcessingApi.Api.Order_Component.Order_StateMachine.Pending_State.InstanceUpdated +=
                            instance =>
                            {
                                Console.WriteLine("New order pending for execution: " + DisplayOrder(instance));
                                orderId = instance.PublicMember.Id;
                                waitOrderCreation.Set();
                            };

                        myOrderProcessingApi.Api.Order_Component.Order_StateMachine.PartiallyExecuted_State
                            .InstanceUpdated +=
                            instance =>
                            {
                                Console.WriteLine("Order partially filled: " + DisplayOrder(instance));
                                waitOrderExecution.Set();
                            };

                        myOrderProcessingApi.Api.Order_Component.Order_StateMachine.Executed_State.InstanceUpdated +=
                            instance =>
                            {
                                Console.WriteLine("Order filled: " + DisplayOrder(instance));
                                waitOrderExecution.Set();
                            };

                        myOrderProcessingApi.Api.Trade_Component.Trade_StateMachine.WaitingForExecution_State
                            .InstanceUpdated +=
                            instance =>
                            {
                                Console.WriteLine("Trade waiting for execution: " + DisplayTrade(instance));
                            };

                        myOrderProcessingApi.Api.Trade_Component.Trade_StateMachine.Executed_State.InstanceUpdated +=
                            instance =>
                            {
                                Console.WriteLine("Trade executed : " + DisplayTrade(instance));
                            };

                        // Create an order
                        OrderInput orderInput = new OrderInput
                        {
                            AssetName = "INVIVOO",
                            Quantity = 1000
                        };

                        myOrderProcessingApi.Api.Order_Component.OrderProcessor_StateMachine.SendEvent(orderInput);
                        waitOrderCreation.WaitOne();
                        // Partially fill the order
                        ExecutionInput executionInput = new ExecutionInput
                        {
                            OrderId = orderId,
                            Quantity = 250,
                            Price = 102
                        };

                        myOrderProcessingApi.Api.Order_Component.Order_StateMachine.SendEvent(executionInput);
                        waitOrderExecution.WaitOne();

                        // Fill the order
                        executionInput = new ExecutionInput
                        {
                            OrderId = orderId,
                            Quantity = 750,
                            Price = 101.5,
                        };
                        myOrderProcessingApi.Api.Order_Component.Order_StateMachine.SendEvent(executionInput);
                        waitOrderExecution.WaitOne();

                        Console.ReadKey();
                    }
                }
                else
                {
                    AnalyseReport(myOrderProcessingApi.Report);
                }
            }
        }

        private static string DisplayTrade(TradeInstance instance)
        {
            return $"Id {instance.PublicMember.Id}, OrderId {instance.PublicMember.OrderId}, Quantity {instance.PublicMember.Quantity}, Price {instance.PublicMember.Price}";
        }

        private static string DisplayOrder(OrderInstance instance)
        {
            return $"Id {instance.PublicMember.Id}, Asset {instance.PublicMember.AssetName}, Quantity {instance.PublicMember.Quantity}, Remaining {instance.PublicMember.RemainingQuantity}";
        }
    }
}