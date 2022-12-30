using ArtCave.Data.Entities;
using ArtCave.Web.DTO.Registration;
using AutoMapper;
using Microsoft.AspNetCore.Identity;

namespace ArtCave.Web.Services.Account
{
    public class AccountService : IAccountService
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IMapper _mapper;

        public AccountService(UserManager<ApplicationUser> userManager, IMapper mapper)
        {
            _userManager = userManager;
            _mapper = mapper;
        }

        public async Task<UserRegistrationResponse> RegisterUserAsync(UserRegistrationRequest userRequestModel)
        {
            var user = _mapper.Map<ApplicationUser>(userRequestModel);
            var result = await _userManager.CreateAsync(user, userRequestModel.Password);

            if (!result.Succeeded)
            {
                var errors = result.Errors.Select(e => e.Description);

                return new UserRegistrationResponse { Errors = errors };
            }

            return new UserRegistrationResponse { IsSuccessfulRegistration = true };
        }
    }
}
