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
        public string MessageImage { get; set; }
        public string MessageTitle { get; set; }
        public string Text { get; set; }
        public string IconEmoji { get; set; }
        public string Color { get; set; }

        public SlackPublisher()
        {
            Color = "good";
            MessageTitle = "Merry Christmas !!!";
            Text = "We wish you a Merry Christmas and Happy Coding with XComponent <https://github.com/xcomponent/xcomponent | (Follow us on GitHub) >";
            IconEmoji = ":christmas_tree:";
        }
        public void SendMessage()
        {
            if (!string.IsNullOrEmpty(UrlWithToken) && !string.IsNullOrEmpty(Channel))
            {
                    SlackClient client = new SlackClient(UrlWithToken);

                    SlackMessage slackMessage = new SlackMessage();
                    slackMessage.Channel = Channel;
                    slackMessage.Username = SlackUser;
                    slackMessage.IconEmoji = IconEmoji;

                    SlackAttachment a = new SlackAttachment();
                    a.Color = Color;
                    a.Title = MessageTitle;
                    if (!string.IsNullOrEmpty(MessageImage))
                    {
                        a.ImageUrl = MessageImage;
                    }
                   
                    a.Text = Text;

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
