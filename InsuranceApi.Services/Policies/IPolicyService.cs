using System;
using System.Threading.Tasks;
using InsuranceApi.Models;

namespace InsuranceApi.Services.Policies
{
    public interface IPolicyService
    {
        Task<Client> GetPolicyClientByPolicyId(string id);
    }
}
