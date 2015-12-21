# XComponent Order Processing example

This project is a simple and naïve `Order Processing` microservice implemented using [XComponent](http://www.xcomponent.com).

## Prerequisite

* Get [Visual Studio Community](https://www.visualstudio.com/en-us/products/visual-studio-community-vs.aspx)
* Install RabbitMQ: [Download link](http://www.rabbitmq.com/download.html). Otherwise, you can install RabbitMQ using [Chocolatey](https://chocolatey.org/packages/rabbitmq)

## Overview

XComponent is a platform to create, monitor and share microservices.
If you want to have more details about microservices, you should read [Martin Fowler's article.](http://martinfowler.com/articles/microservices.html)

In the `Order Processing` sample we're actually going to run two different pieces of software concurrently:
* **`[Order Processing microservice]`** - A microservice that receives *order creation* and *order execution* requests 
* **`[Console Application]`** - A simple application to test our microservice

## Build the project

Execute the following script:
```
$ build All
```
Build results are in the *build* folder

> Note: the build is based on [Fake](http://fsharp.github.io/FAKE/)

## Run the "Order Processing" example

### Start the "Order Processing" microservice

Execute the following script in the *build* folder:
```
$ startMicroservices.cmd
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

## Create your own "Order Processing" project

Step by step tutorial: [Click here](documentation/README.md)

## Questions?

<<<<<<< HEAD
If you have any questions about this sample, please [create a Github issue for us](https://github.com/xcomponent/xcomponent/issues)!
=======
If you have any questions about this sample, please [create a Github issue for us](https://github.com/xcomponent/xcomponent.orderprocessing/issues)!
>>>>>>> ded11e7603a1629b3194f0a94a09a55a31a4ee67
