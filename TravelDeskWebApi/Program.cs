using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using TravelDeskWebApi.Context;
using TravelDeskWebApi.IRepo;
using TravelDeskWebApi.Repo;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.
        builder.Services.AddControllers();
        builder.Services.AddCors(options =>
        {
            options.AddPolicy("AllowOrigin", policy => policy.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
        });

        builder.Services.AddTransient<ILoginRepo, LoginRepo>();
        builder.Services.AddTransient<IRoleRepo, RoleRepo>();
        builder.Services.AddTransient<IUserRepo, UserRepo>();
        builder.Services.AddTransient<IDepartmentRepo, DepartmentRepo>();
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
                    ValidIssuer = "your_issuer",
                    ValidAudience = "your_audience",
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("your_secret_key"))
                };
            }); 

        var app = builder.Build();

        // Configure the HTTP request pipeline.
        app.UseAuthentication();
        app.UseAuthorization();
        app.UseCors("AllowOrigin");

        app.MapControllers();

        app.Run();
    }
}
