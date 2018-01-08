# XComponent Order Processing example

This project is a simple and naïve `Order Processing` microservice implemented using [XComponent](http://www.xcomponent.com).

## Overview

XComponent is a platform to create, monitor and share microservices.
If you want to have more details about microservices, you should read [Martin Fowler's article.](http://martinfowler.com/articles/microservices.html)

In the `Order Processing` sample we're actually going to run two different pieces of software concurrently:
* **`[Order Processing microservice]`** - A microservice that receives *order creation* and *order execution* requests 
* **`[Console Application]`** - A simple application to test our microservice

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

### Open XComponent project

Execute the following script at the root:
```
PS > ./xcstudio.cmd
```


## Create your own "Order Processing" project

Step by step tutorial: [Click here](documentation/README.md)

## Questions?

If you have any questions about this sample, please [create a Github issue for us](https://github.com/xcomponent/xcomponent/issues)!
