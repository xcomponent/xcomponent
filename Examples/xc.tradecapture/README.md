# XComponent Trade Capture


**Trade capture** is the process of booking (or capturing) the trade into the systems used within a financial organisation.
With this project you will learn how to design a simple `trade capture` application with [XComponent](http://www.xcomponent.com).

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
PS > ./build.ps1
```

## Run the example

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

## "Trade Capture" project details

To understand how this project works just [Click here](documentation/README.md)

## Questions?

If you have any questions about this sample, please [create a Github issue for us](https://github.com/xcomponent/xcomponent/issues)!
