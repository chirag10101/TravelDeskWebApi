using System.ComponentModel.DataAnnotations;

namespace TravelDeskWebApi.Model
{
    public class Role
    {

        public int RoleId {  get; set; }

        [Required]
        public string RoleName { get; set; }
        
        public ICollection<User> Users { get; set; }
    }
}
