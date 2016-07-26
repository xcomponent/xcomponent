# XComponent Bench

This project is a simple `Bench` program for [XComponent](http://www.xcomponent.com).

## Overview

XComponent is a platform to create, monitor and share microservices.
If you want to have more details about microservices, you should read [Martin Fowler's article.](http://martinfowler.com/articles/microservices.html)

In the `Bench` sample we're actually going to run two different pieces of software concurrently:
* **`[Bench microservice]`** - A microservice that proceeds the benching
* **`[BenchRunner]`** - A simple application to start the benching

## Build the project

Execute the following script:
```
$ cd Examples\xc.bench
$ build
```
Build results are in the *build* folder

> Note: the build is based on [Fake](http://fsharp.github.io/FAKE/)

## Run the "Bench" example

### Start the "Bench" microservice

Execute the following script :
```
$ build\startMicroservice.cmd
```

### Start the ConsoleApp

Execute the following script:
```
$ build\startConsoleApp.cmd
```
> Note: RabbitMQ has to be running (default configuration)

### Open XComponent project

Execute the following script at the root:
```
$ xcstudio.cmd
```

## Questions?

If you have any questions about this sample, please [create a Github issue for us](https://github.com/xcomponent/xcomponent/issues)!
