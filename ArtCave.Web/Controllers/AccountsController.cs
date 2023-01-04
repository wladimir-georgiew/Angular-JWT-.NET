using ArtCave.Data.Entities;
using ArtCave.Web.DTO.Login;
using ArtCave.Web.DTO.Registration;
using ArtCave.Web.JwtFeatures;
using ArtCave.Web.Services.Account;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.IdentityModel.Tokens.Jwt;

namespace ArtCave.Web.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AccountsController : ControllerBase
    {
        private readonly IAccountService _accountService;

        public AccountsController(IAccountService accountService)
        {
            _accountService = accountService;
        }

        [HttpPost("register")]
        public async Task<IActionResult> RegisterUser([FromBody] UserRegistrationRequest request)
        {
            if (request == null || !ModelState.IsValid)
                return BadRequest();

            var response = await _accountService.RegisterUserAsync(request);

            return response.IsSuccessfulRegistration
                ? Ok(response)
                : BadRequest(response);
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] UserLoginRequest request)
        {
            var response = await _accountService.Login(request);

            return response.IsAuthSuccessful
                ? Ok(response)
                : Unauthorized(response);
        }
    }
}
