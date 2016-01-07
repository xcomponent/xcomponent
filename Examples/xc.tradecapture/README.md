# XComponent Trade Capture


**Trade capture** is the process of booking (or capturing) the trade into the systems used within a financial organisation.
With this project you will learn how to design a simple `trade capture` application with [XComponent](http://www.xcomponent.com).

## Prerequisite

* Get [Visual Studio Community](https://www.visualstudio.com/en-us/products/visual-studio-community-vs.aspx)
* Install RabbitMQ (3.5.1 version is recommanded) : [Download link](https://www.rabbitmq.com/releases/rabbitmq-server/v3.5.1/). Otherwise, you can install RabbitMQ using [Chocolatey](https://chocolatey.org/packages/rabbitmq)

## Overview

XComponent is a platform to create, monitor and share microservices.
If you want to have more details about microservices, you should read [Martin Fowler's article.](http://martinfowler.com/articles/microservices.html)

In this project, we're actually going to run different pieces of software concurrently:

* **`[Referential microservice]`** - A microservice in charge of maintaining a list of valid financial instruments
* **`[TradeCapture microservice]`** - A microservice in charge of the trades validation

* **`[Trade Creator Application]`** - A Wpf Application from which we can create new trades
* **`[Trade Validator Application]`** - A Wpf Application from which we can monitor and validate trades


## Build the project

Execute the following script:
```
$ build All
```
Build results are in the *build* folder

> Note: the build is based on [Fake](http://fsharp.github.io/FAKE/)

## Run the "Trade Capture" project

### 1. Start the microservices
#### Start the "referential" microservice

Execute the following script in the *build* folder:
```
$ startReferentialService.cmd
```

#### Start the "trade" microservice

Execute the following script in the *build* folder:
```
$ startTradeService.cmd
```

### 2. Start the GUIs

### Start the Trade Creator Gui

Execute the following script in the *build* folder:
```
$ startTradeCreatorGui.cmd
```

### Start the Trade Validator Gui

Execute the following script in the *build* folder:
```
$ startTradeValidatorGui.cmd
```

> Note: RabbitMQ has to be running (default configuration)

### Open XComponent project

Execute the following script at the root:
```
$ xcstudio.cmd
```

## "Trade Capture" project details

To understand how this project works just [Click here](documentation/README.md)

## Questions?

If you have any questions about this sample, please [create a Github issue for us](https://github.com/xcomponent/xcomponent/issues)!
