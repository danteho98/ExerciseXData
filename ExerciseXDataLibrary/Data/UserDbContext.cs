using ExerciseXData.Models;
using ExerciseXDataLibrary.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;


namespace ExerciseXDataLibrary.Data
{
    public class UserDbContext : IdentityDbContext<IdentityUser>
    {
        public UserDbContext(DbContextOptions<UserDbContext> options) : base(options) {}
        public DbSet<UsersModel> Users { get; set; }
       
        public DbSet<UsersDietsModel> UsersDiets { get; set; }
        public DbSet<UsersExercisesModel> UsersExercises { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder) 
        {
            base.OnModelCreating(modelBuilder); // Ensures the Identity configurations are applied


            //UsersModel
            modelBuilder.Entity<UsersModel>()
                .Property(u => u.U_Gender)
                .HasConversion<string>(); // Convert enum to string in DB


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
                .HasKey(ud => ud.UD_Id);

            modelBuilder.Entity<UsersDietsModel>()
                .HasOne(ud => ud.Users)
                .WithMany(u => u.UsersDiets)
                .HasForeignKey(ud => ud.U_Id)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<UsersDietsModel>()
                .HasOne(ud => ud.Diets)
                .WithMany(d => d.UsersDiets)
                .HasForeignKey(ud => ud.D_Id)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
