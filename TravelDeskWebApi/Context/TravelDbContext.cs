using Microsoft.EntityFrameworkCore;
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

    }
}
