using System;
using InsuranceApi.Models;
using InsuranceApi.Services.Policies;
using Xunit;

namespace InsuranceApiUnitTesting
{
    public class FindPolicyClientUnitTest
    {
        readonly string notExistingId = "false";
        readonly string existingId = "64cceef9-3a01-49ae-a23b-3761b604800b";

        private IPolicyService service = new PolicyService();

        [Fact]
        public async void ExistingIdShouldReturnClient()
        {
            Client actual = await service.GetPolicyClientByPolicyId(existingId);

            Assert.NotNull(actual);
        }

        [Fact]
        public async void NonExistingNameShouldReturnNull()
        {
            Client client = await service.GetPolicyClientByPolicyId(notExistingId);

            Assert.Null(client);
        }

        [Fact]
        public async void EmptyIdShouldReturnNull()
        {
            Client client = await service.GetPolicyClientByPolicyId("");

            Assert.Null(client);
        }
    }
}
