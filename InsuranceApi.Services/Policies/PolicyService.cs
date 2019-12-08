using System;
using System.Threading.Tasks;
using InsuranceApi.Models;
using Newtonsoft.Json.Linq;
using System.Net;
using System.Net.Http;
using System.Linq;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace InsuranceApi.Services.Policies
{
    public class PolicyService : IPolicyService
    {
        public async Task<Client> GetPolicyClientByPolicyId(string id)
        {
            var webClient = new HttpClient();
            string clientsJson = await webClient.GetStringAsync(Sources.clients);
            string policiesJson = await webClient.GetStringAsync(Sources.policies);
            var clients = JsonConvert.DeserializeObject<ClientsList>(clientsJson);
            var policies = JsonConvert.DeserializeObject<PoliciesList>(policiesJson);

            var policyClient = from c in clients.Clients
                               join p in policies.Policies
                               on c.id equals p.clientId
                               where p.id.Equals(id)
                               select c;
            return policyClient.FirstOrDefault();
        }
    }
}
