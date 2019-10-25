using System;
using System.Collections.Generic;
using System.Text;
using TH.PubSub.Lib.Interfaces;

namespace TH.PubSub.Lib.Impl
{
    class BufferedQueue : IItemQueue
    {
        public string Name { get; set; }
        public int Capacity { get; set; }
        public bool WaitingToFlush { get; set; }
        public event EventHandler ReadyToPublish;
        Queue<object> queue;

        public BufferedQueue(string name, int capacity)
        {
            Name = name;
            Capacity = capacity;
            queue = new Queue<object>(capacity);
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

        public void AddToQueue(object obj)
        {
            if (Capacity == queue.Count)
            {
                ReadyToPublish(this, EventArgs.Empty);
            }

            if (WaitingToFlush)
            {
                //There is no subscriber and queue is full, so remove old items and enqueue new ones
                queue.Dequeue();
            }

            queue.Enqueue(obj);
        }
    }
}
