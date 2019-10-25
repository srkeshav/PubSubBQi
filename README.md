# PubSubBQi
Assumptions
1. We need to address different queues by names (they are stored in MessageBroker QueuePool)
2. MessageBroker will be singleton (implemented manually, instead of using DI Framework)
3. Default buffer limit for default queue is 5
4. Subscribers cannot subscribe to same queue twice

How to Run:
1. Install Visual Studio Community 2019 from VisualStudio website
2. Download .NET desktop development workload
3. Open Visual Studio, select clone a project option
4. Clone the Project from Github to a local repository
5. Open the solution file
6. Run the TH.PubSub.UI.Con application and test



Xtensibility:
Write unit test cases
Use ConcurrentDictionary for handling concurrency in multithreading scenarios
Use DependencyInjection to be able inject dependencies based on definition
Use Typed Queues instead of named queues for better type-safety
Instead of passing multiple parameters while PublishingToQueue, we can use a single dto object for 
improved encapsulation and maintenance
Allow users to delete queues except Default Queue
Refactor for better naming

