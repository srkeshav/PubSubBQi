using System;
using System.Collections.Generic;

namespace TH.PubSub.Lib.Interfaces
{
    interface IItemQueue
    {
        string Name { get; set; }
        int BufferLimit { get; set; }

        /// <summary>
        /// If the bufferlimit is reached and the queue and has no subscriber, this flag is set so that
        /// whenever a new subscriber connects, the queue will flush.
        /// </summary>
        bool WaitingToFlush { get; set; }

        /// <summary>
        /// Fires when the queue reaches buffer limit and is Ready To Publish
        /// </summary>
        event EventHandler ReadyToPublish;

        /// <summary>
        /// Return the items in queue as a list of items and clear Queue
        /// </summary>
        List<object> FlushQueuedItems();

        /// <summary>
        /// Enqueue items to the queue
        /// </summary>
        void EnQueue(object obj);
    }
}
