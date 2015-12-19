#XComponent User Guide

## Contents

* [Overview](#overview)
* [XComponent philosophy](#xcomponent-philosophy)
 * [Microservice definition](#microservice-definition)
 * [Component definition](#component-definition)
 * [State machine definition](#state-machine-definition)
 * [State definition](#state-definition)

## Overview

XComponent is an open platform to easily create, control and share microservices.
In XComponent, a microservice is a set of components. Each component is based on state machines.
This approach is powerful and flexible because it enables you to size or resize your microservices as you want.

XComponent provides the following tools:
* XCStudio: an application to design / compose components and microservices
* XCRuntime: an execution environment for xc microservices
* XCSpy: a test tool
* XComponent AC2: an application to deploy and control microservices
* XComponent Gallery: it enables you to share easily your projects

The following figure is a good summary of the XComponent architecture.

![xcomponent architecture](Images/architecture.jpg)

> Note: "Microservice architectural style is an approach to develop a single application as a suite of small services, each running in its own process and communicating with lightweight mechanisms. These services are built around business capabilities and independently deployable by fully automated deployment machinery.” *James Lewis & Martin Fowler*

# XComponent philosophy

XComponent is based on state machine diagrams. To design, implement and build your projects you’re going to use XCStudio and Visual Studio. 
XCStudio is an IDE to create microservices. 

The aim of this chapter is to provide you few definitions of the concepts related to XComponent including:
* a microservice
* a component
* a state machine
* a state
* a transition
* an event
* a triggered method
* a triggering rule
* an api
* a composition

## Microservice definition

> "Microservice architectural style is an approach to developing a single application as a suite of small units, each running in its own process and communicating with lightweight mechanisms" *Martin Fowler*

XComponent defines a microservice as a set of components. It leads to much more flexibility:
Indeed, you can begin with a monolith, and then split your architecture into microservices.

XComponent proposes to embrace the microservice style:
* Split each feature in a separate service
* Easy evolution, refactoring and scaling / accelerate innovation
* Single responsibility pattern (business oriented service) 
* Decoupled your microservices (Tolerant Reader Pattern for example)

This approach promotes the idea of "design for failure".
It means that your application has to tolerate service failures. For example, you can use circuit breakers and timeout patterns.

## Component definition

In XComponent, a component is a logical brick answering a functional need. It’s an aggregation of several state machines, each state machine made of several states linked to each other by transitions.

## State machine definition

The definition of a state machine is similar to a class in Object-Oriented Programming. It can be instantiated several times exactly as a class can be. A class instance is an object and in XComponent we call it a state machine instance. 
In XCStudio a state machine is a set of states, a state machine is delimited by a blue edge.

## State definition

A state is the current status of a state machine instance.
A state is represented by a colored circle in XCStudio.



