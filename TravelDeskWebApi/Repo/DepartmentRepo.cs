using TravelDeskWebApi.Context;
using TravelDeskWebApi.IRepo;
using TravelDeskWebApi.Model;

namespace TravelDeskWebApi.Repo
{

    public class DepartmentRepo :IDepartmentRepo
    {
        TravelDbContext _context;
        public DepartmentRepo(TravelDbContext context)
        {
            _context = context;

        }
        public List<Department> GetAllDepts()
        {
            return _context.Departments.ToList();
        }
    }
}
