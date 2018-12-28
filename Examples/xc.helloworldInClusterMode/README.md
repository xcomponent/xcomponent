# XComponent Hello World in cluster mode

This project is a classic `Hello World` program in cluster mode applied to [XComponent](http://www.xcomponent.com).

## Overview

XComponent is a platform to create, monitor and share microservices.
If you want to have more details about microservices, you should read [Martin Fowler's article.](http://martinfowler.com/articles/microservices.html)
 
XComponent integrated a new features which are Clustering and Failover. XComponent Cluster allows developpers to implement stateful services, which execute requests
based on internal state, with High Availability (HA) and Fault Tolerance (FT). 
Stateful architectures are powerful, simplify deployment and the time to process requests is shorter. 
However, in a cluster deployment the application state is scattered across several nodes and this has major impacts on the implementation of HA and FT.

- The context of the request is important: only a node in the cluster can handle a given context because it is the owner of the corresponding state. 
The cluster must implement a consistent partitioning of the application state among the nodes in the cluster. This is called dynamic sharding
(or partitioning). Each node owns a shard at a given time. The shard (or partition) size evolves over time as new entities are created 

- When a node fails, another node in the cluster must take over requests formerly handled by the faulty node. This requires continuous state 
synchronization among the nodes in the cluster.

- When a node joins the cluster, it does not own any state, so it cannot process any request. Therefore, a protocol of load balancing must be implemented
natively in the cluster: old nodes will handover some of their state to the new node. This is called resharding and it is completed with a partial shard handover.

==> In short, a stateful cluster must implement: 

- A dynamic sharding strategy 

- Continuous state synchronization between the nodes in the cluster 

- A dynamic resharding strategy in case of cluster topology changes

XComponent Cluster implemented these features in order to have a stateful clusters that automatically decide which node handles a given event, 
load-balance in case of cluster topology changes and guarantee that the input events are processed in the same order as they arrive on the messaging middleware.

XComponent Cluster is based on [Akka.Net](https://getakka.net/articles/intro/what-is-akka.html) and [Akka.Cluster](https://getakka.net/articles/clustering/cluster-overview.html).
Akka.Cluster features are based on the [cluster gossip](https://getakka.net/articles/clustering/cluster-overview.html#cluster-gossip), a distributed protocol implemented between
cluster nodes (cluster members) that allows new nodes/members to join the cluster, existing nodes to leave it and a leader of the cluster to be elected. When the cluster gossip 
converges, the cluster has an elected leader that undertakes cluster actions like declaring as Up members that joined, declaring as Unreachable members for which a majority of
nodes confirms they are unreachable. 
When a new node joins the cluster, it must point to an existing node as a seed, which can be any node in the cluster. The first node joining the cluster uses its own address
as a seed, it does a self-join which creates the cluster with one node. The seed node is only used in the join process, it does not have a special cluster role. Also, any existing
node in the cluster can be used as a seed by a joining node.

For the dynamic sharding, XComponent Cluster implemented its own strategy based on consistent hash ring technique inspired by the [Chord](https://pdos.csail.mit.edu/papers/chord:sigcomm01/chord_sigcomm.pdf)
algorithm in order to perform state machine instance sharding.
Load balancing within a cluster with Consistent Hash ring technique allows load distribution between different cluster nodes based on a Hash Code value. In order to have a uniform distribution
within the cluster, we use the Consistent Hash ring approach based on virtual nodes. This approach consists of creating replicas of the cluster nodes called virtual nodes. The following figure illustrates
the basic idea of this approach.

![Scheme](Consistent-hashing.png)

This is an example of a cluster of 4 nodes. For each node, instead of adding one point on the ring, we add r points, called replicas. Replica ids are generated simply from the node id,
by concatenating the node id with 0, 1, …, r. For this example, r = 8, so each node will have 8 replicas in the ring. This way, node replicas will be interleaved and during dynamic topology:
- All the nodes will hand over a small amount of the instances they own to the new nodes in the cluster
- All the nodes will take over a small amount of the instances of a removed node previously owned

Therefore, node replicas maintain a properly load balanced cluster when dynamic topology changes occur.

Partition tolerance is achieved through the concept of reachability. A node can be seen as Unreachable, but still be part of the cluster and able to handle work. 
XComponent implemented a strategy in order to solve this problem of network partition / split brain by implementing a first strategy called Quorum. This strategy consists of downing unreachable
nodes if the number of reachable ones is greater than or equal to a minimum number of members in the cluster. This minimum number is defined by the user. This strategy works well when you are able
to define minimum required cluster size and when you have a cluster with fixed size of nodes or fixed size of nodes with specific role. 


In the `Hello World in Cluster Mode` sample, we're going to use the `Hello World` project and run two different pieces of software concurrently:
* **`[Hello World microservice]`** - A microservice launched in cluster mode (launching more than one node of XComponent runtime) that receives *say hello* requests 
* **`[Console Application]`** - A simple application to test our microservice

## Build the project

Execute the following script from the directory `xc.helloworld`:
```
PS > ./build.ps1
```

## Launch the microservice in cluster mode

In order to launch a microservice in cluster mode, we must launch nodes in the command line by using the executable of XComponent Runtime (XCRuntime) and configuring the cluster.
The main parameters used to configure the cluster are:
- clusterHost: the IP address of the cluster node. By default, it is set to 127.0.0.1
- clusterPort: the port of the cluster node
- clusterSeeds: The list of the other nodes of the cluster. This list is used so the current node can join the cluster. It expects a list of elements separated by semicolons. An element is in
the following form: seed_node_IP_address:seed_node_port.

Launch `Hello World` microservice in cluster mode by launching a cluster of 3 nodes

First node:
```
PS >  .\generated\XCRuntime\xcruntime.exe "xc.helloworld\Runtime\xcassemblies\helloworld-HelloMicroservice.xcr" -clusterPort 4035 -clusterSeeds "127.0.0.1:4035"
```
Second node:
```
PS >  .\generated\XCRuntime\xcruntime.exe "xc.helloworld\Runtime\xcassemblies\helloworld-HelloMicroservice.xcr" -clusterPort 4036 -clusterSeeds "127.0.0.1:4035"
```
Third node:
```
PS >  .\generated\XCRuntime\xcruntime.exe "xc.helloworld\Runtime\xcassemblies\helloworld-HelloMicroservice.xcr" -clusterPort 4037 -clusterSeeds "127.0.0.1:4035"
```

## Run the "Hello World" example for cluster mode

Execute the following script from the directory `xc.helloworld`:
```
PS > ./runForClusterExample.cmd
```
Enter a name in the displayed console and see the logs of the launched runtimes (3 launched nodes). You will see a message in green color displayed in the console of the owner node.
Entering a name in the console creates a new instance of the state machine `HelloWorldResponse`. This instance is created in the owner node and replicas of this instance are created in the other nodes
in order to handle the failover and to ensure the high availability.

If you kill a node from the launched nodes, you will see that the other nodes will down and remove the killed node from the cluster and they will share all the requests (instances) handled by the
removed node.

> Note: RabbitMQ has to be running (default configuration) 

## Questions?

If you have any questions about this sample, please [create a Github issue for us](https://github.com/xcomponent/xcomponent/issues)!