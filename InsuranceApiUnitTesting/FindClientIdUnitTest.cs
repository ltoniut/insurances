using System;
using System.Net.Http;
using InsuranceApi.Models;
using InsuranceApi.Services.Clients;
using Xunit;

namespace InsuranceApiUnitTesting
{
    public class FindClientIdUnitTest
    {
        readonly string notExistingId = "false";
        readonly string existingId = "a0ece5db-cd14-4f21-812f-966633e7be86";

        private HttpClient httpClient = new HttpClient();
        private readonly IClientService service;

        public FindClientIdUnitTest()
        {
            service = new ClientService(httpClient);
        }

        ~FindClientIdUnitTest()
        {
            httpClient.Dispose();
        }

        [Fact]
        public async void ExistingIdShouldReturnClient()
        {
            Type expected = typeof(Client);
            Client actual = await service.GetClientById(existingId);

            Assert.IsType(expected, actual);
        }

        [Fact]
        public async void NonExistingNameShouldNotReturnClient()
        {
            Type expected = typeof(Client);
            Client client = await service.GetClientById(notExistingId);

            Assert.IsNotType(expected, client);
        }

        [Fact]
        public async void NonExistingNameShouldReturnNull()
        {
            Client client = await service.GetClientById(notExistingId);

            Assert.Null(client);
        }

        [Fact]
        public async void EmptyIdShouldReturnNull()
        {
            Client client = await service.GetClientById("");

            Assert.Null(client);
        }
    }
}
