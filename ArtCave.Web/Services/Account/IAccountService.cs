using ArtCave.Web.DTO.Login;
using ArtCave.Web.DTO.Registration;

namespace ArtCave.Web.Services.Account
{
    public interface IAccountService
    {
        Task<UserLoginResponse> Login(UserLoginRequest request);
        Task<UserRegistrationResponse> RegisterUserAsync(UserRegistrationRequest userRequestModel);
    }
}
