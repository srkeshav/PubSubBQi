# PubSubBQi



Assumptions
1. We need to address different queues by names (they are stored in MessageBroker QueuePool)
2. MessageBroker will be singleton (implemented manually, instead of using DI Framework)




How to Run:
1. Install Visual Studio Community 2019 from VisualStudio website
2.




Questions
1. If the queue is full and has no subscriber and we add new items to Queue, what is the expected behaviour?
Will the older items be dequeued and new ones added?


























Extensible
We can have asynchronous implemenations in real-world scenarios
We can return bool/string while execution subscription or any other action to denote the progress of the method
We can create named or typed implementations of the Publisher class
Concurrent Dictionary can be used to make the implemenation thread-safe
Publisher can depend on a QueueProvider which can have any implementation underneath
Publisher can have a list of Queues which can contain different data based on Content or Topic
So, while adding data to a queue we can add data to a queue containing specific data type
While removing data from a queue, we can have an implemenation which removes data of a particular type

Questions:
1. Do we need to have any UI for the same or is it fine if I help the end-user go through the code?
2. Should the providers be using a queue pool from the MessageBroker or is it fine if they have their own queues?
3. Do we need to maintain a list of publishers? If we want to randomly refer any publisher amongst a list of publishers
we will have to give them some identity and maintain a list of publishers in the messagebroker. Do we want the identity
to be a string or Publisher of a specific Type
4. 