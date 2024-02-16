using Microsoft.EntityFrameworkCore;
using TravelDeskWebApi.Model;
using TravelDeskWebApi.ViewModel;

namespace TravelDeskWebApi.IRepo
{
    public interface IUserRepo
    {
        public bool Adduser(User user);

        public List<User> GetAllUsers();

        public List<User> GetActiveUsers();

        public  Task<bool> Edituser(User user);

        public List<User> GetManagers();

        public bool CheckEmail(string email);

        public List<UserViewModel> GetViewUsers();

        public bool DeleteUser(int id);

        public User GetUser(int id);
    }
}
