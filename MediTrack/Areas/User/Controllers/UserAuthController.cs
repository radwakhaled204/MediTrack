using Microsoft.EntityFrameworkCore;
using MediTrack.Data;
using MediTrack.Dtos;
using MediTrack.Models;
using MediTrack.Services;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace MediTrack.Areas.User.Controllers
{
    [Area("User")]
    [Route("api/[area]/[Controller]")]
    [ApiController]
   
    public class UserAuthController : ControllerBase
    {
        private readonly IUserAuthRepository _userAuthRepository;
        private readonly IJwtTokenService _servicesJwt;
        private readonly IDataRepository<MediTrack.Models.User> _dataRepository;
        public UserAuthController(IUserAuthRepository userAuthRepository, IJwtTokenService servicesJwt , IDataRepository<MediTrack.Models.User> dataRepository)
        {
            _userAuthRepository = userAuthRepository;
            _servicesJwt = servicesJwt;
            _dataRepository = dataRepository;
        }

        [HttpPost("loginUser")]
        public async Task<IActionResult> Login (LoginDto logindto)
        {
            var user = await _userAuthRepository.LoginUser(logindto.email, logindto.password);
            if ( user == null)
            {
               return Unauthorized();
            }
            var claims = new[]
            {
            new Claim(ClaimTypes.NameIdentifier, user.user_id.ToString()),
            new Claim(ClaimTypes.Email, user.email),
            new Claim(ClaimTypes.Name, user.user_name),
            new Claim(ClaimTypes.Role, "User")
            };
            var token = _servicesJwt.GenerateJWT(claims);
            return Ok(new { token });
        }
        [HttpPost("registerUser")]
        public async Task<IActionResult> Register(RegisterDto registerdto)
        {
            if (registerdto == null) {  return BadRequest(); }
            registerdto.email = registerdto.email.ToLower();
            var userExist = await _userAuthRepository.IfUserExist(registerdto.email);
            if (userExist)
            {
                
                return BadRequest("User Already Exist");
            }
            var user = new MediTrack.Models.User
            {
                email = registerdto.email,
                user_name = registerdto.user_name,
                JoinedDate = DateTime.UtcNow,
            };
            await _userAuthRepository.RegisterUser(user, registerdto.password);
            return Ok(user);
        }
        [HttpPost("changepassword")]
        public async Task<IActionResult> ChangePassword(ChangePasswordDto changepassworddto)
        {
            
            if (changepassworddto == null)
            {
                return BadRequest("Enter Your Data");
            }
            var user = await _userAuthRepository.ChangePasswordForUser(changepassworddto.user_id, changepassworddto.old_password, changepassworddto.new_password);
            return Ok(user);
        }

    }
}
