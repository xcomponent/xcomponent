# XComponent REST API Client

This project is a sample REST API client microservice developped with [XComponent](http://www.xcomponent.com).

## Prerequisite

* Get [Visual Studio Community](https://www.visualstudio.com/en-us/products/visual-studio-community-vs.aspx)
* Install RabbitMQ: [Download link](http://www.rabbitmq.com/download.html). Otherwise, you can install RabbitMQ using [Chocolatey](https://chocolatey.org/packages/rabbitmq)

## Overview

XComponent is a platform to create, monitor and share microservices.
If you want to have more details about microservices, you should read [Martin Fowler's article.](http://martinfowler.com/articles/microservices.html)

In the `REST API Client` sample we are going to create two pieces of software:
* **`[RestConsumer microservice]`** - A microservice that interacts with a pet store *Restful* service. 
* **`[Console Application]`** - A simple application to test our microservice

## Build the project

Execute the following script:
```
$ build All
```
Build results are in the *build* folder

> Note: the build is based on [Fake](http://fsharp.github.io/FAKE/)

## Run the example

### Start the "RestConsumer" microservice

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

## "REST API Client" project details

More informations: [Click here](documentation/README.md)

## Questions?

If you have any questions about this sample, please [create a Github issue for us](https://github.com/xcomponent/issues)!
