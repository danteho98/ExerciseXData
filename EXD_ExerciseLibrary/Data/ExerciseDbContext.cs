using ExerciseXData_ExerciseLibrary.Models;
using ExerciseXData_ExerciseLibrary.Utilities;
using ExerciseXData_UserLibrary.Models;
using Microsoft.EntityFrameworkCore;

namespace ExerciseXData_ExerciseLibrary.Data
{
    public class ExerciseDbContext : DbContext
    {
        public ExerciseDbContext(DbContextOptions<ExerciseDbContext> options) : base(options) { }

        public DbSet<UsersExercisesModel> UsersExercises { get; set; }
        public DbSet<ExercisesModel> Exercises { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            ExerciseDataSeeder.SeedData(modelBuilder);

            // Configure UsersExercisesModel
            modelBuilder.Entity<UsersExercisesModel>()
                .HasKey(ue => ue.UE_Id);

            modelBuilder.Entity<UsersExercisesModel>()
                .HasOne(ue => ue.Users)
                .WithMany() // Avoid navigation properties in UsersModel
                .HasForeignKey(ue => ue.U_Id);

            modelBuilder.Entity<UsersExercisesModel>()
                .HasOne(ue => ue.Exercises)
                .WithMany(e => e.UsersExercises)
                .HasForeignKey(ue => ue.E_Id);
        }
    }
}
