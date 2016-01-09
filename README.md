# XComponent Resource Center

XComponent is a platform to create, monitor and share microservices.
XComponent is an open platform to easily create, control and share microservices. In XComponent, a microservice is a set of components. Each component is based on state machines. This approach is powerful and flexible because it enables you to size or resize your microservices as you want.

Microservices are developed in **C#** (.NET4 or above).

XComponent community edition provides the following tools:
* XCStudio (requires .Net 4.5 Framework): an application to design / compose components and microservices 
* XCRuntime (requires .Net 4.0 Framework and can runs on Windows or under [Mono](http://www.mono-project.com/)): an execution environment for xc microservices
* XCSpy (requires .Net 4.5 Framework): a test and monitoring tool
* XComponent Gallery: it enables you to share easily your projects


The following figure is a good summary of the XComponent architecture.

![xcomponent architecture](Images/architecture.jpg)

> Note: "Microservice architectural style is an approach to develop a single application as a suite of small services, each running in its own process and communicating with lightweight mechanisms. These services are built around business capabilities and independently deployable by fully automated deployment machinery.” *James Lewis & Martin Fowler*

For a better understanding of XComponent, we suggest to read the [user guide](Documentation/README.md).

Thanks to the [Use Cases](Examples) section, you will able to understand:
* How to develop microservices with XCStudio 
* How to run them with XCRuntime
* How to consume microservices with XComponent Apis


## Prerequisite
* .NET 4.5 framework
* Get [Visual Studio Community](https://www.visualstudio.com/en-us/products/visual-studio-community-vs.aspx)
* A RabbitMQ middleware (3.5.1 version is recommanded) : [Download link for windows](https://www.rabbitmq.com/releases/rabbitmq-server/v3.5.1/rabbitmq-server-3.5.1.exe). Otherwise, if you want to install RabbitMQ on other OS you can follow this [link](https://www.rabbitmq.com/releases/rabbitmq-server/v3.5.1/)

## Install

* XComponent community edition is available on Nuget:
```
$ Tools\NuGet.exe install XComponent.Community -ConfigFile Tools\Nuget.Config -ExcludeVersion -OutputDirectory .\packages -Version 4.5.0-rc0118
```
* Download msi:
 * [4.5.0 x64](https://github.com/xcomponent/xcomponent/releases/download/4.5.0/XComponentCommunity-4.5.0-G8_x64.msi)
 * [4.5.0 x86](https://github.com/xcomponent/xcomponent/releases/download/4.5.0/XComponentCommunity-4.5.0-G8_x86.msi)

## Documentation

[User Guide](Documentation/README.md)

## Use Cases

[Click here](Examples) to see XComponent examples.

It is a good starting point to understand how the XComponent platform works.

## Test Plan

[Test Plan](TestPlan/README.md)

## Questions ?

If you have any questions about this sample, please [create a Github issue for us](https://github.com/xcomponent/xcomponent/issues)!

