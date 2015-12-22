using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SlackApi;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            SlackApi.SlackPublisher slackPublisher = new SlackPublisher();
            slackPublisher.UrlWithToken = "https://hooks.slack.com/services/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";
            slackPublisher.Channel = "test";
            slackPublisher.SlackUser = "XComponent Team";
           
            slackPublisher.SendMessage();
        }
    }
}
