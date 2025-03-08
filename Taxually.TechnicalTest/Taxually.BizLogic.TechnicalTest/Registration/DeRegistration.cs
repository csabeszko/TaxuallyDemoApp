using System.Xml.Serialization;
using Taxually.Contracts.TechnicalTest;
using Taxually.TechnicalTest.Contracts;

namespace Taxually.BizLogic.TechnicalTest.Registration
{
    /// <summary>
    /// Registration component for Germany
    /// </summary>
    internal class DeRegistration : IVatRegistration
    {
        public DeRegistration(ITaxuallyQueueClient taxuallyQueueClient)
        {
            myTaxuallyQueueClient = taxuallyQueueClient;
        }

        public async Task RegisterVatAsync(VatRegistrationRequest request)
        {
            // Germany requires an XML document to be uploaded to register for a VAT number
            using (var stringwriter = new StringWriter())
            {
                var serializer = new XmlSerializer(typeof(VatRegistrationRequest));
                serializer.Serialize(stringwriter, request);
                var xml = stringwriter.ToString();

                // Queue xml doc to be processed
                await myTaxuallyQueueClient.EnqueueAsync(myQueueName, xml);
            }
        }

        private readonly ITaxuallyQueueClient myTaxuallyQueueClient;
        private const string myQueueName = "vat-registration-xml";
    }
}
