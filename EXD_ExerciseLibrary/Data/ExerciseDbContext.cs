using ExerciseXData_ExerciseLibrary.Models;
using ExerciseXData_ExerciseLibrary.Utilities;
using Microsoft.EntityFrameworkCore;

namespace ExerciseXData_ExerciseLibrary.Data
{
    public class ExerciseDbContext : DbContext
    {
        public ExerciseDbContext(DbContextOptions<ExerciseDbContext> options) : base(options) { }

        //public DbSet<UsersExercisesModel> UsersExercises { get; set; }
        public DbSet<ExercisesModel> Exercises { get; set; }
        public DbSet<CategoriesModel> Categories { get; set; }
        public DbSet<ExercisePlansModel> ExercisePlans { get; set; }
     

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

            modelBuilder.Entity<UsersExercisesModel>()
                .HasKey(ue => ue.UE_Id);

            modelBuilder.Entity<UsersExercisesModel>()
                .HasOne(ue => ue.User)
                .WithMany() // Avoid navigation property on ApplicationUser
                .HasForeignKey(ue => ue.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<UsersExercisesModel>()
                .HasOne(ue => ue.Exercise)
                .WithMany(e => e.UsersExercises)
                .HasForeignKey(ue => ue.E_Id)
                .OnDelete(DeleteBehavior.Cascade);


        }
    }
}
