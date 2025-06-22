using Microsoft.AspNetCore.Mvc;

namespace MediTrack.Areas.User.Controllers
{
    [Area("User")]
    [Route("api/[area]/[Controller]")]
    [ApiController]
   
    public class UserAuthController : Controller
    {
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(new {Message="This is User Area"});
        }
    }
}
