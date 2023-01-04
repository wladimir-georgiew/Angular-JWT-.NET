using ArtCave.Data.Entities;
using ArtCave.Web.DTO.Login;
using ArtCave.Web.DTO.Registration;
using ArtCave.Web.JwtFeatures;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.IdentityModel.Tokens.Jwt;

namespace ArtCave.Web.Services.Account
{
    public class AccountService : IAccountService
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IMapper _mapper;
        private readonly JwtHandler _jwtHandler;

        public AccountService(UserManager<ApplicationUser> userManager, IMapper mapper, JwtHandler jwtHandler)
        {
            _userManager = userManager;
            _mapper = mapper;
            _jwtHandler = jwtHandler;
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

            await _userManager.AddToRoleAsync(user, Constants.Constants.IdentityRoles.FreeUser);

            return new UserRegistrationResponse { IsSuccessfulRegistration = true };
        }

        public async Task<UserLoginResponse> Login(UserLoginRequest request)
        {
            var user = await _userManager.FindByNameAsync(request.Email);

            if (user == null || !await _userManager.CheckPasswordAsync(user, request.Password))
                return new UserLoginResponse
                {
                    ErrorMessage = "Invalid username and/or password"
                };

            var signingCredentials = _jwtHandler.GetSigningCredentials();
            var claims = await _jwtHandler.GetClaimsAsync(user);
            var tokenOptions = _jwtHandler.GenerateTokenOptions(signingCredentials, claims);

            var token = new JwtSecurityTokenHandler().WriteToken(tokenOptions);

            return new UserLoginResponse 
            {
                IsAuthSuccessful = true,
                Token = token
            };
        }
    }
}
