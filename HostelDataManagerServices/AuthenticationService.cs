using AutoMapper;
using HostelDataManagerApplication.CommonContracts;
using HostelDataManagerDomain.Entities;
using HostelDataManagerServiceContract;
using HostelDataManagerShared.DataTransferObjects.UserDTO;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace HostelDataManagerServices
{
    internal sealed class AuthenticationService : IAuthenticationService
    {
        private readonly ILoggerManager _logger;
        private readonly IMapper _mapper;
        private readonly UserManager<User> _userManager;
        private readonly IConfiguration _configuration;

        private User _user;

        public AuthenticationService(ILoggerManager logger, IMapper mapper,
            UserManager<User> userManager, IConfiguration configuration)
        {
            _logger = logger;
            _mapper = mapper;
            _userManager = userManager;
            _configuration = configuration;
            //_user = user;

        }

        public async Task<string> CreateToken()
        {
            var signingCredentials = GetSigningCredentials();
            var claims = await GetClaims();
            var tokenOptions = GenerateTokenOptions(signingCredentials, claims);

            return new JwtSecurityTokenHandler().WriteToken(tokenOptions);
        }

        private JwtSecurityToken GenerateTokenOptions(SigningCredentials signingCredentials, List<Claim> claims)
        {
            var jwtSettings = _configuration.GetSection("jwtSettings");
            var tokenOptions = new JwtSecurityToken
                (
                    issuer: jwtSettings["validIssuer"],
                    audience: jwtSettings["validAudience"],
                    claims: claims,
                    expires: DateTime.Now.AddMinutes(Convert.ToDouble(jwtSettings["expires"])),
                    signingCredentials: signingCredentials
                );
            return tokenOptions;
        }

        private async Task<List<Claim>> GetClaims()
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, _user.UserName)
            };
            var roles = await _userManager.GetRolesAsync(_user);
            foreach (var role in roles)
            {
                claims.Add(new Claim(ClaimTypes.Role, role));
            }
            return claims;
        }

        private SigningCredentials GetSigningCredentials()
        {
            var key = Encoding.UTF8.GetBytes(Environment.GetEnvironmentVariable("SECRET") ?? "mydefaultkey");
            var secert = new SymmetricSecurityKey(key);

            return new SigningCredentials(secert, SecurityAlgorithms.HmacSha256);
        }

        public async Task<IdentityResult> RegistraterUser(UserForRegistrationDto userForRegistration)
        {
            var user = _mapper.Map<User>(userForRegistration);

            if (userForRegistration.Password == null )
            {
                throw new ArgumentNullException(nameof(userForRegistration.Password));
            }
                       
            var result = await _userManager.CreateAsync(user, userForRegistration.Password);

            if(userForRegistration.Roles == null || !userForRegistration.Roles.Any())
            {
                throw new ArgumentException("User must have at least one role", nameof(userForRegistration.Roles));
            }

            if (result.Succeeded)
            {
                await _userManager.AddToRoleAsync(user, userForRegistration.Roles.First());
            }
               

            return result;
        }

        public async Task<bool> ValidateUser(UserForAuthenticationDto userForAuth)
        {
            _user = await _userManager.FindByNameAsync(userForAuth.UserName);

            var result = false;
            if (_user != null && userForAuth.Password != null)
            {
                result = await _userManager.CheckPasswordAsync(_user, userForAuth.Password);
            }
            if (!result)
            {
                _logger.LogWarn($"{nameof(ValidateUser)}: Authentication process failed.");
            }
            return result;
        }
    }
}
