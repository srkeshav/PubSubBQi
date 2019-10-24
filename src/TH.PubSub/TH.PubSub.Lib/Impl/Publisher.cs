using System;
using System.Collections.Generic;
using TH.PubSub.Lib.Interfaces;

namespace TH.PubSub.Lib.Impl
{
    internal class Publisher : IPublisher
    {
        public event EventHandler ReadyToPublish;
        private readonly string _name;
        private readonly int _size;
        public Queue<object> queue;
        public bool WaitingToFlush { get; set; }

        public Publisher(string name, int size)
        {
            _name = name;
            _size = size;
            queue = new Queue<object>(_size);
        }

        public void AddToQueue(object obj)
        {
            if (_size == queue.Count)
            {
                ReadyToPublish(this, EventArgs.Empty);
            }
            if(WaitingToFlush)
            {
                queue.Dequeue();
            }
            queue.Enqueue(obj);
        }

        public void ClearQueue()
        {
            queue.Clear();
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
    }
}
