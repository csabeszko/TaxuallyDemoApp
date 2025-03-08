using System.Xml.Serialization;
using Taxually.BizLogic.TechnicalTest.Clients;
using Taxually.TechnicalTest.Contracts;

namespace Taxually.BizLogic.TechnicalTest.Registration
{
    /// <summary>
    /// Registration component for Germany
    /// </summary>
    internal class DeRegistration : IVatRegistration
    {
        public async Task RegisterVATAsync(VatRegistrationRequest request)
        {
            // Germany requires an XML document to be uploaded to register for a VAT number
            using (var stringwriter = new StringWriter())
            {
                var serializer = new XmlSerializer(typeof(VatRegistrationRequest));
                serializer.Serialize(stringwriter, request);
                var xml = stringwriter.ToString();
                var xmlQueueClient = new TaxuallyQueueClient();

                // Queue xml doc to be processed
                await xmlQueueClient.EnqueueAsync("vat-registration-xml", xml);
            }
        }
    }
}
