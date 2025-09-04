using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using MediTrack.Core.Interfaces;
using MediTrack.WebAPI.Dtos;

namespace MediTrack.WebAPI.Controllers
{
    
    [Route("api/[Controller]")]
    [ApiController]

    public class UserAuthController : ControllerBase
    {
        private readonly IUserAuthRepository _userAuthRepository;
        private readonly IJwtTokenService _servicesJwt;
        private readonly IDataRepository<Core.Models.User> _dataRepository;
        public UserAuthController(IUserAuthRepository userAuthRepository, IJwtTokenService servicesJwt, IDataRepository<Core.Models.User> dataRepository)
        {
            _userAuthRepository = userAuthRepository;
            _servicesJwt = servicesJwt;
            _dataRepository = dataRepository;
        }

        [HttpPost("loginUser")]
        public async Task<IActionResult> Login(LoginDto logindto)
        {
            var user = await _userAuthRepository.LoginUser(logindto.email, logindto.password);
            if (user == null)
            {
                return Unauthorized();
            }
            var claims = new[]
            {
            new Claim(ClaimTypes.NameIdentifier, user.UserId.ToString()),
            new Claim(ClaimTypes.Email, user.Email),
            new Claim(ClaimTypes.Name, user.UserName),
            new Claim(ClaimTypes.Role, "User")
            };
            var token = _servicesJwt.GenerateJWT(claims);
            return Ok(new { token });
        }
        [HttpPost("registerUser")]
        public async Task<IActionResult> Register(RegisterDto registerdto)
        {
            if (registerdto == null) { return BadRequest(); }
            registerdto.email = registerdto.email.ToLower();
            var userExist = await _userAuthRepository.IfUserExist(registerdto.email);
            if (userExist)
            {

                return BadRequest("User Already Exist");
            }
            var user = new Core.Models.User
            {
                Email = registerdto.email,
                UserName = registerdto.user_name,
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
