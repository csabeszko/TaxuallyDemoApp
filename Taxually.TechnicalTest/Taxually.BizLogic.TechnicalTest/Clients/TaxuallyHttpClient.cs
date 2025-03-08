using Taxually.Contracts.TechnicalTest;

namespace Taxually.BizLogic.TechnicalTest.Clients
{
    internal class TaxuallyHttpClient : ITaxuallyHttpClient
    {
        public Task PostAsync<TRequest>(string url, TRequest request)
        {
            // Actual HTTP call removed for purposes of this exercise
            return Task.CompletedTask;
        }
    }
}
