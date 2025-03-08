using System.Text;
using Taxually.Contracts.TechnicalTest;
using Taxually.TechnicalTest.Contracts;

namespace Taxually.BizLogic.TechnicalTest.Registration
{
    /// <summary>
    /// Registration component for France
    /// </summary>
    internal class FrRegistration : IVatRegistration
    {
        public FrRegistration(ITaxuallyQueueClient taxuallyQueueClient)
        {
            myTaxuallyQueueClient = taxuallyQueueClient;
        }

        public async Task RegisterVatAsync(VatRegistrationRequest request)
        {
            // France requires an excel spreadsheet to be uploaded to register for a VAT number
            var csvBuilder = new StringBuilder();
            csvBuilder.AppendLine("CompanyName,CompanyId");
            csvBuilder.AppendLine($"{request.CompanyName}{request.CompanyId}");
            var csv = Encoding.UTF8.GetBytes(csvBuilder.ToString());
            
            // Queue file to be processed
            await myTaxuallyQueueClient.EnqueueAsync(myQueueName, csv);
        }

        private readonly ITaxuallyQueueClient myTaxuallyQueueClient;
        private const string myQueueName = "vat-registration-csv";
    }
}
