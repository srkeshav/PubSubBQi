using System;
using System.Collections.Generic;
using TH.PubSub.Lib.Interfaces;

namespace TH.PubSub.Lib.Impl
{
    //TODO: Allow only a single object to be created of the MessageBroker
    public class MsgBroker : IMsgBroker
    {
        private Dictionary<string, List<Action<List<object>>>> actionDictionary;
        private Dictionary<string, BufferedQueue> queueDictionary;

        #region Singleton Initializer

        private static readonly Lazy<MsgBroker> lazy = new Lazy<MsgBroker>(() => new MsgBroker());
        public static MsgBroker Instance { get { return lazy.Value; } }

        #endregion

        #region Constructor

        private MsgBroker()
        {
            actionDictionary =
            new Dictionary<string, List<Action<List<object>>>>()
            {
                {"default", new List<Action<List<object>>>() }
            };

            var defaultQueue = new BufferedQueue("default", 5);
            defaultQueue.ReadyToPublish += QueuedItems_ReadyToPublish;
            queueDictionary = new Dictionary<string, BufferedQueue>()
            {
                {"default", new BufferedQueue("default", 5) }
            };
        }

        #endregion

        private void QueuedItems_ReadyToPublish(object sender, EventArgs e)
        {
            var queue = sender as BufferedQueue;
            var qname = queue.Name;
            if (actionDictionary.ContainsKey(qname) && actionDictionary[qname].Count > 0)
            {
                foreach (var action in actionDictionary[qname])
                {
                    var items = queue.FlushQueuedItems();
                    action(items);
                }
            }
            else
            {
                queue.WaitingToFlush = true;
            }
        }

        public void Subscribe(Action<List<object>> calledAction, string queueName = "default")
        {
            //If a queue being subscribed to does not exist, create it
            if (!queueDictionary.ContainsKey(queueName))
                InitializeQueue(queueName, 3);

            actionDictionary[queueName].Add(calledAction);

            //If Subscription Count was zero earlier and queued overflowed, we must check if queue
            //must publish items to the new subscriber
            var queue = queueDictionary[queueName];
            if (queue.WaitingToFlush)
            {
                var items = queue.FlushQueuedItems();
                calledAction(items);
                queue.WaitingToFlush = false;
            }
        }

        public void UnSubscribe(Action<List<object>> calledAction, string queueName = "default")
        {
            if (actionDictionary.ContainsKey(queueName))
            {
                var index = actionDictionary[queueName].FindIndex(x => x == calledAction);
                if (index != -1)
                    actionDictionary[queueName].RemoveAt(index);
            }
        }

        public void PublishToQueue(object o, string name = "default")
        {
            BufferedQueue queueToAddIn;
            if (queueDictionary.ContainsKey(name))
            {
                queueToAddIn = queueDictionary[name];
            }
            else
            {
                queueToAddIn = InitializeQueue(name, 3);
            }

            queueToAddIn.AddToQueue(o);
        }

        private BufferedQueue InitializeQueue(string name, int capacity)
        {
            var newQueue = new BufferedQueue(name, 3);
            newQueue.ReadyToPublish += QueuedItems_ReadyToPublish;
            queueDictionary.Add(name, newQueue);
            actionDictionary.Add(name, new List<Action<List<object>>>());
            return newQueue;
        }
    }
}
