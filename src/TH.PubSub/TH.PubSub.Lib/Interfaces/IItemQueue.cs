using System;
using System.Collections.Generic;

namespace TH.PubSub.Lib.Interfaces
{
    interface IItemQueue
    {
        string Name { get; set; }
        int Capacity { get; set; }

        /// <summary>
        /// If the queue is full and has no subscriber, this flag is set so that
        /// whenever a new subscriber connects, the queue will flush.
        /// </summary>
        bool WaitingToFlush { get; set; }

        /// <summary>
        /// Fires when the queue is Ready To Publish, the logic can be encapsulated inside Queue class
        /// </summary>
        event EventHandler ReadyToPublish;

        /// <summary>
        /// Return the items in queue as a list of items and clear Queue
        /// </summary>
        List<object> FlushQueuedItems();

        void AddToQueue(object obj);
    }
}
