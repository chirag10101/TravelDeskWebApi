using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TravelDeskWebApi.Model
{
    public class User
    {
        
        public int UserId { get; set; }
        [Required]
        [MinLength(2)]
        [MaxLength(50)]
        [RegularExpression("[a-zA-Z ]+", ErrorMessage = "Only alphabets allowed")]
        public string FirstName { get; set; }
        [Required]
        [MinLength(2)]
        [MaxLength(50)]
        [RegularExpression("[a-zA-Z ]+", ErrorMessage = "Only alphabets allowed")]
        public string LastName { get; set; }
        public string? Address { get; set; }
        
        [Required]
        [RegularExpression("^(\\+\\d{1,3}[- ]?)?\\d{10}$")]
        public string MobileNumber { get; set; }

        [Required]
        [RegularExpression("^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\\.[a-zA-Z]{2,}$")]
        public string Email { get; set; }

        [Required]
        [RegularExpression("^(?=.*[a-z])(?=.*[A-Z])(?=.*\\d)(?=.*[@$!#%*?&])[A-Za-z\\d@$!%*#?&]{8,}$")]
        public string Password { get; set; }
        
        [Required]
        public int CreatedBy { get; set; }
        public int? UpdatedBy { get; set;} = null;

        [Required]
        public DateTime CreatedOn { get; set; } = DateTime.Now;
        public DateTime? UpdatedOn { get; set;}
        [Required]
        public bool IsActive { get; set; }
        [Required]
        public int RoleId { get; set; }

        [ForeignKey("RoleId")]
        public Role? Role { get; set; }

        [Required]
        public int DepartmentId { get; set; }

        [ForeignKey("DepartmentId")]
        public Department? Department { get; set; }

        public int? ManagerId { get; set; }
        [ForeignKey("ManagerId")]
        public User? Manager { get; set; }
    }
}
