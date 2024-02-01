using Azure;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using System.Web.Http;
using TravelDeskWebApi.IRepo;
using TravelDeskWebApi.Model;
using HttpPostAttribute = Microsoft.AspNetCore.Mvc.HttpPostAttribute;
using RouteAttribute = Microsoft.AspNetCore.Mvc.RouteAttribute;

namespace TravelDeskWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class LoginController : ControllerBase
    {
        ILoginRepo _repo;

        private IConfiguration _config;

 

        public LoginController(ILoginRepo repo , IConfiguration config)
        {
            _repo = repo;
            _config = config;
        }

        [HttpPost]
        [AllowAnonymous]
        
        public IActionResult Login(Login login)
        {
            if (_repo.Login(login.Email, login.Password))
            {
                var tokenString = GenerateJSONWebToken(login);
                return Ok(new { token = tokenString });
            }
            else
            {
                return BadRequest();
            }

        }   

        private string GenerateJSONWebToken(Login user)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(_config["Jwt:Issuer"],
              _config["Jwt:Issuer"],
              null,
              expires: DateTime.Now.AddMinutes(120),
              signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

    }
}
