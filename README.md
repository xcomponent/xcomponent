# XComponent Resource Center

XComponent is a platform to create, monitor and share microservices.
XComponent is an open platform to easily create, control and share microservices. In XComponent, a microservice is a set of components. Each component is based on state machines. This approach is powerful and flexible because it enables you to size or resize your microservices as you want.



## Prerequisite

* Get [Visual Studio Community](https://www.visualstudio.com/en-us/products/visual-studio-community-vs.aspx)
* Install RabbitMQ (3.5.1 version is recommanded) : [Download link](https://www.rabbitmq.com/releases/rabbitmq-server/v3.5.1/). Otherwise, you can install RabbitMQ using [Chocolatey](https://chocolatey.org/packages/rabbitmq)

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

