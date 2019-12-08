using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using InsuranceApi.Models;
using Newtonsoft.Json;

namespace InsuranceApi.Services.Clients
{
    public class ClientService : IClientService
    {
        private readonly HttpClient _client;

        public ClientService(HttpClient client)
        {
            _client = client;
        }

        public async Task<Client> GetClientById(string id)
        {
            string json = await _client.GetStringAsync(Sources.clients);
            var clients = JsonConvert.DeserializeObject<HasClients>(json);

            var clientById = from c in clients.Clients
                             where Equals(c.id, id)
                             select c;
            return clientById.FirstOrDefault();
        }


        public async Task<Client> GetClientByName(string name)
        {
            string json = await _client.GetStringAsync(Sources.clients);
            var clients = JsonConvert.DeserializeObject<HasClients>(json);

            var clientByName = from c in clients.Clients
                             where Equals(c.name, name)
                             select c;
            return clientByName.FirstOrDefault();
        }

        public async Task<List<Policy>> GetPoliciesByClientName(string name)
        {
            string clientsJson, policiesJson;
            clientsJson = await _client.GetStringAsync(Sources.clients);policiesJson = await _client.GetStringAsync(Sources.policies);
            var clients = JsonConvert.DeserializeObject<HasClients>(clientsJson);
            var policies = JsonConvert.DeserializeObject<HasPolicies>(policiesJson);

            var policiesByClientName = from c in clients.Clients
                                       join p in policies.Policies
                                       on c.id equals p.clientId
                                       where Equals(c.name, name)
                                       select p;

            return policiesByClientName.ToList();
        }
    }
}
