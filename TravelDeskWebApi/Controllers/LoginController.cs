using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TravelDeskWebApi.IRepo;
using TravelDeskWebApi.Model;

namespace TravelDeskWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        ILoginRepo _repo;

        public LoginController(ILoginRepo repo)
        {
            _repo = repo;
        }
        [HttpPost]
        public IActionResult Login(LoginUser user)
        {
            if(_repo.Login(user.Email, user.Password))
            {
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }
    }
}
