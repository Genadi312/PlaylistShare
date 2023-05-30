using Microsoft.AspNetCore.Authorization;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using PlaylistShare.BL.Interfaces;
using PlaylistShare.DL.Models;
using PlaylistShare.Models.Models.Requests.AddRequests;

namespace PlaylistShare.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserInfoController : ControllerBase
    {
        private readonly IUserInfoService _userInfoService;
        private readonly IConfiguration _config;


        public UserInfoController(IUserInfoService userInfoService, IConfiguration config)
        {
            _userInfoService = userInfoService;
            _config = config;
        }

        [AllowAnonymous]
        [HttpPost("Add")]
        public async Task Add([FromBody] AddUserInfoRequest user)
        {
            await _userInfoService.Add(user);
        }

        [ProducesResponseType(StatusCodes.Status200OK,
            Type = typeof(Song))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpGet("Login")]
        [AllowAnonymous]
        public async Task<IActionResult> Login(string email, string password)
        {
            if (string.IsNullOrEmpty(email) ||
                string.IsNullOrEmpty(password))
                return BadRequest("Wrong e-mail and/or password");

            var user =
                await _userInfoService.GetUserInfoAsync(email, password);
            if (user != null)
            {
                var claims = new List<Claim>
                {
                    new Claim(JwtRegisteredClaimNames.Sub, _config.GetSection("Jwt:Subject").Value),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                    new Claim(JwtRegisteredClaimNames.Iat, DateTime.UtcNow.ToString()),
                    new Claim("UserId", user.Id.ToString()),
                    new Claim("DisplayName", user.Username ?? string.Empty),
                    new Claim("View", "Employee"),
                };

                var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
                var signIn = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
                var token = new JwtSecurityToken(
                    _config["Jwt:Issuer"],
                    _config["Jwt:Audience"],
                    claims,
                    expires: DateTime.UtcNow.AddMinutes(10),
                    signingCredentials: signIn);

                return Ok(new JwtSecurityTokenHandler().WriteToken(token));

            }

            else
            {
                return BadRequest("Wrong e-mail and/or password");
            }

        }
    }
}
