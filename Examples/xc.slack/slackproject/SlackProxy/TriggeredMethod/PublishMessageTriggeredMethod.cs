using System;
using XComponent.Common.ApiContext;
using XComponent.Common.Timeouts;
using XComponent.Shared;
using XComponent.SlackProxy.Common;
using XComponent.SlackProxy.Common.Senders;
using XComponent.SlackProxy.TriggeredMethod.SlackApi;

namespace XComponent.SlackProxy.TriggeredMethod
{
    using System;
    using XComponent.Common.ApiContext;
    using XComponent.Common.Timeouts;
    using XComponent.SlackProxy.Common.Senders;
    using XComponent.SlackProxy.Common;


    public static class PublishMessageTriggeredMethod
    {
        public static void ExecuteOn_Publishing_Through_SendMessage(XComponent.SlackProxy.UserObject.SendMessage sendMessage, XComponent.SlackProxy.UserObject.PublishMessage publishMessage, object object_InternalMember, Context context, ISendMessageSendMessageOnPublishingPublishMessageSenderInterface sender)
        {
            try
            {
                SlackPublisher slackPublisher = new SlackPublisher();
                slackPublisher.UrlWithToken = sendMessage.SlackUrlWithToken;
                slackPublisher.Channel = sendMessage.SlackChannel;
                slackPublisher.SlackUser = sendMessage.SlackUser;
                if (!string.IsNullOrEmpty(sendMessage.Color))
                {
                    slackPublisher.Color = sendMessage.Color;
                }
                if (!string.IsNullOrEmpty(sendMessage.Text))
                {
                    slackPublisher.Text = sendMessage.Text;
                }
                if (!string.IsNullOrEmpty(sendMessage.IconEmoji))
                {
                    slackPublisher.IconEmoji = sendMessage.IconEmoji;
                }
                if (!string.IsNullOrEmpty(sendMessage.MessageImage))
                {
                    slackPublisher.MessageImage = sendMessage.MessageImage;
                }
                if (!string.IsNullOrEmpty(sendMessage.MessageTitle))
                {
                    slackPublisher.MessageTitle = sendMessage.MessageTitle;
                }
                slackPublisher.SendMessage();
                sender.Success(context);
            }
            catch (Exception ex)
            {
                publishMessage.Message = ex.ToString();
                sender.Error(context);
            }
        }
    }
}