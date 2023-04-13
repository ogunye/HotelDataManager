using HostelDataManagerShared.DataTransferObjects.UserDTO;
using Microsoft.AspNetCore.Identity;

namespace HostelDataManagerServiceContract
{
    public interface IAuthenticationService
    {
        Task<IdentityResult> RegistraterUser(UserForRegistrationDto userForRegistration);
        Task<bool> ValidateUser(UserForAuthenticationDto userForAuth);
        Task<TokenDto> CreateToken(bool populateExp);
        Task<TokenDto> RefreshToken(TokenDto tokenDto);
    }
}
