using ExerciseXData_ExerciseLibrary.Models;
using ExerciseXData_ExerciseLibrary.Utilities;
using Microsoft.EntityFrameworkCore;

namespace ExerciseXData_ExerciseLibrary.Data
{
    public class ExerciseDbContext : DbContext
    {
        public ExerciseDbContext(DbContextOptions<ExerciseDbContext> options) : base(options) { }

        public DbSet<CategoriesModel> Categories { get; set; }
        public DbSet<ExercisesModel> Exercises { get; set; }
        public DbSet<ExercisePlansModel> ExercisePlans { get; set; }
        public DbSet<ExercisePlanExercisesModel> ExercisePlanExercises { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            ExerciseDataSeeder.SeedData(modelBuilder);

            modelBuilder.Entity<CategoriesModel>()
                .ToTable("Categories");

            // Configure ExercisesModel
            modelBuilder.Entity<ExercisesModel>()
                .HasKey(e => e.E_Id); // Primary key for Exercises

            modelBuilder.Entity<ExercisesModel>()
                .HasOne(e => e.Categories) // Navigation property
                .WithMany(c => c.Exercises) // Many Exercises belong to one Category
                .HasForeignKey(e => e.CategoriesC_Id) // Foreign key in Exercises table
                .OnDelete(DeleteBehavior.Restrict); // Prevent cascading delete

            // Configure CategoriesModel
            modelBuilder.Entity<CategoriesModel>()
                .HasKey(c => c.C_Id); // Primary key for Categories

            modelBuilder.Entity<CategoriesModel>()
                .HasMany(c => c.Exercises) // Navigation property
                .WithOne(e => e.Categories) // One Category has many Exercises
                .HasForeignKey(e => e.CategoriesC_Id); // Foreign key in Exercises table

            modelBuilder.Entity<ExercisePlanExercisesModel>()
                .HasKey(epe => new { epe.ExercisePlanEP_Id, epe.ExercisesE_Id }); // Composite key (optional)

            modelBuilder.Entity<ExercisePlanExercisesModel>()
                .HasOne(epe => epe.ExercisePlan)
                .WithMany(ep => ep.ExercisePlanExercises) // Navigation property in ExercisePlansModel
                .HasForeignKey(epe => epe.ExercisePlanEP_Id)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<ExercisePlanExercisesModel>()
                .HasOne(epe => epe.Exercises)
                .WithMany(e => e.ExercisePlanExercises) // Navigation property in ExercisesModel
                .HasForeignKey(epe => epe.ExercisesE_Id)
                .OnDelete(DeleteBehavior.Restrict);


        }
    }
}
