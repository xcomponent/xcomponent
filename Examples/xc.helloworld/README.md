# XComponent Hello World

This project is a classic `Hello World` program applied to [XComponent](http://www.xcomponent.com).

## Prerequisite

* Get [Visual Studio Community](https://www.visualstudio.com/en-us/products/visual-studio-community-vs.aspx)
* Install RabbitMQ (3.5.1 version is recommanded) : [Download link](https://www.rabbitmq.com/releases/rabbitmq-server/v3.5.1/). Otherwise, you can install RabbitMQ using [Chocolatey](https://chocolatey.org/packages/rabbitmq)

## Overview

XComponent is a platform to create, monitor and share microservices.
If you want to have more details about microservices, you should read [Martin Fowler's article.](http://martinfowler.com/articles/microservices.html)

In the `Hello World` sample we're actually going to run two different pieces of software concurrently:
* **`[Hello World microservice]`** - A microservice that receives *say hello* requests 
* **`[Console Application]`** - A simple application to test our microservice

## Build the project

Execute the following script:
```
$ build All
```
Build results are in the *build* folder

> Note: the build is based on [Fake](http://fsharp.github.io/FAKE/)

## Run the "Hello World" example

### Start the "Hello World" microservice

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

## Create your own "Hello World" project

Step by step tutorial: [Click here](documentation/README.md)

## Questions?

If you have any questions about this sample, please [create a Github issue for us](https://github.com/xcomponent/xcomponent/issues)!
