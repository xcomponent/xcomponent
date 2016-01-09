# XComponent Authentication

This project is a simple `authentication` microservice developped with [XComponent](http://www.xcomponent.com).

## Overview

XComponent is a platform to create, monitor and share microservices.
If you want to have more details about microservices, you should read [Martin Fowler's article.](http://martinfowler.com/articles/microservices.html)

In the `authentication` sample we're actually going to run two different pieces of software concurrently:
* **`[Authentication microservice]`** - A microservice that receives *login* requests 
* **`[Console Application]`** - A simple application sending *login* requests to our microservice

## Build the project

Execute the following script:
```
$ build All
```
Build results are in the *build* folder

> Note: the build is based on [Fake](http://fsharp.github.io/FAKE/)

## Run the "authentication" example

### Start the "authentication" microservice

Execute the following script in:
```
$ build\startMicroservice.cmd
```

### Start the ConsoleApp

Execute the following script in the *build* folder:
```
$ build\startConsoleApp.cmd
```
> Note: RabbitMQ has to be running (default configuration)

### Open XComponent project

Execute the following script at the root:
```
$ xcstudio.cmd
```

## "Authentication" project details

More informations: [Click here](documentation/README.md)

## Questions?

If you have any questions about this sample, please [create a Github issue for us](https://github.com/xcomponent/xcomponent.helloworld/issues)!
