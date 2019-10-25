# PubSubBQi


Assumptions
1. We need to address different queues by names (they are stored in MessageBroker QueuePool)
2. MessageBroker will be singleton (implemented manually, instead of using DI Framework)
3. Default buffer limit for 


How to Run:
1. Install Visual Studio Community 2019 from VisualStudio website
2.



Xtensibility:
Use ConcurrentDictionary for handling concurrency in multithreading scenarios
Use DependencyInjection to be able inject dependencies based on definition
Use Typed Queues instead of named queues for better type-safety
Instead of passing multiple parameters while PublishingToQueue, we can use a single dto object for 
improved encapsulation and maintenance
Refactor for better naming

