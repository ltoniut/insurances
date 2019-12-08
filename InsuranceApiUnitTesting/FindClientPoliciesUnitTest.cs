using System;
using System.Collections.Generic;
using System.Net.Http;
using InsuranceApi.Models;
using InsuranceApi.Services.Clients;
using Xunit;

namespace InsuranceApiUnitTesting
{
    public class FindClientPoliciesUnitTest
    {
        readonly string britney = "Britney";
        readonly string lamb = "Lamb";
        readonly string notExistingName = "Lamb";
        private HttpClient httpClient = new HttpClient();
        private readonly IClientService service;

        public FindClientPoliciesUnitTest()
        {
            service = new ClientService(httpClient);
        }

        ~FindClientPoliciesUnitTest()
        {
            httpClient.Dispose();
        }


        [Fact]
        public async void BritneyShouldReturn102Policies()
        {
            List<Policy> list = await service.GetPoliciesByClientName(britney);

            int amount = list.Count;

            Assert.Equal(102, amount);
        }

        [Fact]
        public async void LambShouldReturnNoPolicies()
        {
            List<Policy> list = await service.GetPoliciesByClientName(lamb);

            int amount = list.Count;

            Assert.Empty(list);
        }

        [Fact]
        public async void NonExistingNameShouldReturnEmptyList()
        {
            List<Policy> list = await service.GetPoliciesByClientName(notExistingName);

            Assert.Empty(list);
        }

        [Fact]
        public async void EmptyStringNameShouldReturnEmptyList()
        {
            List<Policy> list = await service.GetPoliciesByClientName("");

            Assert.Empty(list);
        }
    }
}
