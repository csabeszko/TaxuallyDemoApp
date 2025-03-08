using Taxually.BizLogic.TechnicalTest.Clients;
using Taxually.TechnicalTest.Contracts;

namespace Taxually.BizLogic.TechnicalTest.Registration
{
    /// <summary>
    /// Registration component for United Kingdom
    /// </summary>
    internal class GbRegistration : IVatRegistration
    {
        public async Task RegisterVatAsync(VatRegistrationRequest request)
        {
            // UK has an API to register for a VAT number
            var httpClient = new TaxuallyHttpClient();

            await httpClient.PostAsync("https://api.uktax.gov.uk", request);
        }
    }
}
