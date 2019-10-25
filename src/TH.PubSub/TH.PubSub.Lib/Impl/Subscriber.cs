using System;
using System.Collections.Generic;
using TH.PubSub.Lib.Interfaces;

namespace TH.PubSub.Lib.Impl
{
     public class Subscriber : ISubscriber
    {
        private readonly IMsgBroker _messageBroker;
        public Subscriber()
        {
            _messageBroker = MsgBroker.Instance;
        }

        //This method is private because we don't want to allow outside access to this method
        private void Execute(List<object> objs, string queueName)
        {
            //Specified queueName so that it becomes easier to test output
            Console.WriteLine($"Flushed From {queueName }");
            foreach (var obj in objs)
            {
                Console.Write(obj.ToString() + " ");
            }
            Console.WriteLine();
        }

        public void Subscribe(string queueName)
        {
            //Gliding calls here for business logic impl
            _messageBroker.Subscribe(Execute, queueName);
        }

        public void UnSubscribe(string queueName)
        {
            //Gliding calls here for business logic impl
            _messageBroker.UnSubscribe(Execute, queueName);
        }
    }
}
