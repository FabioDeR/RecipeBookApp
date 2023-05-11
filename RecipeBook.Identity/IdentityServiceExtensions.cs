
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using RecipeBook.Application.Contracts.Identity;
using RecipeBook.Application.Models.Authentification;
using RecipeBook.Identity.Models;
using RecipeBook.Identity.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace RecipeBook.Identity
{
    public static class IdentityServiceExtensions
    {

        public static void AddIdentityServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<JwtSettings>(configuration.GetSection("JwtSettings"));

            services.AddDbContext<RecipeBookIdentityDbContext>(options => options.UseSqlServer(configuration.GetConnectionString("RecipeBookIdentityDBContextConnectionString"),
                b => b.MigrationsAssembly(typeof(RecipeBookIdentityDbContext).Assembly.FullName)));
            services.Configure<IdentityOptions>(options =>
            {
                options.Password.RequiredLength = 8;
                options.Password.RequireDigit = true;
                options.Password.RequireLowercase = true;
                options.Password.RequireUppercase = true;
                options.Password.RequireNonAlphanumeric = true;
                options.User.RequireUniqueEmail = true;
                options.SignIn.RequireConfirmedEmail = true;
                options.Tokens.EmailConfirmationTokenProvider = "emailconfirmation";
                options.User.AllowedUserNameCharacters =
                "abcdefghijklmnopqrstuvwxyzçABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-._@+";
            });
            services.AddIdentity<ApplicationUser,IdentityRole>()
                    .AddEntityFrameworkStores<RecipeBookIdentityDbContext>()
                    .AddDefaultTokenProviders();
            services.AddTransient<IAuthentificationService, AuthentificationService>();
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = true,
                        ValidateAudience = true,
                        ValidateLifetime = true,
                        ValidateIssuerSigningKey = true,
                        ValidIssuer = configuration["JwtSettings:Issuer"],
                        ValidAudience = configuration["JwtSettings:Audience"],
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["JwtSettings:Key"]))
                    };
                });
                }
    }
}
