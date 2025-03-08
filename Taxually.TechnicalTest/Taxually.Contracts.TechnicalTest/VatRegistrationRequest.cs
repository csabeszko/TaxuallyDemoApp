namespace Taxually.TechnicalTest.Contracts
{
    /// <summary>
    /// Represents a request to register a company for a VAT number
    /// </summary>
    public class VatRegistrationRequest
    {
        /// <summary>
        /// The name of the company
        /// </summary>
        public string? CompanyName { get; set; }

        /// <summary>
        /// The unique identifier of the company
        /// </summary>
        public string? CompanyId { get; set; }

        /// <summary>
        /// The country in which the company is registering for a VAT number
        /// </summary>
        public string? Country { get; set; }
    }
}
