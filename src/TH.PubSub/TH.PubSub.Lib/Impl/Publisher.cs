using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TH.PubSub.Lib.Interfaces;

namespace TH.PubSub.Lib.Impl
{
    internal class Publisher : IPublisher
    {
        public event EventHandler ReadyToPublish;
        private readonly string _name;
        private readonly int _size;
        private readonly Queue<object> queue;
        public  Publisher(string name, int size)
        {
            _name = name;
            _size = size;
            queue = new Queue<object>(_size);
        }

        public Task<bool> AddToQueue(object obj)
        {
            //Add Elements to Queue
            return Task.FromResult(true);
        }

        public Task<bool> ClearQueue()
        {
            queue.Clear();
            return Task.FromResult(true);
        }
    }
}
