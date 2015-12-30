using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace XComponent.SlackProxy.TriggeredMethod.SlackApi
{
    internal class SlackMessage
    {
        /// <summary>
        /// This is the text that will be posted to the channel
        /// </summary>
        public string Text { get; set; }
        /// <summary>
        /// Optional override of destination channel
        /// </summary>
        public string Channel { get; set; }
        /// <summary>
        /// Optional override of the username that is displayed
        /// </summary>
        public string Username { get; set; }
        /// <summary>
        /// Optional emoji displayed with the message
        /// </summary>
        public string IconEmoji { get; set; }
        /// <summary>
        /// Optional attachment collection
        /// </summary>
        public List<SlackAttachment> Attachments { get; set; }
    }
}
