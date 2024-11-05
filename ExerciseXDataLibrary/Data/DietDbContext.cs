using ExerciseXData.Models;
using ExerciseXDataLibrary.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExerciseXDataLibrary.Data
{
    public class DietDbContext : DbContext
    {
        public DietDbContext(DbContextOptions<DietDbContext> options) : base(options) {}

        public DbSet<DietsModel> Diets { get; set; }
        public DbSet<FoodsModel> Foods { get; set; }
        public DbSet<DietsFoodsModel> DietsFoods { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //DietsFoods junction table
            modelBuilder.Entity<DietsFoodsModel>()
                .HasKey(df => df.DF_Id);

            modelBuilder.Entity<DietsFoodsModel>()
                    .HasOne(df => df.Diets)
                    .WithMany(d => d.DietsFoods)
                    .HasForeignKey(df => df.D_Id);

            modelBuilder.Entity<DietsFoodsModel>()
                    .HasOne(df => df.Foods)
                    .WithMany(f => f.DietsFoods)
                    .HasForeignKey(df => df.F_Id);
        }
    }
}