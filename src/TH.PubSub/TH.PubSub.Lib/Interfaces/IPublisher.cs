using System;
using System.Collections.Generic;

namespace TH.PubSub.Lib.Interfaces
{
    public interface IPublisher
    {
        event EventHandler ReadyToPublish;//TODO: Put Comments
        void AddToQueue(Object obj);//TODO: Put Comments
        void ClearQueue();//TODO: Put Comments
        /// <summary>
        /// Dequeue all items into a list of items
        /// </summary>
        List<object> FlushQueuedItems();
        bool WaitingToFlush { get; set; }
    }
}
