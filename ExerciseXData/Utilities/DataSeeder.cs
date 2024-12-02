
using ExerciseXData_UserLibrary.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace ExerciseXData.Utilities
{
    public static class DataSeeder
    {
        public static async Task SeedRoles(IServiceProvider serviceProvider)
        {
            var roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();

            if (!await roleManager.RoleExistsAsync("Admin"))
            {
                await roleManager.CreateAsync(new IdentityRole("Admin"));
            }
            if (!await roleManager.RoleExistsAsync("User"))
            {
                await roleManager.CreateAsync(new IdentityRole("User"));
            }
        }

        public static async Task SeedAdminAccount(IServiceProvider serviceProvider, IConfiguration configuration)
        {
            var userManager = serviceProvider.GetRequiredService<UserManager<UsersModel>>();
            //var roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();
            var adminEmail = "admin@example.com";

            // Ensure the Admin role exists
            var adminUser = await userManager.FindByEmailAsync(adminEmail);
            if (adminUser == null)
            {
                // Create the admin user
                var newAdmin = new UsersModel 
                { 
                    UserName = "Admin",
                    Email = adminEmail,
                    U_UserGender = UserGenderModel.Gender.PreferNotToSay, // Or as applicable
                    U_Age = 30,
                    U_Goal = "Maintain system"
                };

                var createResult = await userManager.CreateAsync(newAdmin, "Admin12345"); // Default password
                if (createResult.Succeeded)
                {
                    await userManager.AddToRoleAsync(newAdmin, "Admin");
                }
            }
        }
    }
}
