using TravelDeskWebApi.Context;
using TravelDeskWebApi.IRepo;

namespace TravelDeskWebApi.Repo
{
    public class LoginRepo :ILoginRepo
    {
        TravelDbContext _context;
        public LoginRepo(TravelDbContext context)
        {
            _context = context;

        }

        public bool Login(string email,string password)
        {
            var user = _context.Users.FirstOrDefault(u => u.Email == email);
            if ( user == null)
            {
                return false;
            }
            else
            {
                if(user.Password == password)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
    }
}
