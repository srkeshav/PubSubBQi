using System;
using System.Collections.Generic;
using TH.PubSub.Lib.Impl;
using TH.PubSub.Lib.Interfaces;

namespace TH.PubSub.UI.Con
{
    class Program
    {
        //This has to be a singleton
        private static IMsgBroker broker;
        static void Main(string[] args)
        {
            Program prg = new Program();

            //Create a Broker
            //broker = new MsgBroker();
            //var publisher = broker.CreatePublisher("pub1", 5);
            //broker.Subscribe(publisher, prg.ExecuteThis);

            //for (int i = 0; i < 5; i++)
            //{
            //    broker.AddToPublisherQueue(publisher, i);
            //}
            //broker.AddToPublisherQueue(publisher, 6);
            //broker.DeletePublisher(ref publisher);
            //try
            //{
            //    broker.AddToPublisherQueue(publisher, 1);
            //}
            //catch (Exception ex)
            //{
            //    Console.Write("Publisher not found");
            //    Console.WriteLine();
            //}

            ////var publisher2 = broker.CreatePublisher("pub2", 5);
            //for (int i = 0; i < 6; i++)
            //{
            //    broker.AddToPublisherQueue(publisher2, i);
            //}
            //broker.Subscribe(publisher2, prg.ExecuteThis);
            Console.ReadLine();
        }

        private void ExecuteThis(List<object> objs)
        {
            foreach (var obj in objs)
            {
                Console.Write(obj.ToString() + " ");
            }
            Console.WriteLine();
        }
    }
}
