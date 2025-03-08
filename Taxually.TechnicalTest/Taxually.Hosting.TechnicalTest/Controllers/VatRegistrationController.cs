using Microsoft.AspNetCore.Mvc;
using Taxually.Contracts.TechnicalTest;
using Taxually.TechnicalTest.Contracts;

namespace Taxually.TechnicalTest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VatRegistrationController : ControllerBase
    {
        public VatRegistrationController(IVatRegistrationFactory vatRegistrationFactory)
        {
            myVatRegistrationFactory = vatRegistrationFactory;
        }

        /// <summary>
        /// Registers a company for a VAT number in a given country
        /// </summary>
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] VatRegistrationRequest request)
        {
            try
            {
                IVatRegistration registractionComponent = myVatRegistrationFactory.CreateRegistrationComponent(request.Country);
                await registractionComponent.RegisterVatAsync(request);

                return Ok($"Successful VAT registration: {request.Country}");
            }
            catch (Exception)
            {
                return BadRequest($"Failed VAT registration: {request.Country}");
            }
        }

        private readonly IVatRegistrationFactory myVatRegistrationFactory;
    }
}
