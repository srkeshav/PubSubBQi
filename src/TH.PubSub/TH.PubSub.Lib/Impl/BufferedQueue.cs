using System;
using System.Collections.Generic;
using TH.PubSub.Lib.Interfaces;

namespace TH.PubSub.Lib.Impl
{
    class BufferedQueue : IItemQueue
    {
        public string Name { get; set; }
        public int BufferLimit { get; set; }
        public bool WaitingToFlush { get; set; }
        public event EventHandler ReadyToPublish;
        Queue<object> queue;

        public BufferedQueue(string name, int limit)
        {
            Name = name;
            BufferLimit = limit;
            queue = new Queue<object>();
        }

        public List<object> FlushQueuedItems()
        {
            var list = new List<object>();
            while (queue.Count > 0)
            {
                list.Add(queue.Dequeue());
            }
            return list;
        }

        public void EnQueue(object obj)
        {
            if (BufferLimit <= queue.Count && !WaitingToFlush)
            {
                ReadyToPublish(this, EventArgs.Empty);
            }

            queue.Enqueue(obj);
        }
    }
}
