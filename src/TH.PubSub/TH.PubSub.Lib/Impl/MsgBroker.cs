using System;
using System.Collections.Generic;
using TH.PubSub.Lib.Interfaces;

namespace TH.PubSub.Lib.Impl
{
    internal class MsgBroker : IMsgBroker
    {
        private readonly Dictionary<string, List<Action<List<object>, string>>> _actionDictionary;
        private readonly Dictionary<string, BufferedQueue> _queuePool;

        #region Singleton Initializer

        private static readonly Lazy<MsgBroker> lazy = new Lazy<MsgBroker>(() => new MsgBroker());
        public static MsgBroker Instance { get { return lazy.Value; } }

        #endregion

        #region Constructor

        private MsgBroker()
        {
            //Initialize Default queues, robustness of queueing s/m is MsgBroker's responsibility
            _actionDictionary =
            new Dictionary<string, List<Action<List<object>, string>>>()
            {
                {"default", new List<Action<List<object>, string>>() }
            };

            var defaultQueue = new BufferedQueue("default", 5);
            defaultQueue.ReadyToPublish += QueuedItems_ReadyToPublish;
            _queuePool = new Dictionary<string, BufferedQueue>()
            {
                {"default", defaultQueue }
            };
        }

        #endregion

        private void QueuedItems_ReadyToPublish(object sender, EventArgs e)
        {
            var queue = sender as BufferedQueue;
            var qname = queue.Name;
            if (_actionDictionary[qname].Count > 0)
            {
                foreach (var action in _actionDictionary[qname])
                {
                    var items = queue.FlushQueuedItems();
                    action(items, qname);
                }
            }
            else
            {
                queue.WaitingToFlush = true;
            }
        }

        public void Subscribe(Action<List<object>, string> calledAction, string queueName = "default")
        {
            //If a queue being subscribed to does not exist, create it
            if (!_queuePool.ContainsKey(queueName))
                InitializeQueue(queueName, 3);

            var existingSubscriptionIndex = _actionDictionary[queueName].FindIndex(x => x == calledAction);
            if (existingSubscriptionIndex != -1)
            {
              //Item already exists, do not subscribe twice  
                return;
            }

            _actionDictionary[queueName].Add(calledAction);

            //If Subscription Count was zero earlier and queued overflowed, we must check if queue
            //must publish items to the new subscriber
            var queue = _queuePool[queueName];
            if (queue.WaitingToFlush)
            {
                var items = queue.FlushQueuedItems();
                calledAction(items, queue.Name);
                queue.WaitingToFlush = false;
            }
        }

        public void UnSubscribe(Action<List<object>, string> calledAction, string queueName = "default")
        {
            if (_actionDictionary.ContainsKey(queueName))
            {
                var index = _actionDictionary[queueName].FindIndex(x => x == calledAction);
                if (index != -1)
                    _actionDictionary[queueName].RemoveAt(index);
            }
        }

        public void PushToQueue(object o, string queueName = "default")
        {
            BufferedQueue queueToAddIn;
            if (_queuePool.ContainsKey(queueName))
            {
                queueToAddIn = _queuePool[queueName];
            }
            else
            {
                queueToAddIn = InitializeQueue(queueName, 3);
            }
            queueToAddIn.EnQueue(o);
        }

        private BufferedQueue InitializeQueue(string queueName, int capacity)
        {
            var newQueue = new BufferedQueue(queueName, 3);
            newQueue.ReadyToPublish += QueuedItems_ReadyToPublish;
            _queuePool.Add(queueName, newQueue);
            _actionDictionary.Add(queueName, new List<Action<List<object>,string>>());
            return newQueue;
        }
    }
}
