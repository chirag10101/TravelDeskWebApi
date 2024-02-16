using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.Data;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
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
        IUserRepo _userRepo;
        IRoleRepo _roleRepo;
        IDepartmentRepo _departmentRepo;
        private IConfiguration _config;

        public LoginController(ILoginRepo repo, IConfiguration config, IUserRepo userRepo, IRoleRepo roleRepo, IDepartmentRepo departmentRepo)
        {
            _repo = repo;
            _config = config;
            _userRepo = userRepo;
            _roleRepo = roleRepo;
            _departmentRepo = departmentRepo;
        }

        [HttpPost]
        [AllowAnonymous]
        public IActionResult Login(LoginUser loginUser)
        {
            var user = _repo.Login(loginUser);
            if (user!=null)
            {
                var tokenString = GenerateJSONWebToken(user);
                
                return Ok(new { token = tokenString });
            }
            else
            {
                return BadRequest();
            }

        }   

        private string GenerateJSONWebToken(User user)
        {
            var claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Sub, user.Email),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
            };
            string role= _roleRepo.GetRoleById((user.RoleId)).RoleName;
            string firstName = user.FirstName;
            string lastName = user.LastName;
            string departmentId = user.DepartmentId.ToString();
            int userId = user.UserId;
                //claims.Add(new Claim(ClaimTypes.Role, user.RoleId.ToString()));
            claims.Add(new Claim("role", role));
            claims.Add(new Claim(ClaimTypes.Role, role));
            claims.Add(new Claim("firstName", firstName));
            claims.Add(new Claim("lastName", lastName));
            claims.Add(new Claim("departmentId", departmentId));
            claims.Add(new Claim("userId",userId.ToString() ));

            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(_config["Jwt:Issuer"],
              _config["Jwt:Issuer"],
              claims,
              null,
              expires: DateTime.Now.AddMinutes(120),
              signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
