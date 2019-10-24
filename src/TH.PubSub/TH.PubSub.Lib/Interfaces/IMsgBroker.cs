using System;
using System.Collections.Generic;

namespace TH.PubSub.Lib.Interfaces
{
    public interface IMsgBroker
    {
        /// <summary>
        /// Create a named Publisher that can maintain a queue of a specific size
        /// </summary>
        //Xtensibility: We can create publishers of a particular type
        IPublisher CreatePublisher(string name, int size);//TODO: Put Comments
        ///Delete a publisher (using publisher object, since messagebroker is not maintaining a list of publisher items)
        void DeletePublisher(ref IPublisher publisher);
        ///Subscribe to a publisher with an action that must be run when publisher pushes a notification
        void Subscribe(IPublisher publisher, Action<List<object>> calledAction);
        ///UnSubscribe from the publisher so that notifications sent by a publisher are not received
        void UnSubscribe(IPublisher publisher, Action<List<object>> calledAction);
        ///Add an element/ object to a publisher's queue
        void AddToPublisherQueue(IPublisher publisher, object o);//TODO: Put Comments
    }
}
