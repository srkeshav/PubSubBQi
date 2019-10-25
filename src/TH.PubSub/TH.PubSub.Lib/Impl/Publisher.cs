using TH.PubSub.Lib.Interfaces;

namespace TH.PubSub.Lib.Impl
{
    internal class Publisher : IPublisher
    {
        private readonly IMsgBroker _messageBroker;
        public Publisher()
        {
            _messageBroker = MsgBroker.Instance;
        }

        public void AddToQueue(object obj, string queueName)
        {
            _messageBroker.PublishToQueue(obj, queueName);
        }
    }
}
