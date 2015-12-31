using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace XComponent.SlackProxy.TriggeredMethod.SlackApi
{
    internal class SlackAttachment
    {
        /// <summary>
        /// Required text summary of the attachment that is shown by clients that understand attachments but choose not to show them.
        /// </summary>
        public string Fallback { get; set; }
        /// <summary>
        /// Optional text that should appear within the attachment
        /// </summary>
        public string Text { get; set; }
        /// <summary>
        /// Optional text that should appear above the formatted data
        /// </summary>
        public string PreText { get; set; }
        /// <summary>
        /// Can either be one of 'good', 'warning', 'danger', or any hex color code
        /// </summary>
        public string Color { get; set; }

        public string Title { get; set; }
        public string ImageUrl { get; set; }
        /// <summary>
        /// Fields are displayed in a table on the message
        /// </summary>
        public List<SlackField> Fields { get; set; }
    }
}
