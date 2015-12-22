using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using CommandLine;
using CommandLine.Text;
using ServiceStack.DataAnnotations;
using XCClientAPICommon.Client;
using XCClientAPICommon.ApiExtensions;
using XComponent.XChristmas.XChristmasApi;
using XComponent.SlackProxy.UserObject;


namespace XChristmasApp
{
	class Program
	{
        class CmdLineOptions
        {
            [Option('w', "webhook", Required = true, HelpText = "Slack Webhook URL")]
            public string WebHookUrl { get; set; }

            [Option('c', "channel", Required = true, HelpText = "Slack Channel")]
            public string Channel { get; set; }

            [Option('u', "user", Required = true, HelpText = "Slack User")]
            public string User { get; set; }

            [HelpOption]
            public string GetUsage()
            {
                return HelpText.AutoBuild(this,
                  (HelpText current) => HelpText.DefaultParsingErrorsHandler(this, current));
            }
        }


        private static void Main(string[] args)
	    {
            CmdLineOptions cmdLineOptions = new CmdLineOptions();
            var commandLineParser = new Parser();
            if (!commandLineParser.ParseArguments(args, cmdLineOptions))
            {
                Console.WriteLine(cmdLineOptions.GetUsage());
                return; 
            }

            using (var myXChristmasApi = new ApiWrapper<XChristmasApi>())
	        {
	            ClientApiOptions clientApiOptions = new ClientApiOptions();
	                //fill this object to override default xcApi parameters

	            if (myXChristmasApi.Init(myXChristmasApi.Api.DefaultXcApiFileName, clientApiOptions))
	            {
	                using (AutoResetEvent autoResetEvent = new AutoResetEvent(false))
	                {
                        myXChristmasApi.Api.SlackProxy_Component.PublishMessage_StateMachine.Published_State.InstanceUpdated +=
                         instance =>
                         {
                             Console.WriteLine("Message has been successfully published!");
                             autoResetEvent.Set();
                         };

                        myXChristmasApi.Api.SlackProxy_Component.PublishMessage_StateMachine.Error_State.InstanceUpdated +=
                           instance =>
                           {
                               Console.WriteLine("Error while publishing message: " + instance.PublicMember.Message);
                               autoResetEvent.Set();
                           };

                        myXChristmasApi.Api.SlackProxy_Component.SlackProxy_StateMachine.SendEvent(new SendMessage()
                        {
                            SlackChannel = cmdLineOptions.Channel,
                            SlackUrlWithToken = cmdLineOptions.WebHookUrl,
                            SlackUser = cmdLineOptions.User
                        });

	                    autoResetEvent.WaitOne();
	                }

                    Console.WriteLine("Press any key to leave...");
                    Console.ReadKey();
                }
	            else
	            {
                    Console.WriteLine("Can't initialize client Api !");
                }
	        }
	    }

	}
}