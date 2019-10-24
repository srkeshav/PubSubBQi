using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TH.PubSub.Lib.Interfaces;

namespace TH.PubSub.Lib.Impl
{
    //TODO: Allow only a single object to be created of the MessageBroker
    public class MsgBroker : IMsgBroker
    {
        //Xtensibility: If we want it to be used conccurrently, we will have to use ConccurrentDictionary
        private Dictionary<IPublisher, List<Action<List<object>>>> actionSet = 
            new Dictionary<IPublisher, List<Action<List<object>>>>();

        public IPublisher CreatePublisher(string name, int size)
        {
            //Xtensibility: We can maintain a list of publishers and ensure two publishers don't have same name
            IPublisher pub =  new Publisher(name, size);
            pub.ReadyToPublish += Pub_ReadyToPublish;
            return pub;
        }

        private void Pub_ReadyToPublish(object sender, EventArgs e)
        {
            var publisher = sender as Publisher;
            if (actionSet.ContainsKey(publisher) && actionSet[publisher].Count > 0)
            {
                foreach (var action in actionSet[publisher])
                {
                    var items = publisher.FlushQueuedItems();
                    action(items);
                }
            }
            else
            {
                publisher.WaitingToFlush = true;
            }
        }

        public void DeletePublisher(ref IPublisher publisher)
        {
            //We need to pass the publisher object as we are not maintaining a list of publishers in MessageBroker
            if(actionSet.ContainsKey(publisher))
            {
                //TODO: Remove the publisher before disposing it otherwise dictionary will throw exception
                actionSet.Remove(publisher);
            }
            publisher = null;
        }

        public void Subscribe(IPublisher publisher, Action<List<object>> calledAction)
        {
            if (publisher == null)
                throw new ArgumentNullException();

            if (actionSet.ContainsKey(publisher))
            {
                publisher.AddToQueue(calledAction);
            }
            else
            {
                actionSet.Add(publisher, new List<Action<List<object>>> { calledAction });
                if (publisher.WaitingToFlush)
                {
                    var items = publisher.FlushQueuedItems();
                    calledAction(items);
                    publisher.WaitingToFlush = false;
                }
            }
        }

        public void UnSubscribe(IPublisher publisher, Action<List<object>> calledAction)
        {
            if (publisher == null)
                throw new ArgumentNullException();

            if (actionSet.ContainsKey(publisher))
            {
                var index = actionSet[publisher].FindIndex(x => x == calledAction);
                if (index != -1)
                    actionSet[publisher].RemoveAt(index);
            }
        }

        public void AddToPublisherQueue(IPublisher publisher, object o)
        {
            if (publisher == null)
                throw new ArgumentNullException();
            publisher.AddToQueue(o);
        }
    }
}
