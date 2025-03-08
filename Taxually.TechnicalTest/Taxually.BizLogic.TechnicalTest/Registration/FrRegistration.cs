using System.Text;
using Taxually.BizLogic.TechnicalTest.Clients;
using Taxually.TechnicalTest.Contracts;

namespace Taxually.BizLogic.TechnicalTest.Registration
{
    /// <summary>
    /// Registration component for France
    /// </summary>
    internal class FrRegistration : IVatRegistration
    {
        public async Task RegisterVatAsync(VatRegistrationRequest request)
        {
            // France requires an excel spreadsheet to be uploaded to register for a VAT number
            var csvBuilder = new StringBuilder();
            csvBuilder.AppendLine("CompanyName,CompanyId");
            csvBuilder.AppendLine($"{request.CompanyName}{request.CompanyId}");
            var csv = Encoding.UTF8.GetBytes(csvBuilder.ToString());
            var excelQueueClient = new TaxuallyQueueClient();
            
            // Queue file to be processed
            await excelQueueClient.EnqueueAsync("vat-registration-csv", csv);
        }
    }
}
