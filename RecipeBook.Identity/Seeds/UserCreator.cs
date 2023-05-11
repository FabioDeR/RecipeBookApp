using Microsoft.AspNetCore.Identity;
using RecipeBook.Identity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeBook.Identity.Seeds
{
    public static class UserCreator
    {
        public static async Task SeedAsync(UserManager<ApplicationUser> userManager)
        {
            var applicationUser = new ApplicationUser()
            {
                FirstName = "Benjamin",
                LastName = "Benoit",
                UserName = "BenBenoit10",
                EmailConfirmed = true
            };

            var user = await userManager.FindByEmailAsync(applicationUser.Email);

            if (user == null)
            {
                await userManager.CreateAsync(applicationUser, "Test1234/*");
            }
        }
    }
}
