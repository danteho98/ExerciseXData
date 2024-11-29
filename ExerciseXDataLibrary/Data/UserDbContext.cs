
using ExerciseXData_UserLibrary.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;



namespace ExerciseXData_UserLibrary.Data
{
    public class UserDbContext : IdentityDbContext<UsersModel>
    {
        public UserDbContext(DbContextOptions<UserDbContext> options) : base(options) {}
     

        protected override void OnModelCreating(ModelBuilder modelBuilder) 
        {
            base.OnModelCreating(modelBuilder); // Ensures the Identity configurations are applied
            

            //UsersModel
            modelBuilder.Entity<UsersModel>()
                .Property(u => u.U_UserGender)
                .HasConversion<string>(); // Convert enum to string in DB

            // Configure IdentityUser mappings if required
            modelBuilder.Entity<IdentityUser>()
                .HasIndex(iu => iu.Email)
                .IsUnique();

        }
    }
}
