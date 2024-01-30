using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using TravelDeskWebApi.IRepo;
using TravelDeskWebApi.Model;
using TravelDeskWebApi.Repo;

namespace TravelDeskWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
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

        [HttpPost]
        public IActionResult Add(User user)
        {
            var result = _repo.Adduser(user);
            return result ? Ok() : StatusCode(StatusCodes.Status500InternalServerError);
        }

        [Route("manager")]
        public List<User> GetManagers()
        {
            return _repo.GetManagers();
        }
    }
}
