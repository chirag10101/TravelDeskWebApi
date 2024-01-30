using Microsoft.EntityFrameworkCore;
using TravelDeskWebApi.Model;

namespace TravelDeskWebApi.IRepo
{
    public interface IUserRepo
    {
        public bool Adduser(User user);

        public List<User> GetAllUsers();

        public List<User> GetManagers();
    }
}
