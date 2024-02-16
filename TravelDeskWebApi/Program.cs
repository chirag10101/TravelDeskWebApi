using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using System.Text.Json.Serialization;
using TravelDeskWebApi.Context;
using TravelDeskWebApi.IRepo;
using TravelDeskWebApi.Repo;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddControllers();
            builder.Services.AddCors(x => x.AddPolicy("AllowOrigin",options=>options.AllowAnyOrigin()
            .AllowAnyMethod()
            .AllowAnyHeader()));
            builder.Services.AddTransient<ILoginRepo,LoginRepo>();
            builder.Services.AddTransient<IRoleRepo, RoleRepo>();
            builder.Services.AddTransient<IUserRepo, UserRepo>();
            builder.Services.AddTransient<ITravelRequestRepo, TravelRequestRepo>();
            builder.Services.AddTransient<IDepartmentRepo, DepartmentRepo >();
            builder.Services.AddDbContext<TravelDbContext>(x => x.UseSqlServer(builder.Configuration["ConnectionStrings:DBCS"]));
            builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = "Test.com",
                    ValidAudience = "Test.com",
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("ThisismySecretKeyThisismySecretKeyThisismySecretKeyThisismySecretKey"))
                };
            });
            builder.Services.AddAuthorization();

        var app = builder.Build();

            app.UseCors("AllowOrigin");

            // Configure the HTTP request pipeline.
            app.UseAuthentication();
            app.UseAuthorization();
            
            
            

        app.MapControllers();

        app.Run();
    }
}
