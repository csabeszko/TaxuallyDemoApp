using Taxually.BizLogic.TechnicalTest.Clients;
using Taxually.Contracts.TechnicalTest;
using Taxually.TechnicalTest.Contracts;

namespace Taxually.BizLogic.TechnicalTest.Registration
{
    /// <summary>
    /// Registration component for United Kingdom
    /// </summary>
    internal class GbRegistration : IVatRegistration
    {
        public GbRegistration(ITaxuallyHttpClient taxuallyHttpClient)
        {
            myTaxuallyHttpClient = taxuallyHttpClient;
        }

        public async Task RegisterVatAsync(VatRegistrationRequest request)
        {
            // UK has an API to register for a VAT number
            await myTaxuallyHttpClient.PostAsync(myUrl, request);
        }
        
        private readonly ITaxuallyHttpClient myTaxuallyHttpClient;
        private const string myUrl = "https://api.uktax.gov.uk";
    }
}
