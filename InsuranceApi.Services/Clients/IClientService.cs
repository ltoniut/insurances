using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using InsuranceApi.Models;

namespace InsuranceApi.Services.Clients
{
    public interface IClientService
    {
        Task<Client> GetClientById(string id);
        Task<Client> GetClientByName(string id);
        Task<List<Policy>> GetPoliciesByClientName(string name);
    }
}