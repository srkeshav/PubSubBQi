# PubSubBQi

Flow:
1. Create a publisher
2. Subscribe to publisher
2. Add message to publishers queue
3. Overflow the queue
4. Delete the publisher
5. Try adding message to the queue of the same publisher
6. Create new publisher
7. Add messages to publisher queue
8. Overflow the queue
9. Subscribe to the publisher

See, if it's possible to give the application a UI



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
Create Implementation of MessageBroker and Publisher
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
We can have asynchronous implemenations in real-world scenarios
We can return bool/string while execution subscription or any other action to denote the progress of the method
We can create named or typed implementations of the Publisher class
Concurrent Dictionary can be used to make the implemenation thread-safe
Publisher can depend on a QueueProvider which can have any implementation underneath
Publisher can have a list of Queues which can contain different data based on Content or Topic
So, while adding data to a queue we can add data to a queue containing specific data type
While removing data from a queue, we can have an implemenation which removes data of a particular type