# XComponent Slack

This project is a simple gateway to [Slack](http://wwww.slack.com). With this gateway you will be able to send messages to a [Slack](http://wwww.slack.com) channel using [XComponent](http://www.xcomponent.com).

## Prerequisite

* Get [Visual Studio Community](https://www.visualstudio.com/en-us/products/visual-studio-community-vs.aspx)
* Install RabbitMQ: [Download link](http://www.rabbitmq.com/download.html). Otherwise, you can install RabbitMQ using [Chocolatey](https://chocolatey.org/packages/rabbitmq)
* You should have a [Slack](http://wwww.slack.com) account. On [Slack](http://wwww.slack.com), you should create a `WebHook`. For more details about `WebHook`, please refers to the [Slack api documentation](https://api.slack.com/)


## Overview

XComponent is a platform to create, monitor and share microservices.
If you want to have more details about microservices, you should read [Martin Fowler's article.](http://martinfowler.com/articles/microservices.html)

In the `Slack` sample we're actually going to run two different pieces of software concurrently:
* **`[Slack microservice]`** - A microservice which sends **Merry Christmas** messages to a [Slack](http://wwww.slack.com) channel
* **`[Console Application]`** - A simple application to communicate with the microservice

## Build the project

Execute the following script:
```
$ build All
```
Build results are in the *build* folder

> Note: the build is based on [Fake](http://fsharp.github.io/FAKE/)

## Run the "Slack" example

### Start the "Slack" microservice

Execute the following script in the *build* folder:
```
$ startMicroservice.cmd
```

### Start the ConsoleApp

Execute the following script in the *build* folder:
```
$ startConsoleApp.cmd
```
> Note: RabbitMQ has to be running (default configuration)

### Open XComponent project

Execute the following script at the root:
```
$ xcstudio.cmd
```

## Some details about the project

### 1. Slack proxy microservice
![Slack proxy component](images/SlackProxy_Image.png)

The `Slack` microservice contains only one component: the `SlackProxy`. The api to send messages on `Slack` is directly embedded in the `Triggered methods` of this component.
With the code below, we have the hability to post messages on `Slack`.
It is easy to customize this component to send your customs messages. By default, the component sends a ***Merry Christmas** message :)

```cs
try {
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
 } catch (Exception ex) {
        publishMessage.Message = ex.ToString();
        sender.Error(context);
 }
```

### 2. The console application

The console application embeds the XComponent client Api. This way, the application is able to communicate with the `Slack` microservice.
This application needs several inputs:
* The name of the `Slack` channel
* The `WebHook` url
* The name of the user 

The console source code is quite simple:
```cs
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
                            SlackUser = cmdLineOptions.User,
                            // MessageTitle = "My first slack message",
                            // Text = "Hello from slack",
                            //  MessageImage = "http://www2.xcomponent.com/wp-content/uploads/2015/12/logo-340x1561.png",
                            // IconEmoji = ":christmas_tree:" // http://www.emoji-cheat-sheet.com/
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
```

If the console application runs correctly, you will have a post like this on your `Slack` channel :)

![Slack proxy component](images/slack.png)

## Questions?

If you have any questions about this sample, please [create a Github issue for us](https://github.com/xcomponent/xcomponent/issues)!
