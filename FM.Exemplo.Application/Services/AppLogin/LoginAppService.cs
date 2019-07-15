using FM.Exemplo.Application.Interfaces.Entities;
using FM.Exemplo.Application.Services.AppLogin.Input;
using FM.Exemplo.Domain.Entities;
using FM.Exemplo.Domain.Interfaces.Entities;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace FM.Exemplo.Application.Services.AppLogin
{
    public class LoginAppService : ILoginAppService
    {
        private readonly IUserDomainService _userDomainService;
        private readonly IConfiguration _configuration;

        public LoginAppService
        (
            IUserDomainService userDomainService,
            IConfiguration configuration
        )
        {
            _userDomainService = userDomainService;
            _configuration = configuration;
        }
        public async Task<string> LoginAsync(LoginInput input)
        {
            var user = await _userDomainService.LoginAsync(input.Email, input.Password);

            if (user != null)
                return GenerateToken(user);

            return null;
        }

        private string GenerateToken(User user)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration.GetSection("ConfigurationJwt:Key").Value));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var claims = new[] {
                new Claim(JwtRegisteredClaimNames.Sub, user.Name),
                new Claim(JwtRegisteredClaimNames.Email, user.Email),
                new Claim(JwtRegisteredClaimNames.Jti, user.Id.ToString())
            };

            var token = new JwtSecurityToken(_configuration.GetSection("ConfigurationJwt:Issuer").Value,
                _configuration.GetSection("ConfigurationJwt:Issuer").Value,
                claims,
                expires: DateTime.Now.AddMinutes(120),
                signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
