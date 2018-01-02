# XComponent Calculator

The project `Calculator` is a classic program applied to [XComponent](http://www.xcomponent.com).

## Overview

XComponent is a platform to create, monitor and share microservices.
If you want to have more details about microservices, you should read [Martin Fowler's article.](http://martinfowler.com/articles/microservices.html)

In the `Calculator` sample we're actually going to run two different pieces of software concurrently:
* **`[Calculator microservice]`** - A microservice that receives *Calculate* requests 
* **`[NodeJS Application]`** - A simple application to run triggered methods coded in Javascript

## Build the project

Execute the following script:
```
$ cd calculator
$ 
```
Build results are in *...* folder

> Note: the build is based on [Fake](http://fsharp.github.io/FAKE/)

## Run the "Calculator" example

### Start the "Calculator" microservice

Execute the following script :
```
$ 
```

### Start the NodeJS application

Execute the following script:
```
$ node Calculator/calculator.js
```
> Note: RabbitMQ has to be running (default configuration)

### Open XComponent project

Execute the following script at the root:
```
$ 
```

## Create your own "Calculator" project

Step by step tutorial: [Click here](documentation/README.md)

## Questions?

If you have any questions about this sample, please [create a Github issue for us](https://github.com/xcomponent/xcomponent/issues)!
