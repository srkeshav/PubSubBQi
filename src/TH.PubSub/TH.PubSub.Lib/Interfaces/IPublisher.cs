namespace TH.PubSub.Lib.Interfaces
{
    public interface IPublisher
    {
        void AddToQueue(object obj, string queueName);
    }
}
