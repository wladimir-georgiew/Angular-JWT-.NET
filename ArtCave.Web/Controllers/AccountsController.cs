using ArtCave.Data.Entities;
using ArtCave.Web.DTO.Registration;
using ArtCave.Web.Services.Account;
using Microsoft.AspNetCore.Mvc;

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
        public async Task<IActionResult> RegisterUser([FromBody] UserRegistrationRequest userRequestModel)
        {
            if (userRequestModel == null || !ModelState.IsValid)
                return BadRequest();

            var response = await _accountService.RegisterUserAsync(userRequestModel);

            return response.IsSuccessfulRegistration
                ? Ok(response)
                : BadRequest(response);
        }
    }
}
