using TH.PubSub.Lib.Interfaces;

namespace TH.PubSub.Lib.Impl
{
    public class Publisher : IPublisher
    {
        private readonly IMsgBroker _messageBroker;
        public Publisher()
        {
            _messageBroker = MsgBroker.Instance;
        }

        public void Publish(object obj, string queueName)
        {
            _messageBroker.PushToQueue(obj, queueName);
        }
    }
}
