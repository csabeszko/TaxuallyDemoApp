namespace Taxually.Contracts.TechnicalTest
{
    /// <summary>
    /// HTTP client for making requests to Taxually
    /// </summary>
    public interface ITaxuallyHttpClient
    {
        /// <summary>
        /// Makes a POST request to the specified URL with the given request object
        /// </summary>
        /// <typeparam name="TRequest"></typeparam>
        /// <param name="url"></param>
        /// <param name="request"></param>
        /// <returns></returns>
        Task PostAsync<TRequest>(string url, TRequest request);
    }
}
