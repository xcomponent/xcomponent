# XComponent Examples

## Prerequisite

* Get [Visual Studio Community](https://www.visualstudio.com/en-us/products/visual-studio-community-vs.aspx)
* Install RabbitMQ: [Download link](http://www.rabbitmq.com/download.html). Otherwise, you can install RabbitMQ using [Chocolatey](https://chocolatey.org/packages/rabbitmq)

## Build all examples

Execute the following script:
```
$ build All
```
Build results are in the *build* folder of each example.

> Note: the build is based on [Fake](http://fsharp.github.io/FAKE/)

## Examples overview

* **Hello World** ([Click here](xcomponent.helloworld)): 
standard example to demonstrate the use of XComponent without knowing too much about microservices
* **Simple Authentication service** ([Click here](xcomponent.authentication)): 
example to demonstrate how to develop a simple authentication microservice with XComponent: you will learn how to store data in a component and how to use file resources