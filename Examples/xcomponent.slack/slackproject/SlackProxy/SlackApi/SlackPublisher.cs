using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SlackApi
{
    public class SlackPublisher
    {
        public string UrlWithToken { get; set; }
        public string Channel { get; set; }
        public string SlackUser { get; set; }

        public void SendMessage()
        {
            if (!string.IsNullOrEmpty(UrlWithToken) && !string.IsNullOrEmpty(Channel))
            {
                    SlackClient client = new SlackClient(UrlWithToken);

                    SlackMessage slackMessage = new SlackMessage();
                    slackMessage.Channel = Channel;
                    slackMessage.Username = SlackUser;
                    slackMessage.IconEmoji = ":christmas_tree:";


                    SlackAttachment a = new SlackAttachment();
                    a.Color = "good";
                    a.Title = "Merry Christhmas !!!";
                    a.ImageUrl =
                        "https://scontent-cdg2-1.xx.fbcdn.net/hphotos-xap1/t31.0-8/12052390_965355310189672_2198005579528258871_o.jpg";
                    a.Text = "We wish you a Merry Christhmas and Happy Coding with XComponent <https://github.com/xcomponent/xcomponent | (Follow us on GitHub) >";

                    slackMessage.Attachments = new List<SlackAttachment>() { a };

                    client.Post(slackMessage);
            }
            else
            {
              throw new Exception("Channel and Url with Token are mandatory !");
            }

        }
    }
}
