using Taxually.Contracts.TechnicalTest;
using Taxually.TechnicalTest.Contracts;

namespace Taxually.BizLogic.TechnicalTest
{
    internal class VatRegistrationFactory : IVatRegistrationFactory
    {
        public VatRegistrationFactory(IEnumerable<IVatRegistration> registrationComponents)
        {
            myRegistrationComponents = registrationComponents.ToDictionary(reg => reg.GetType().Name.Replace("Registration", "").ToUpper(), reg => reg);
        }

        public IVatRegistration CreateRegistrationComponent(string countryCode)
        {
            if(!myRegistrationComponents.TryGetValue(countryCode, out var registrationComponent))
            {
                throw new InvalidOperationException($"No registration component found for country code: {countryCode}");
            }

            return registrationComponent;
        }

        private readonly IDictionary<string, IVatRegistration> myRegistrationComponents;
    }
}
