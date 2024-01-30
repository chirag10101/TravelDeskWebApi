using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TravelDeskWebApi.IRepo;
using TravelDeskWebApi.Model;

namespace TravelDeskWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoleController : ControllerBase
    {

        IRoleRepo _repo;

        public RoleController(IRoleRepo repo)
        {
            _repo = repo;
        }

        public List<Role> Get()
        {
            return _repo.GetAllRoles();
        }
    }
}
