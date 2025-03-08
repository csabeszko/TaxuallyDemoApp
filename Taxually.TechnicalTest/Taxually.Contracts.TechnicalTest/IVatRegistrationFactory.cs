using Taxually.TechnicalTest.Contracts;

namespace Taxually.Contracts.TechnicalTest
{
    /// <summary>
    /// Factory for creating VAT registration components
    /// </summary>
    public interface IVatRegistrationFactory
    {
        /// <summary>
        /// Creates a registration component for a given country code
        /// </summary>
        /// <param name="countryCode"></param>
        /// <returns></returns>
        public IVatRegistration CreateRegistrationComponent(string countryCode);
    }
}
