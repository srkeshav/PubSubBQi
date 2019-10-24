using System;
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
            broker = new MsgBroker();
            var publisher = broker.CreatePublisher("pub1", 5);

            for(int i = 0; i < 5; i++)
            {
                //broker.QueueToPublisher(publisher, i);
            }
        }

        private void ExecuteThis(object obj)
        {
            if (obj is string s)
            {
                Console.WriteLine(s);
            }
        }
    }
}
