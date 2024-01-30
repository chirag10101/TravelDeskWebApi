using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using System.Text.Json;
using System.Text.Json.Serialization;
using TravelDeskWebApi.Context;
using TravelDeskWebApi.IRepo;
using TravelDeskWebApi.Model;

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
            //var jsonSerializerOptions = new JsonSerializerOptions
            //{
            //    ReferenceHandler = ReferenceHandler.Preserve
            //};
            //return _context.Users
            //    .Include(u => u.Role)
            //    .Include(u => u.Department)
            //    .AsEnumerable() // Switch to IEnumerable to allow circular references
            //.Select(user => JsonSerializer.Deserialize<User>(JsonSerializer.Serialize(user, jsonSerializerOptions), jsonSerializerOptions)).ToList();
            return _context.Users.ToList();


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
            return _context.Users.Where(x => x.RoleId == 3).ToList();
        }

        //public async Task<ActionResult<User>> Adduser(User user)
        //{
        //    try
        //    {

        //        _context.Users.Add(user);
        //        await _context.SaveChangesAsync();
        //        return Res;
        //    }
        //    catch (Exception ex)
        //    {
        //        return erro
        //    }

        //    return CreatedAtAction("GetTodoItem", new { id = todoItem.Id }, todoItem);
        //}
    }
}
