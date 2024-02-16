using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using TravelDeskWebApi.Context;
using TravelDeskWebApi.IRepo;
using TravelDeskWebApi.Model;
using TravelDeskWebApi.ViewModel;

namespace TravelDeskWebApi.Repo
{
    public class UserRepo : IUserRepo
    {
        TravelDbContext _context;
        public UserRepo(TravelDbContext context)
        {
            _context = context;

        }

        public List<User> GetAllUsers()
        {
            
            return _context.Users.ToList();
        }

        public List<User> GetActiveUsers()
        {
            return _context.Users.Where(x=>x.IsActive==true).ToList();
        }

        public List<UserViewModel> GetViewUsers()
        {
            var query =
            (from user in _context.Users
             join manager in _context.Users on user.ManagerId equals manager.UserId
             join role in _context.Roles on user.RoleId equals role.RoleId
             join department in _context.Departments on user.DepartmentId equals department.DepartmentId
             where user.IsActive == true
             select new UserViewModel
             {
                 UserId = user.UserId,
                 FirstName = user.FirstName,
                 LastName = user.LastName,
                 RoleName = role.RoleName,
                 MangerName = manager.FirstName + " " + manager.LastName,
                 DepartmentName = department.DepartmentName,
             }).ToList();
            return query;
        }

        public bool CheckEmail(string email)
        {
            if(_context.Users.FirstOrDefault(x => x.Email == email) == null)
                return false;
            else
                return true;
        }

        public bool DeleteUser(int id)
        {
            var userToDelete = _context.Users.FirstOrDefault(x => x.UserId == id);
            if(userToDelete != null)
            {
                if(userToDelete.IsActive)
                {
                    userToDelete.IsActive = false;
                    _context.Update(userToDelete);
                    _context.SaveChanges();
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }

        public bool Adduser(User user)
        {

            try
            {
                user.CreatedOn = DateTime.Now;
                _context.Users.Add(user);
                _context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public List<User> GetManagers()
        {
            return _context.Users.Where(x => x.RoleId == 3 || x.RoleId == 1).ToList();
        }

        public async Task<bool> Edituser(User user)
        {
            if (user == null || user.UserId == 0)
                return false;

            var u = _context.Users.FirstOrDefault(x => x.UserId == user.UserId);
            if (u == null)
                return false;

            var pass = EncodePasswordToBase64(user.Password);
            u.FirstName = user.FirstName;
            u.LastName = user.LastName;
            u.Email = user.Email;
            u.MobileNumber = user.MobileNumber;
            u.Address = user.Address;
            u.Password = pass;
            u.UpdatedBy = 12;
            u.UpdatedOn = DateTime.Now;
            u.ManagerId = user.ManagerId;
            u.RoleId = user.RoleId;
            u.DepartmentId = user.DepartmentId;

            _context.Users.Update(u);
            await _context.SaveChangesAsync();
            return true;
        }

        public User GetUser(int id)
        {
            var u = _context.Users.FirstOrDefault(x => x.UserId == id);
            return u;
        }

        public static string EncodePasswordToBase64(string password)
        {
            try
            {
                byte[] encData_byte = new byte[password.Length];
                encData_byte = System.Text.Encoding.UTF8.GetBytes(password);
                string encodedData = Convert.ToBase64String(encData_byte);
                return encodedData;
            }
            catch (Exception ex)
            {
                throw new Exception("Error in base64Encode" + ex.Message);
            }
        }
        //this function Convert to Decord your Password
        public string DecodeFrom64(string encodedData)
        {
            System.Text.UTF8Encoding encoder = new System.Text.UTF8Encoding();
            System.Text.Decoder utf8Decode = encoder.GetDecoder();
            byte[] todecode_byte = Convert.FromBase64String(encodedData);
            int charCount = utf8Decode.GetCharCount(todecode_byte, 0, todecode_byte.Length);
            char[] decoded_char = new char[charCount];
            utf8Decode.GetChars(todecode_byte, 0, todecode_byte.Length, decoded_char, 0);
            string result = new String(decoded_char);
            return result;
        }
    }
}
