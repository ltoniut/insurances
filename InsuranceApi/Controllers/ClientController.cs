using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using InsuranceApi.Models;
using InsuranceApi.Services.Clients;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;

namespace InsuranceApi.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class ClientController : ControllerBase
    {
        private IClientService _service;

        public ClientController(IClientService service)
        {
            _service = service;
        }

        [HttpGet("{id}")]
        public async Task<Client> GetClientById(string id)
        {
            return await _service.GetClientById(id);
        }

        [HttpGet("name/{name}")]
        public async Task<Client> GetClientByName(string name)
        {
            return await _service.GetClientByName(name);
        }

        [Authorize(Roles = Role.Admin)]
        [HttpGet("{name}/policies")]
        public async Task<List<Policy>> GetPoliciesByClientName(string name)
        {
            return await _service.GetPoliciesByClientName(name);
        }
    }
}
