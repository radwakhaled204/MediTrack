using Microsoft.EntityFrameworkCore;
using MediTrack.Data;
using MediTrack.Dtos;
using MediTrack.Models;
using MediTrack.Services;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;

namespace MediTrack.Areas.User.Controllers
{
    [Area("User")]
    [Route("api/[area]/[Controller]")]
    [ApiController]
   
    public class UserAuthController : ControllerBase
    {
        private readonly IUserAuthRepository _userAuthRepository;
        private readonly IDataRepository<MediTrack.Models.User> _dataRepository;
        public UserAuthController(IUserAuthRepository userAuthRepository , IDataRepository<MediTrack.Models.User> dataRepository)
        {
            _userAuthRepository = userAuthRepository;
            _dataRepository = dataRepository;
        }
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(new { message= "this user area" });
        }

        
        
    }
}
