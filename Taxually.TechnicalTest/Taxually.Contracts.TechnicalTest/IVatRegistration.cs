namespace Taxually.TechnicalTest.Contracts
{
    /// <summary>
    /// Registration component for VAT numbers
    /// </summary>
    public interface IVatRegistration
    {
        /// <summary>
        /// Registers a company for a VAT number
        /// </summary>
        /// <param name="request"></param>
        public Task RegisterVATAsync(VatRegistrationRequest request);
    }
}
