using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using RecipeBook.Identity.Models;
using RecipeBook.Identity.Seeds;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeBook.Identity
{
    public class RecipeBookIdentityDbContext : IdentityDbContext<ApplicationUser>
    {




        public RecipeBookIdentityDbContext(DbContextOptions<RecipeBookIdentityDbContext> options) : base(options)
        {

        }



        protected override void OnModelCreating(ModelBuilder builder)
        {
            var applicationUser = new ApplicationUser()
            {
                FirstName = "Benjamin",
                LastName = "Benoit",
                UserName = "BenBenoit10",
                Email = "benoitbenjamin@hotmail.com",
                EmailConfirmed = true
            };

            PasswordHasher<ApplicationUser> ph = new PasswordHasher<ApplicationUser>();
            applicationUser.PasswordHash = ph.HashPassword(applicationUser, "Test123/*");
            builder.Entity<ApplicationUser>().HasData(applicationUser);

            base.OnModelCreating(builder);
        }
    }
}
