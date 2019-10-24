using System;
using System.Threading.Tasks;

namespace TH.PubSub.Lib.Interfaces
{
    public interface IMsgBroker
    {
        Task<IPublisher> CreatePublisher(string name, int size);
        Task<bool> DeletePublisher(string name);
        Task<bool> Subscribe(IPublisher publisher, Action<object> calledAction);
        Task<bool> UnSubscribe(IPublisher publisher, Action<object> calledAction);
        Task<bool> AddToPublisherQueue(IPublisher publisher, object o);
    }
}
