
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TravelDeskWebApi.IRepo;
using TravelDeskWebApi.Model;

namespace TravelDeskWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize]
    public class UserController : ControllerBase
    {
        IUserRepo _repo;

        public UserController(IUserRepo repo)
        {
            _repo = repo;
        }

        public List<User> Get()
        {
            return _repo.GetAllUsers();
        }

        [HttpGet("{id}")]
        public  User GetUserById(int id)
        {
                return  _repo.GetUser(id);
        }

        //[Route("Active")]
        //public List<User> GetActiveUsers()
        //{
        //    return _repo.GetActiveUsers();
        //}

        [Route("Active")]
        //[Authorize(Roles = "Admin, Manager")]
        public IActionResult GetViewUsers()
        {
            return Ok(_repo.GetViewUsers());
        }

        [HttpGet("delete/{id}")]
        public IActionResult DeleteUser(int id)
        {
            if (_repo.DeleteUser(id))
            {
                return Ok();
            }
            else
            {
                return NotFound();
            }
        }

        [HttpPost]
        public IActionResult Add(User user)
        {

            var result = _repo.Adduser(user);
            return result ? Ok() : StatusCode(StatusCodes.Status500InternalServerError);
        }

        [HttpPost("checkemail")]
        public bool CheckEmail(string email)
        {
            return _repo.CheckEmail(email);
        }

        [HttpPut("edit")]
        public async Task<IActionResult> Edituser(User user)
        {
            user.UpdatedOn = DateTime.Now;
            if (await _repo.Edituser(user))
                return Ok(); 
            else
                return NotFound();
        }

        [Route("manager")]
        public List<User> GetManagers()
        {
            return _repo.GetManagers();
        }
    }
}
