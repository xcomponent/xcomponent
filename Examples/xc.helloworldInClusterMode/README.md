# XComponent Hello World in cluster mode

This project illustrates our clustering support applied to the [Hello World](../xc.helloworld) sample.

## Overview

XComponent is a platform to create, monitor and share microservices.
If you want to have more details about microservices, you should read [Martin Fowler's article.](http://martinfowler.com/articles/microservices.html)
 
XComponent integrated a new features which are Clustering and Failover. XComponent Cluster allows developpers to implement stateful services, which execute requests based on internal state, with High Availability (HA) and Fault Tolerance (FT). Stateful architectures are powerful, simplify deployment and the time to process requests is shorter. However, in a cluster deployment the application state is scattered across several nodes and this has major impacts on the implementation of HA and FT.

- The context of the request is important: only a node in the cluster can handle a given context because it is the owner of the corresponding state. The cluster must implement a consistent partitioning of the application state among the nodes in the cluster. This is called dynamic sharding (or partitioning). Each node owns a shard at a given time.

- When a node fails, another node in the cluster must take over requests formerly handled by the faulty node. This requires continuous state synchronization among the nodes in the cluster.

- When a node joins the cluster, it does not own any state, so it cannot process any requests. Therefore, a protocol for load balancing must be implemented natively in the cluster: old nodes will handover some of their state to the new node. This is called resharding and it is performed by a partial shard handover.

XComponent Cluster is based on [Akka.Net](https://getakka.net/articles/intro/what-is-akka.html) and [Akka.Cluster](https://getakka.net/articles/clustering/cluster-overview.html). Akka.Cluster features are based on the [cluster gossip](https://getakka.net/articles/clustering/cluster-overview.html#cluster-gossip), a distributed protocol implemented between cluster nodes (cluster members) that allows new nodes/members to join the cluster, existing nodes to leave it and a leader of the cluster to be elected. When the cluster gossip converges, the cluster has an elected leader that undertakes cluster actions like declaring as Up members that joined, declaring as Unreachable members for which a majority of nodes confirms they are unreachable. 

When a new node joins the cluster, it must point to an existing node as a **seed**, which can be any node in the cluster. The first node joining the cluster uses its own address as a seed, it does a self-join which creates the cluster with one node. 

Partition tolerance is achieved through the concept of reachability. A node can be seen as Unreachable, but still be part of the cluster and able to handle work. XComponent implemented a strategy in order to solve this problem of network partition / split brain by implementing a first strategy called Quorum. This strategy consists of downing unreachable nodes if the number of reachable ones is greater than or equal to a minimum number of members in the cluster. This minimum number is defined by the user. This strategy works well when you are able to define minimum required cluster size and when you have a cluster with fixed size of nodes or fixed size of nodes with specific role.  

In the `Hello World in Cluster Mode` sample, we're going to use the `Hello World` project and run two different pieces of software concurrently:

* **`[Hello World microservice]`** - A microservice launched in cluster mode (launching more than one node of XComponent runtime) that receives *say hello* requests 
* **`[Console Application]`** - A simple application to test our microservice

## Build the project

Execute the following script from the directory `xc.helloworld`:
```
PS > ./build.ps1
```

## Run the "Hello World" example in cluster mode

Execute the following script from the directory `xc.helloworld`:
```
PS > ./runCluster.cmd
```
Enter a name in the displayed console and see the logs of the launched runtimes (3 launched nodes). You will see a message in green color displayed in the console of the owner node.

Entering a name in the console creates a new instance of the state machine `HelloWorldResponse`. This instance is created in the owner node and replicas of this instance are created in the other nodes
in order to handle the failover and to ensure the high availability.

If you kill a node from the cluster, you will see that the other nodes will share all the requests (instances) handled by the
removed node.

> Note: RabbitMQ has to be running (default configuration) 

## Questions?

If you have any questions about this sample, please [create a Github issue for us](https://github.com/xcomponent/xcomponent/issues)!
