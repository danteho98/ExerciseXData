
using ExerciseXData_SharedLibrary.Enum;
using ExerciseXData_UserLibrary.Models;
using Microsoft.AspNetCore.Identity;
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
                    //U_UserGender = Gender.PreferNotToSay, // Or as applicable
                    U_Age = 30,
                    //FitnessGoal = FitnessGoal.Maintenance,
                    //U_ActivityLevel = ActivityLevel.Active, // Example activity level
                    DietaryPreferences = "Vegetarian", // Example dietary preference
                    //HealthConditions = new List<HealthCondition>
                    //{
                    //    HealthCondition.None // Example condition
                    //}, // Example health condition
                    //SleepPatterns = SleepPattern.NinePlus, // Example sleep pattern
                    ConsentToDataCollection = true, // Example consent
                    U_Created_Date = DateTime.UtcNow,
                    U_Last_Login = DateTime.UtcNow
                };

                var createResult = await userManager.CreateAsync(newAdmin, "Admin12345"); // Default password
                if (createResult.Succeeded)
                {
                    await userManager.AddToRoleAsync(newAdmin, "Admin");
                }
            }
        }

        public static async Task SeedUserAccount(IServiceProvider serviceProvider, IConfiguration configuration)
        {
            var userManager = serviceProvider.GetRequiredService<UserManager<UsersModel>>();
            var roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();

            // Check if the user exists
            var regularUser = await userManager.FindByEmailAsync("user@example.com");
            if (regularUser == null)
            {
                // Create the regular user
                var newUser = new UsersModel
                {
                    UserName = "User",
                    Email = "user@example.com",
                    //U_UserGender = Gender.Male,
                    U_Age = 25,
                    U_Height_CM = 175,  // Example height
                    U_Weight_KG = 68,    // Example weight
                    //FitnessGoal = FitnessGoal.GeneralHealth,
                    //U_ActivityLevel = ActivityLevel.Active, // Example activity level
                    DietaryPreferences = "Non-Vegetarian", // Example dietary preference
                    ////HealthConditions = new List<HealthCondition>
                    //{
                    //    HealthCondition.Diabetes // Example condition
                    //}, // Example health condition
                    //SleepPatterns = SleepPattern.NinePlus, // Example sleep pattern
                    ConsentToDataCollection = true, // Example consent
                    U_Created_Date = DateTime.UtcNow,
                    U_Last_Login = DateTime.UtcNow
                };

                var createResult = await userManager.CreateAsync(newUser, "User@12345"); // Default password
                if (createResult.Succeeded)
                {
                    await userManager.AddToRoleAsync(newUser, "User");
                }
            }
        }
    }
}
