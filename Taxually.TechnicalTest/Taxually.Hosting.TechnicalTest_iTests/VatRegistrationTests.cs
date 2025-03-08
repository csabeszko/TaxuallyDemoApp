using Microsoft.AspNetCore.Mvc.Testing;
using NUnit.Framework;
using System.Text;
using System.Text.Json;
using Taxually.TechnicalTest.Contracts;

namespace Taxually.Hosting.TechnicalTest_iTests
{
    [TestFixture]
    class VatRegistrationTests
    {
        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            myWebApplicationFactory = new WebApplicationFactory<Program>();
            myHttpClient = myWebApplicationFactory.CreateClient();
        }

        [OneTimeTearDown]
        public void OneTimeTearDown()
        {
            myHttpClient.Dispose();
            myWebApplicationFactory.Dispose();
        }

        [TestCase("DE")]
        [TestCase("FR")]
        [TestCase("GB")]
        public async Task RegisterVatAsync_RequestContainsAvailableCountryCode_AllRequestsAreSuccess(string countryCode)
        {
            //Arrange
            var vatRegistrationRequest = new VatRegistrationRequest 
            { 
                Country = countryCode,
                CompanyName = "CompanyName1",
                CompanyId = "CompanyId1"
            };
            var json = JsonSerializer.Serialize(vatRegistrationRequest);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            //Act
            var response =  await myHttpClient.PostAsync("api/vat/register", content);

            //Assert
            Assert.That(response.IsSuccessStatusCode, Is.True);
        }

        [TestCase("badCode")]
        public async Task RegisterVatAsync_RequestContainsNotSupportedCountryCode_ExceptionIsThrown(string countryCode)
        {
            //Arrange
            var vatRegistrationRequest = new VatRegistrationRequest
            {
                Country = countryCode,
                CompanyName = "CompanyName1",
                CompanyId = "CompanyId1"
            };
            var json = JsonSerializer.Serialize(vatRegistrationRequest);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            //Act
            var response = await myHttpClient.PostAsync("api/vat/register", content);

            //Assert
            Assert.That(response.IsSuccessStatusCode, Is.False);
        }

        private WebApplicationFactory<Program> myWebApplicationFactory;
        private HttpClient myHttpClient;
    }
}
