using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using InsuranceApi.Models;

namespace InsuranceApi.AuthServices
{
    public interface IAuthService
    {
        Task<Client> Authenticate(string id);
    }
}
