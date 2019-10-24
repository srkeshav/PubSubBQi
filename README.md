# PubSubBQi





TODO:
Create Interfaces for MessageBroker, CustomQueue, Publisher and Subscriber
While Subscribing, subscriber passes the action as an argument that must get executed when published
Subscriber can also unsubscribe from a Publisher.

IMessageBroker: Subscribe, UnSubscribe
IModQueue: event FireOnFull
IPublisher: Fires an event ReadyToPublish when the FireOnFull event is fired

Publisher will not have a dependency on ModQueue but a datastore which can be changed later on, as in the 
ModQueue will be named properly as ItemQueuer or something

There is going to be a flag associated with a Publisher which is going to decide whenever a subscriber subscribes to a particular
Publisher, should all the elements of the Queue for that Publisher be fired off and the ClearMessageStore method fired.






Done:
Read up on Publisher Subscriber/ Create Interface for contract
Add Projects


Multiple publishers are present in the system. 
--There is going to be a way to identify different publishers, some string or name
Publishers can publish to queues already present in the system or create a new queue if it needs
--All publishers will have a queue of their own of fixed sizes
--(Not required now)We can have an extensible implementation that makes the message broker contains the list of queues 
--objects that are available in the Queue Pool for usage rather than each publisher having it's own queue
Each queue has a fixed buffer size. Once it reaches the buffer size, it flushes it’s items to all the subscribers
--Queue can be allowed to fire events to which a publisher can respond by publishing it's messages
Multiple subscribers are present in the system
--There's not going to be any list of subscribers maintained separately, except by Message Broker'
Each subscriber can subscribe to one or multiple queues
--This is simply going to be an action/method that will be executed 
--One or multiple queues means publisher because a single publisher cannot have multiple queues (this must be cleared)
System allows publishers to send message of different types to the queue
--The queue will be of type object


Extensible
Publisher can depend on a QueueProvider which can have any implementation underneath
Publisher can have a list of Queues
