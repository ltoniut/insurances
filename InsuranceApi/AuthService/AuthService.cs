using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using InsuranceApi.Helpers;
using InsuranceApi.Models;
using InsuranceApi.Services.Clients;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace InsuranceApi.AuthServices
{
    public class AuthService : IAuthService
    {
        private readonly AppSettings _appSettings;
        private readonly IClientService c_service;

        public AuthService(IOptions<AppSettings> appSettings, IClientService clientService)
        {
            _appSettings = appSettings.Value;
            c_service = clientService;
        }

        public async Task<Client> Authenticate(string id)
        {
            Client client = await c_service.GetClientById(id);

            if (client == null)
                return null;

            var tokenHandler = new JwtSecurityTokenHandler();
            var securityKey = Encoding.ASCII.GetBytes(_appSettings.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, client.id),
                    new Claim(ClaimTypes.Role, client.role)
                }),
                Expires = DateTime.UtcNow.AddHours(2),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(securityKey), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            client.Token = tokenHandler.WriteToken(token);

            return client;
        }
    }
}
