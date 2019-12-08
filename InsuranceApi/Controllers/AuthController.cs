using System.Threading.Tasks;
using InsuranceApi.AuthServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace InsuranceApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [AllowAnonymous]
        [HttpPost("[action]")]
        public async Task<IActionResult> Authenticate([FromBody]string id)
        {
            var client = await _authService.Authenticate(id);

            if (client == null)
            {
                return BadRequest(new { message = "Client id is incorrect" });
            }

            return Ok(client);
        }
    }
}
