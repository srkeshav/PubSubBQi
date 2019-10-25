using System;
using TH.PubSub.Lib.Impl;
using TH.PubSub.Lib.Interfaces;

namespace TH.PubSub.UI.Con
{
    class Program
    {
        static void Main(string[] args)
        {
            Program prg = new Program();
            prg.RunQueueingSystem();
        }

        private  void RunQueueingSystem()
        {
            var publisher = new Publisher();
            var subscriber = new Subscriber();
            AddItemsToQueueAfterSubscribing(publisher, subscriber, "test");
            AddItemsToQueueBeforeSubscribing(publisher, subscriber, "test");

            //Let's the console remain open until an input is made
            Console.ReadLine();
        }


        private void AddItemsToQueueAfterSubscribing(IPublisher publisher, ISubscriber subscriber,
            string queueName)
        {
            Console.WriteLine(nameof(AddItemsToQueueAfterSubscribing));
            subscriber.Subscribe(queueName);
            
            for(int i = 0; i < 10; i++)
            {
                publisher.Publish(i, queueName);
            }

            subscriber.UnSubscribe(queueName);

            Console.WriteLine();
        }

        private void AddItemsToQueueBeforeSubscribing(IPublisher publisher, ISubscriber subscriber,
            string queueName)
        {
            Console.WriteLine(nameof(AddItemsToQueueBeforeSubscribing));

            for (int i = 0; i < 10; i++)
            {
                publisher.Publish(i, queueName);
            }

            subscriber.Subscribe(queueName);

            Console.WriteLine();
        }
    }
}
