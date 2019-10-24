using System;
using System.Threading.Tasks;

namespace TH.PubSub.Lib.Interfaces
{
    public interface IPublisher
    {
        event EventHandler ReadyToPublish;
        Task<bool> AddToQueue(Object obj);
        Task<bool> ClearQueue();
    }
}
