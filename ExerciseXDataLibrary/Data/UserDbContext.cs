using ExerciseXData.Models;
using ExerciseXDataLibrary.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;


namespace ExerciseXDataLibrary.Data
{
    public class UserDbContext: IdentityDbContext<IdentityUser>
    {
        public UserDbContext(DbContextOptions<UserDbContext> options) : base(options) {}
        public DbSet<UsersModel> Users { get; set; }
        public DbSet<UsersCredentialsModel> UsersCredentials { get; set; }
        public DbSet<UsersDietsModel> UsersDiets { get; set; }
        public DbSet<UsersExercisesModel> UsersExercises { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder) 
        {
            base.OnModelCreating(modelBuilder); // Ensures the Identity configurations are applied

            modelBuilder.Entity<UsersCredentialsModel>()
                .Property(u => u.Cre_Id)
                .ValueGeneratedOnAdd();

            modelBuilder.Entity<UsersModel>()
                .Property(u => u.Gender)
                .HasConversion<string>(); // Convert enum to string in DB

            modelBuilder.Entity<UsersModel>()
                .HasIndex(u => u.U_Email)
                .IsUnique();

            //1 to many relationship to UsersCredentials
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
                .HasKey(ud => ud.UD_Id);

            modelBuilder.Entity<UsersDietsModel>()
                .HasOne(ud => ud.Users)
                .WithMany(u => u.UsersDiets)
                .HasForeignKey(ud => ud.U_Id);

            modelBuilder.Entity<UsersDietsModel>()
                .HasOne(ud => ud.Diets)
                .WithMany(d => d.UsersDiets)
                .HasForeignKey(ud => ud.D_Id);
        }
    }
}
