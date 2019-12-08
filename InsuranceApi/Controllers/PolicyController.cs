using Microsoft.AspNetCore.Mvc;
using InsuranceApi.Models;
using Microsoft.AspNetCore.Authorization;
using InsuranceApi.Services.Policies;
using System.Threading.Tasks;

namespace InsuranceApi.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class PolicyController : ControllerBase
    {
        private IPolicyService _service;

        public PolicyController(IPolicyService service)
        {
            _service = service;
        }

        [Authorize(Roles = Role.Admin)]
        [HttpGet("{id}")]
        public async Task<Client> GetPolicyClient(string id)
        {
            return await _service.GetPolicyClientByPolicyId(id);
        }
    }
}
