using System;
using System.Threading;
using CommandLine;
using CommandLine.Text;
using XCClientAPICommon.ApiExtensions;
using XComponent.SlackGateway.SlackGatewayApi;
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
                Console.WriteLine("Enter Slack WebHook url:");
                cmdLineOptions.WebHookUrl = Console.ReadLine();
                Console.WriteLine("Enter Slack channel:");
                cmdLineOptions.Channel = Console.ReadLine();
                Console.WriteLine("Enter Slack user:");
                cmdLineOptions.User = Console.ReadLine();
            }

            using (var mySlackGateway = new ApiWrapper<SlackGatewayApi>())
	        {
	            ClientApiOptions clientApiOptions = new ClientApiOptions();
	                //fill this object to override default xcApi parameters

	            if (mySlackGateway.Init(mySlackGateway.Api.DefaultXcApiFileName, clientApiOptions))
	            {
	                using (AutoResetEvent autoResetEvent = new AutoResetEvent(false))
	                {
                        mySlackGateway.Api.SlackProxy_Component.PublishMessage_StateMachine.Published_State.InstanceUpdated +=
                         instance =>
                         {
                             Console.WriteLine("Message has been successfully published!");
                             autoResetEvent.Set();
                         };

                        mySlackGateway.Api.SlackProxy_Component.PublishMessage_StateMachine.Error_State.InstanceUpdated +=
                           instance =>
                           {
                               Console.WriteLine("Error while publishing message: " + instance.PublicMember.Message);
                               autoResetEvent.Set();
                           };

	                    SendMessage slackMessage = new SendMessage()
	                    {
	                        SlackChannel = cmdLineOptions.Channel,
	                        SlackUrlWithToken = cmdLineOptions.WebHookUrl,
	                        SlackUser = cmdLineOptions.User,
                           // MessageTitle = "My first slack message",
                           // Text = "Hello from slack",
                           //  MessageImage = "https://raw.githubusercontent.com/xcomponent/xcomponent/master/Examples/xcomponent.slack/images/XCChristmasLogo.png",
                           // IconEmoji = ":tv:" // http://www.emoji-cheat-sheet.com/
                        };

                        mySlackGateway.Api.SlackProxy_Component.SlackProxy_StateMachine.SendEvent(slackMessage);

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