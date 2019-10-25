# PubSubBQi


Assumptions
1. We need to address different queues by names (they are stored in MessageBroker QueuePool)
2. MessageBroker will be singleton (implemented manually, instead of using DI Framework)



How to Run:
1. Install Visual Studio Community 2019 from VisualStudio website
2.



Xtensibility:
Use ConcurrentDictionary for handling concurrency in multithreading scenarios
Use DependencyInjection to be able inject dependencies based on definition
Use Typed Queues instead of named queues
Pass more parameters like type, capacity based on requirements

