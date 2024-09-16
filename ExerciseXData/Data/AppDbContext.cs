using ExerciseXData.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace ExerciseXData.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {
        }
 
            /*
         protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //UserExercise junction table
            modelBuilder.Entity<UserExercise>()
                .HasKey(userexercise => new { userexercise.U_Id, userexercise.E_Id });

            modelBuilder.Entity<UserExercise>()
                .HasOne(user => user.User)
                .WithMany(userexercise => userexercise.UserExercises)
                .HasForeignKey(user => user.U_Id);

            modelBuilder.Entity<UserExercise>()
                .HasOne(exercise => exercise.Exercise)
                .WithMany(userexercise => userexercise.UserExercises)
                .HasForeignKey(exercise => exercise.E_Id);

            //UserDiet junction table
            modelBuilder.Entity<UserDiet>()
               .HasKey(userdiet => new { userdiet.U_Id, userdiet.D_Id });

            modelBuilder.Entity<UserDiet>()
                .HasOne(user => user.User)
                .WithMany(userdiet => userdiet.UserDiets)
                .HasForeignKey(user => user.U_Id);

            modelBuilder.Entity<UserDiet>()
                .HasOne(diet => diet.User)
                .WithMany(userdiet => userdiet.UserDiets)
                .HasForeignKey(diet => diet.U_Id);

        }
        */
        
        public DbSet<Categories> Categories { get; set; }
        public DbSet<Diets> Diets { get; set; }
        public DbSet<Exercises> Exercises { get; set; }
        public DbSet<Foods> Foods { get; set; }
        public DbSet<Users> Users { get; set; }

        
        //Many to many tables
        public DbSet<UsersDiets> UserDiets { get; set; }
        public DbSet<DietsFoods> DietFoods { get; set; }
        public DbSet<UsersExercises> UserExercises { get; set; }
        

    }
}
