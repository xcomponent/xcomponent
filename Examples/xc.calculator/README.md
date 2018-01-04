# XComponent Calculator

The `Calculator` project is an example of project where triggered methods are implemented in JavaScript instead of C#.

## Overview

As we have seen in other examples, in a XComponent project consists of a state machine model defined in XCStudio coupled with C# code to implement the behavior of state machine instances when they change state. This behavior is described as a set of C# methods called triggered methods. Starting at version 5.0, XComponent introduces the concept of *REST* implemented triggered methods, in opposition to *Native* triggered methods implemented in C#. It makes it possible to implement XComponent triggered methods in any language that is able to use a REST service.

A XComponent microservice whose triggered methods should be implemented by a REST service starts a REST service upon start up. The REST service queues triggered methods to be executed (called Tasks) by clients (called Workers) following a protocol described [here](https://github.com/xcomponent/XComponent.Functions).

In the `Calculator` sample we will run two different pieces of software concurrently:
* **`[Calculator microservice]`** - A XComponent microservice that receives requests to calculate additions;
* **`[Calculator.js worker]`** - A simple NodeJS application to run triggered methods coded in JavaScript.

## Build the project

Execute the following script on PowerShell:
```
$ ./build.ps1
```

## Run the example

Execute the following script :
```
$ ./xcruntime.cmd
```

## Create your own "Calculator" project

[ Step by step tutorial ](documentation/README.md)

## Questions?

If you have any questions about this sample, please [create a Github issue for us](https://github.com/xcomponent/xcomponent/issues)!
