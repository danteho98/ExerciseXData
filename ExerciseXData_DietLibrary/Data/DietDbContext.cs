using ExerciseXData_DietLibrary.Models;
using ExerciseXData_DietLibrary.Utilities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;

namespace ExerciseXData_DietLibrary.Data
{
    public class DietDbContext : DbContext
    {
        public DietDbContext(DbContextOptions<DietDbContext> options) : base(options) { }

        
        public DbSet<DietsModel> Diets { get; set; }
        public DbSet<FoodsModel> Foods { get; set; }
        public DbSet<UsersDietsModel> UsersDiets { get; set; }
        public DbSet<DietsFoodsModel> DietsFoods { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            DietDataSeeder.SeedData(modelBuilder);

            modelBuilder.Entity<DietsFoodsModel>()
                .HasKey(df => new { df.DietsD_Id, df.FoodsF_Id });  

            modelBuilder.Entity<DietsFoodsModel>()
                .HasOne(df => df.Diets)
                .WithMany(d => d.DietsFoods)
                .HasForeignKey(df => df.DietsD_Id)
                .OnDelete(DeleteBehavior.Cascade); // Optional, configure delete behavior

            modelBuilder.Entity<DietsFoodsModel>()
                .HasOne(df => df.Foods)
                .WithMany(f => f.DietsFoods)
                .HasForeignKey(df => df.FoodsF_Id);

            modelBuilder.Entity<UsersDietsModel>()
                .HasKey(ud => ud.UD_Id);

            modelBuilder.Entity<UsersDietsModel>()
                .HasOne(ud => ud.User)
                .WithMany() // Avoid navigation property on ApplicationUser
                .HasForeignKey(ud => ud.Id)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<UsersDietsModel>()
                .HasOne(ud => ud.Diet)
                .WithMany(/*d => d.UsersDiets*/)
                .HasForeignKey(ud => ud.D_Id)
                .OnDelete(DeleteBehavior.Cascade);

        }
    }
}
