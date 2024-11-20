
using ExerciseXData_UserLibrary.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;



namespace ExerciseXData_UserLibrary.Data
{
    public class UserDbContext : IdentityDbContext<IdentityUser>
    {
        public UserDbContext(DbContextOptions<UserDbContext> options) : base(options) {}
        public DbSet<UsersModel> Users { get; set; }
       
        //public DbSet<UsersDietsModel> UsersDiets { get; set; }
        //public DbSet<UsersExercisesModel> UsersExercises { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder) 
        {
            base.OnModelCreating(modelBuilder); // Ensures the Identity configurations are applied


            //UsersModel
            modelBuilder.Entity<UsersModel>()
                .Property(u => u.U_Gender)
                .HasConversion<string>(); // Convert enum to string in DB


           
        }
    }
}
