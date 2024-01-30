using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TravelDeskWebApi.IRepo;
using TravelDeskWebApi.Model;

namespace TravelDeskWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentController : ControllerBase
    {
        IDepartmentRepo _repo;

        public DepartmentController(IDepartmentRepo repo)
        {
            _repo = repo;
        }

        public List<Department> Get()
        {
            return _repo.GetAllDepts();
        }
    }
}
