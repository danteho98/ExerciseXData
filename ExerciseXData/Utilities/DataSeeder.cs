using ExerciseXData_DietLibrary.Models;
using ExerciseXData_ExerciseLibrary.Models;
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
            var roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();

            // Ensure the Admin role exists
            if (!await roleManager.RoleExistsAsync("Admin"))
            {
                await roleManager.CreateAsync(new IdentityRole("Admin"));
            }

            // Check if the admin user exists
            var adminUser = await userManager.FindByEmailAsync("admin@example.com");
            if (adminUser == null)
            {
                // Create the admin user
                var newAdmin = new UsersModel
                {
                    UserName = "Admin",
                    Email = "admin@example.com",
                    U_UserGender = UserGender.Gender.PreferNotToSay, // Or as applicable
                    U_Age = 30,
                    
                    U_Goal = "Maintain system"
                };

                var createResult = await userManager.CreateAsync(newAdmin, "Admin@12345"); // Default password
                if (createResult.Succeeded)
                {
                    await userManager.AddToRoleAsync(newAdmin, "Admin");
                }
            }
        }
    }
}
