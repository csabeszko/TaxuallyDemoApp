namespace Taxually.Contracts.TechnicalTest
{
    /// <summary>
    /// Queue client for Taxually
    /// </summary>
    public interface ITaxuallyQueueClient
    {
        /// <summary>
        /// Enqueues a payload to the specified queue
        /// </summary>
        /// <typeparam name="TPayload"></typeparam>
        /// <param name="queueName"></param>
        /// <param name="payload"></param>
        /// <returns></returns>
        Task EnqueueAsync<TPayload>(string queueName, TPayload payload);
    }
}
