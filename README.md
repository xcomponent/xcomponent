[![](http://slack.xcomponent.com/badge.svg)](http://slack.xcomponent.com/)

# XComponent Resource Center

XComponent is a platform to easily create, monitor and share **microservices**.
In XComponent, a microservice is a set of components. Each component is based on **state machines** (States machines are designed graphically). This approach is powerful and flexible because it enables you to size or resize your microservices as you want.

![Authentication component](Documentation/Images/component_impl.jpg)

Microservices are developed in **C#** (.NET4 or above).

XComponent community edition provides the following tools:
* XCStudio (requires .Net 4.5 Framework): the IDE to design / compose components and microservices 
* XCRuntime (requires .Net 4.0 Framework and can runs on Windows or under [Mono](http://www.mono-project.com/)): an execution environment for xc microservices
* XCSpy (requires .Net 4.5 Framework): a test and monitoring tool
* XComponent Gallery: it enables you to share easily your projects



> Note: "Microservice architectural style is an approach to develop a single application as a suite of small services, each running in its own process and communicating with lightweight mechanisms. These services are built around business capabilities and independently deployable by fully automated deployment machinery.” *James Lewis & Martin Fowler*

## Building Microservices with XComponent
* Define your **Components** according to a business logic or a technical logic 

> Note: In XComponent, a **“Component”** is a set of state machines (micro-orchestration)

* Link the components (Composition) between them
* Create the **APIs**
* Create your Microservices as sets of **Components**
* Deploy your microservices and run them with **XCRuntime** (under Windows or Mono)

With XComponent, your microservices have the following avantages:
* They can communicate each other in Real-Time
* You can communicate with your microservices in Real-Time using XComponent Apis
* You can easily **resize** your microservices 
* You can migrate from a Monolith to a full microservices architecture without a line of code !
* XComponent platform is fully asynchronous and it is running on the top of a RabbitMQ middleware. Nevertheless, the complexity of this kind of architecture is hidden to the developper
* You can monitor in Real-Time the status of your microservices
For a better understanding of XComponent, and for more details, we suggest to read the [user guide](Documentation/README.md) or to jump to the [Hello World sample](Examples/xc.helloworld/README.md).


Thanks to the [Use Cases](Examples) section, you will able to understand:
* How to develop microservices with XCStudio 
* How to run them with XCRuntime
* How to consume microservices with XComponent Apis


## Prerequisite
* .NET 4.5 framework
* Get [Visual Studio Community](https://www.visualstudio.com/en-us/products/visual-studio-community-vs.aspx)
* A RabbitMQ middleware (3.5.1 version or later is recommanded) : [Download link for windows](https://www.rabbitmq.com/releases/rabbitmq-server/current/). 

## Install

All samples will directly download XComponent Community Edition from [Nuget](https://www.nuget.org/packages/xcomponent.community/). Nevertheless, if for some reasons, you need an MSI, you can get one in the [releases page](https://github.com/xcomponent/xcomponent/releases).

## Documentation

[User Guide](Documentation/README.md)

## Use Cases

[Click here](Examples) to see XComponent examples.

It is a good starting point to understand how the XComponent platform works.


## Test Framework

[Click here](TestFramework/README.md) to have details about the Test Framework.

## Sequence Diagram Control

[Click here](SequenceDiagram/README.md) to have details about the Sequence Diagram Control.

## Questions ?

If you have any questions about this sample, please [create a Github issue for us](https://github.com/xcomponent/xcomponent/issues)!

You can also join us on [Slack](http://slack.xcomponent.com)!

