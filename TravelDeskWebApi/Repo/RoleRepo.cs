using Microsoft.EntityFrameworkCore;
using TravelDeskWebApi.Context;
using TravelDeskWebApi.IRepo;
using TravelDeskWebApi.Model;

namespace TravelDeskWebApi.Repo
{
    public class RoleRepo : IRoleRepo
    {
        TravelDbContext _context;
        public RoleRepo(TravelDbContext context)
        {
            _context = context;
        }

        public List<Role> GetAllRoles()
        {
            return _context.Roles.ToList();
        }

        public Role GetRoleById(int id)
        {
            return _context.Roles.FirstOrDefault(x=>x.RoleId==id);
        }
    }
}
