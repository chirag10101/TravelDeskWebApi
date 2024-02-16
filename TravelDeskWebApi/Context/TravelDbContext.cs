using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using System.Collections.Generic;
using TravelDeskWebApi.Model;

namespace TravelDeskWebApi.Context
{
    public class TravelDbContext: DbContext
    {
        public TravelDbContext(DbContextOptions<TravelDbContext> options)
        : base(options) { }

        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<MealPreference> MealPreferences { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<TravelRequest> TravelRequests { get; set; }
        public DbSet<MealType> MealTypes { get; set; }
        public DbSet<Location> Locations { get; set; }
        public DbSet<Status> Status { get; set; }
        public DbSet<BookingType> BookingTypes { get; set; }
        public DbSet<FlightType> FlightTypes { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<BookingType>().HasData(
              new BookingType { BookingTypeId = 1, BookingTypeName = "Air Ticket Only" },
              new BookingType { BookingTypeId = 2, BookingTypeName = "Hotel Only" },
              new BookingType { BookingTypeId = 3, BookingTypeName = "Air Ticket and Hotel Both" }
            );
            builder.Entity<FlightType>().HasData(
              new FlightType {  FlightTypeId= 1, FlightTypeName = "Domestic" },
              new FlightType { FlightTypeId = 2, FlightTypeName = "International" }
            );
            builder.Entity<MealType>().HasData(
              new MealType { MealTypeId = 1, MealName = "Lunch" },
              new MealType { MealTypeId = 2, MealName = "Dinner" },
              new MealType { MealTypeId = 3, MealName = "Lunch and Dinner" }
            );
            builder.Entity<MealPreference>().HasData(
              new MealPreference { MealPreferenceId = 1, MealPreferenceName = "Veg" },
              new MealPreference { MealPreferenceId = 2, MealPreferenceName = "Non-Veg" }
            );
            builder.Entity<Project>().HasData(
              new Project { ProjectId = 1, ProjectName = "GBS-UK" },
              new Project { ProjectId = 2, ProjectName = "GBS-Malta" },
              new Project { ProjectId = 3, ProjectName = "GBS-Dubai" },
              new Project { ProjectId = 4, ProjectName = "Meta-Apply"}
            );
            builder.Entity<Status>().HasData(
              new Status { StatusId = 1, StatusName = "Pending" },
              new Status { StatusId = 2, StatusName = "Accepted" },
              new Status { StatusId = 3, StatusName = "Rejected" }
            );
            builder.Entity<Location>().HasData(
              new Location { LocationId = 1, City = "Noida", Country="India" },
              new Location { LocationId = 2, City = "Gurugram", Country="India" },
              new Location { LocationId = 3, City = "London", Country="UK" },
              new Location { LocationId = 4, City = "Valletta", Country="Malta" },
              new Location { LocationId = 5, City = "Dubai", Country="UAE" }
            );
            builder.Entity<Department>().HasData(
              new Department { DepartmentId = 1, DepartmentName = "IT" },
              new Department { DepartmentId = 2, DepartmentName = "HR" },
              new Department { DepartmentId = 3, DepartmentName = "Sales" },
              new Department { DepartmentId = 4, DepartmentName = "Accounts" }
            );

            builder.Entity<Role>().HasData(
              new Role { RoleId = 1, RoleName = "Admin" },
              new Role { RoleId = 2, RoleName = "Employee" },
              new Role { RoleId = 3, RoleName = "Manager" },
              new Role { RoleId = 4, RoleName = "HRTravelAdmin" }
            );

            builder.Entity<User>().HasData(
                new User { UserId = 1, FirstName = "Chirag", LastName = "Kapadiya", ManagerId = null, MobileNumber= "8080977727", Password= EncodePasswordToBase64("Chirag@123"), CreatedBy=1,
               Address="Noida", DepartmentId=1, RoleId=1, Email="ckkapadiya@geduservices.com", IsActive=true, CreatedOn= DateTime.Now},
                new User { UserId = 2, FirstName = "Animesh", LastName = "Pandey", ManagerId = 1, MobileNumber= "9873849999", Password= EncodePasswordToBase64("Animesh!123"), CreatedBy=1,
               Address="Delhi", DepartmentId=2, RoleId=3, Email="animesh@gmail.com", IsActive=true, CreatedOn= DateTime.Now},
                new User { UserId = 3, FirstName = "Saurav", LastName = "Tandon", ManagerId = 2, MobileNumber= "2378498883", Password=EncodePasswordToBase64("Saurav!1234"), CreatedBy=1,
               Address="Gurugram", DepartmentId=3, RoleId=2, Email="saurav@gmail.com", IsActive=true, CreatedOn= DateTime.Now},
                new User { UserId = 4, FirstName = "Priya", LastName = "Jaiswal", ManagerId = 2, MobileNumber= "9876545679", Password=EncodePasswordToBase64("Priya@123"), CreatedBy=1,
               Address="Pune", DepartmentId=3, RoleId=3, Email="priya@gmail.com", IsActive=true, CreatedOn= DateTime.Now}
                
            );
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
