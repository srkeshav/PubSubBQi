using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TH.PubSub.Lib.Interfaces;

namespace TH.PubSub.Lib.Impl
{
    public class MsgBroker : IMsgBroker
    {
        private Dictionary<IPublisher, List<Action<object>>> actionSet = new Dictionary<IPublisher, List<Action<object>>>();

        public Task<IPublisher> CreatePublisher(string name, int size)
        {
            //TODO: Xtensibility: We can maintain a list of publishers and ensure
            //two publishers don't have same property values
            IPublisher pub =  new Publisher(name, size);
            pub.ReadyToPublish += Pub_ReadyToPublish;
            return Task.FromResult(pub);
        }

        private void Pub_ReadyToPublish(object sender, EventArgs e)
        {
            //TODO: Convert the sender to publisher
            //TODO: Fire the queue elements to the subscribers of the publisher
        }

        public Task<bool> DeletePublisher(string name)
        {
            //TODO: Delete a publisher
            //TODO: If it is already present in the dictionary, remove all the items
            //TODO: remove it from dictionary and then dispose that object
            return Task.FromResult(true);
        }

        public Task<bool> Subscribe(IPublisher publisher, Action<object> calledAction)
        {
            //TODO: If publisher is disposed, it will be null, check if publisher is null
            //Subscribe to a publisher
            return Task.FromResult(true);
        }

        public Task<bool> UnSubscribe(IPublisher publisher, Action<object> calledAction)
        {
            
            //TODO: Unsubscribe from a publisher
            return Task.FromResult(true);
        }

        public Task<bool> AddToPublisherQueue(IPublisher publisher, object o)
        {
            publisher.AddToQueue(o);
            return Task.FromResult(true);
        }
    }
}
