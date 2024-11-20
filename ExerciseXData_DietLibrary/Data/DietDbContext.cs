using ExerciseXData_DietLibrary.Models;
using Microsoft.EntityFrameworkCore;

namespace ExerciseXData_DietLibrary.Data
{
    public class DietDbContext : DbContext
    {
        public DietDbContext(DbContextOptions<DietDbContext> options) : base(options) { }

        public DbSet<UsersDietsModel> UsersDiets { get; set; }
        public DbSet<DietsModel> Diets { get; set; }
        public DbSet<FoodsModel> Foods { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configure UsersDietsModel
            modelBuilder.Entity<UsersDietsModel>()
                .HasKey(ud => ud.UD_Id);

            modelBuilder.Entity<UsersDietsModel>()
                .HasOne(ud => ud.Diets)
                .WithMany(d => d.UsersDiets)
                .HasForeignKey(ud => ud.D_Id)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<UsersDietsModel>()
                .HasOne(ud => ud.Users) // Assumes Users property exists
                .WithMany() // No navigation in UsersModel
                .HasForeignKey(ud => ud.U_Id)
                .OnDelete(DeleteBehavior.Restrict); // Avoid cascading deletions
        }
    }
}
