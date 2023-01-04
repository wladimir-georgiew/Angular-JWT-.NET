using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ArtCave.Web.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class StandsController : ControllerBase
    {

        public StandsController()
        {
        }

        [HttpGet("all")]
        [Authorize(Roles = Constants.Constants.IdentityRoles.Admin)]
        public IActionResult GetAllStands()
        {
            var mockStands = new List<string>()
            {
                "stand1",
                "stand2",
                "stand3",
                "stand4",
            };

            return Ok(mockStands);
        }
    }
}
