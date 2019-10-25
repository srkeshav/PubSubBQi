namespace TH.PubSub.Lib.Interfaces
{
    interface ISubscriber
    {
        /// <summary>
        /// Subscribe to a queue to receive notifications
        /// </summary>
        void Subscribe(string queueName);

        /// <summary>
        /// Unsubscribe from a queue
        /// </summary>
        /// <param name="queueName"></param>
        void UnSubscribe(string queueName);
    }
}
