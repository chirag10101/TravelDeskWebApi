using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;
using TravelDeskWebApi.Context;
using TravelDeskWebApi.IRepo;
using TravelDeskWebApi.Repo;

namespace TravelDeskWebApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();

            //builder.Services.AddControllers().AddJsonOptions(x =>
            //    x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);

            builder.Services.AddCors(x => x.AddPolicy("AllowOrigin",options=>options.AllowAnyOrigin()
            .AllowAnyMethod()
            .AllowAnyHeader()));

            builder.Services.AddTransient<ILoginRepo,LoginRepo>();
            builder.Services.AddTransient<IRoleRepo, RoleRepo>();
            builder.Services.AddTransient<IUserRepo, UserRepo>();
            builder.Services.AddTransient<IDepartmentRepo, DepartmentRepo >();
            builder.Services.AddDbContext<TravelDbContext>(x => x.UseSqlServer(builder.Configuration["ConnectionStrings:DBCS"]));


            var app = builder.Build();

            // Configure the HTTP request pipeline.

            app.UseAuthorization();
            app.UseCors("AllowOrigin");


            app.MapControllers();

            app.Run();
        }
    }
}
