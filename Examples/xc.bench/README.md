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
PS > ./build.ps1
```

## Run the "Hello World" example

Execute the following script :
```
PS > ./run.cmd
```

> Note: RabbitMQ has to be running (default configuration)

### Open XComponent project

Execute the following script at the root:
```
PS > ./xcstudio.cmd
```

## Questions?

If you have any questions about this sample, please [create a Github issue for us](https://github.com/xcomponent/xcomponent/issues)!
