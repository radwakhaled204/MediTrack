using Microsoft.AspNetCore.Mvc;

namespace MediTrack.WebAPI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("api/[area]/[controller]")]
    [ApiController]

    public class AdminAuthController : Controller
    {


        [HttpGet]
        public IActionResult Get()
        {
            return Ok(new { Message = "This is Admin Area" });
        }
    }
}
