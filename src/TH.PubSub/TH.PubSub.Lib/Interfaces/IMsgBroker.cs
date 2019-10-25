using System;
using System.Collections.Generic;

namespace TH.PubSub.Lib.Interfaces
{
    public interface IMsgBroker
    {
        /// <summary>
        /// Subscribe to a queue with an action that must be run when queue pushes a notification
        /// </summary>
        void Subscribe(Action<List<object>, string> calledAction, string queueName =  "default");

        /// <summary>
        ///UnSubscribe from the queue so that notifications sent by a queue are not received
        /// </summary>
        void UnSubscribe(Action<List<object>, string> calledAction, string queueName ="default");

        /// <summary>
        /// Push To Queue or whatever implementation the messagebroker has for Queuing 
        /// </summary>
        void PushToQueue(object o, string queueName = "default");
    }
}
