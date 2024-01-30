using System.ComponentModel.DataAnnotations;

namespace TravelDeskWebApi.Model
{
    public class Department
    {
        public int DepartmentId { get; set; }
        [Required]
        public string DepartmentName { get; set; }

        public ICollection<User> Users { get; set; }

    }
}
