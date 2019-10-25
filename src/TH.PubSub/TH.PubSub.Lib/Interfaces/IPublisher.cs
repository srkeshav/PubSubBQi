namespace TH.PubSub.Lib.Interfaces
{
    public interface IPublisher
    {
        void Publish(object obj, string queueName);
    }
}
