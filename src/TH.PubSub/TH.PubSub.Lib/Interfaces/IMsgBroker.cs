using System;
using System.Collections.Generic;

namespace TH.PubSub.Lib.Interfaces
{
    public interface IMsgBroker
    {
        ///Subscribe to a queue with an action that must be run when queue pushes a notification
        void Subscribe(Action<List<object>> calledAction, string queueName =  "default");
        ///UnSubscribe from the queue so that notifications sent by a queue are not received
        void UnSubscribe(Action<List<object>> calledAction, string queueName ="default");
        void PublishToQueue(object o, string queueName = "default");
    }
}
