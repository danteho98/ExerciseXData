using ExerciseXData.Models;
using ExerciseXDataLibrary.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace ExerciseXData.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options) 
        {
        }
        public DbSet<CategoriesModel> Categories { get; set; }
        public DbSet<DietsModel> Diets { get; set; }
        public DbSet<ExercisesModel> Exercises { get; set; }
        public DbSet<FoodsModel> Foods { get; set; }
        public DbSet<UsersModel> Users { get; set; }
        public DbSet<UsersCredentialsModel> UsersCredentials { get; set; }

        //Many to many tables
        public DbSet<UsersDietsModel> UsersDiets { get; set; }
        public DbSet<DietsFoods> DietsFoods { get; set; }
        public DbSet<UsersExercisesModel> UsersExercises { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //One to many relationship
            modelBuilder.Entity<CategoriesModel>()
                .HasMany(c => c.Exercises)
                .WithOne(e => e.Categories)
                .HasForeignKey(e => e.C_Id);

            modelBuilder.Entity<UsersModel>()
                .HasMany(u => u.UsersCredentials)
                .WithOne(uc => uc.Users)
                .HasForeignKey(uc => uc.U_Id);

            //UsersExercises junction table
            modelBuilder.Entity<UsersExercisesModel>()
                .HasKey(ue => ue.UE_Id);

            modelBuilder.Entity<UsersExercisesModel>()
                .HasOne(ue => ue.Users)
                .WithMany(u => u.UsersExercises)
                .HasForeignKey(ue => ue.U_Id);

            modelBuilder.Entity<UsersExercisesModel>()
                .HasOne(ue => ue.Exercises)
                .WithMany(e => e.UsersExercises)
                .HasForeignKey(ue => ue.E_Id);

            //UsersDiets junction table
            modelBuilder.Entity<UsersDietsModel>()
               .HasKey(ud =>  ud.UD_Id );

            modelBuilder.Entity<UsersDietsModel>()
                .HasOne(ud => ud.Users)
                .WithMany(u => u.UsersDiets)
                .HasForeignKey(ud => ud.U_Id);

            modelBuilder.Entity<UsersDietsModel>()
                .HasOne(ud => ud.Diets)
                .WithMany(d => d.UsersDiets)
                .HasForeignKey(ud => ud.D_Id);

            //DietsFoods junction table
            modelBuilder.Entity<DietsFoods>()
                .HasKey(df => df.DF_Id );
            
            modelBuilder.Entity<DietsFoods>()
                .HasOne(df => df.Diets)
                .WithMany(d => d.DietsFoods)
                .HasForeignKey(df => df.D_Id);

            modelBuilder.Entity<DietsFoods>()
                .HasOne(df => df.Foods)
                .WithMany(f => f.DietsFoods)
                .HasForeignKey(df => df.F_Id);

        }

        public static void SeedRolesAndUsers(IServiceProvider serviceProvider)
        {
            var roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();
            var userManager = serviceProvider.GetRequiredService<UserManager<IdentityUser>>();

            // Seed Admin Role
            if (!roleManager.RoleExistsAsync("Admin").Result)
            {
                roleManager.CreateAsync(new IdentityRole("Admin")).Wait();
            }

            // Seed User Role
            if (!roleManager.RoleExistsAsync("User").Result)
            {
                roleManager.CreateAsync(new IdentityRole("User")).Wait();
            }

            // Seed Admin User
            if (userManager.FindByEmailAsync("admin@example.com").Result == null)
            {
                IdentityUser user = new IdentityUser()
                {
                    UserName = "admin@example.com",
                    Email = "admin@example.com"
                };

                var result = userManager.CreateAsync(user, "Admin@123").Result;

                if (result.Succeeded)
                {
                    userManager.AddToRoleAsync(user, "Admin").Wait();
                }
            }
        }
    }
}
