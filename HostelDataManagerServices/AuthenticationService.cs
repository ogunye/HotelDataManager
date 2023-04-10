using AutoMapper;
using HostelDataManagerApplication.CommonContracts;
using HostelDataManagerDomain.Entities;
using HostelDataManagerServiceContract;
using HostelDataManagerShared.DataTransferObjects.UserDTO;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
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

        public AuthenticationService(ILoggerManager logger, IMapper mapper,
            UserManager<User> userManager, IConfiguration configuration)
        {
            _logger = logger;
            _mapper = mapper;
            _userManager = userManager;
            _configuration = configuration;
        }

        public Task<string> CreateToken()
        {
            throw new NotImplementedException();
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

        public Task<bool> ValidateUser(UserForAuthenticationDto userForAuth)
        {
            throw new NotImplementedException();
        }
    }
}
