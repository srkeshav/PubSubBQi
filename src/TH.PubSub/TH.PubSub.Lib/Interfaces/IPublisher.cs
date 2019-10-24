using System;

namespace TH.PubSub.Lib.Interfaces
{
    public interface IPublisher
    {
        event EventHandler ReadyToPublish;
    }
}
