using System;
using System.Net.Http;
using InsuranceApi.Models;
using InsuranceApi.Services.Clients;
using Xunit;

namespace InsuranceApi.UnitTesting
{
    public class FindClientNameUnitTest
    {
        readonly string notExistingName = "notaname";
        readonly string existingName = "Britney";
        private HttpClient httpClient = new HttpClient();
        private readonly IClientService service;

        public FindClientNameUnitTest()
        {
            service = new ClientService(httpClient);
        }

        ~FindClientNameUnitTest()
        {
            httpClient.Dispose();
        }


        [Fact]
        public async void ExistingNameShouldReturnClient()
        {
            Type expectedType = typeof(Client);
            var client = await service.GetClientByName(existingName);

            Assert.NotNull(client);
        }

        [Fact]
        public async void NonExistingNameShouldReturnNull()
        {
            Type expected = typeof(Client);
            var client = await service.GetClientByName(notExistingName);

            Assert.Null(client);
        }

        [Fact]
        public async void EmptyNameShouldReturnNull()
        {
            Type expected = typeof(Client);
            var client = await service.GetClientByName("");

            Assert.Null(client);
        }
    }
}
