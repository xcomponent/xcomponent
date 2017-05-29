# XComponent Chat

This project is a classic a chat room implemented with XComponent.

## Overview

## Build the project

Execute the following script:
```
$ cd Examples\xc.chat
$ build
```
Build results are in the *build* folder

> Note: the build is based on [Fake](http://fsharp.github.io/FAKE/)

## Run the "Chat" example

### Start the "Chat" microservice

Execute the following script :
```
$ build\startMicroservice.cmd
```

### Start the Web applicatioin

Execute the following script:
```
$ build\startWebApplication.cmd
```
> Note: RabbitMQ has to be running (default configuration)

### Open the XComponent project

Execute the following script at the root:
```
$ xcstudio.cmd
```

## Create your own "Chat" project

Step by step tutorial: [Click here](documentation/README.md)

## Questions?

If you have any questions about this sample, please [create a Github issue for us](https://github.com/xcomponent/xcomponent/issues)!
