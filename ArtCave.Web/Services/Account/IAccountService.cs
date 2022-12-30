using ArtCave.Web.DTO.Registration;

namespace ArtCave.Web.Services.Account
{
    public interface IAccountService
    {
        Task<UserRegistrationResponse> RegisterUserAsync(UserRegistrationRequest userRequestModel);
    }
}
