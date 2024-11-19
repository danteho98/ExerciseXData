
using ExerciseXDataLibrary.Models;
using Microsoft.EntityFrameworkCore;


namespace ExerciseXData_ExerciseLibrary.Data
{
    public class ExerciseDbContext : DbContext
    {
        public ExerciseDbContext(DbContextOptions<ExerciseDbContext> options) : base(options) {}
        public DbSet<CategoriesModel> Categories { get; set; }
        public DbSet<ExercisesModel> Exercises { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //One to many relationship
            modelBuilder.Entity<CategoriesModel>()
                .HasMany(c => c.Exercises)
                .WithOne(e => e.Categories)
                .HasForeignKey(e => e.C_Id);
        }
    }
}
