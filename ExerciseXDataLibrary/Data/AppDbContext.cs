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
        public DbSet<Categories> Categories { get; set; }
        public DbSet<Diets> Diets { get; set; }
        public DbSet<Exercises> Exercises { get; set; }
        public DbSet<Foods> Foods { get; set; }
        public DbSet<Users> Users { get; set; }

        //Many to many tables
        public DbSet<UsersDiets> UsersDiets { get; set; }
        public DbSet<DietsFoods> DietsFoods { get; set; }
        public DbSet<UsersExercises> UsersExercises { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //One to many relationship
            modelBuilder.Entity<Exercises>()
                .HasOne(c => c.Categories)
                .WithMany()
                .HasForeignKey(c => c.C_Id);

            //UsersExercises junction table
            modelBuilder.Entity<UsersExercises>()
                .HasKey(ue => new { ue.U_Id, ue.E_Id });

            modelBuilder.Entity<UsersExercises>()
                .HasOne(ue => ue.Users)
                .WithMany(u => u.UsersExercises)
                .HasForeignKey(ue => ue.U_Id);

            modelBuilder.Entity<UsersExercises>()
                .HasOne(ue => ue.Exercises)
                .WithMany(e => e.UsersExercises)
                .HasForeignKey(ue => ue.E_Id);

            //UsersDiets junction table
            modelBuilder.Entity<UsersDiets>()
               .HasKey(ud => new { ud.U_Id, ud.D_Id });

            modelBuilder.Entity<UsersDiets>()
                .HasOne(u => u.Users)
                .WithMany(ud => ud.UsersDiets)
                .HasForeignKey(u => u.U_Id);

            modelBuilder.Entity<UsersDiets>()
                .HasOne(d => d.Diets)
                .WithMany(ud => ud.UsersDiets)
                .HasForeignKey(d => d.D_Id);

            //DietsFoods junction table
            modelBuilder.Entity<DietsFoods>()
                .HasKey(df => new { df.D_Id, df.F_Id });
            
            modelBuilder.Entity<DietsFoods>()
                .HasOne(d => d.Diets)
                .WithMany(df => df.DietsFoods)
                .HasForeignKey(d => d.D_Id);

            modelBuilder.Entity<DietsFoods>()
                .HasOne(f => f.Foods)
                .WithMany(df => df.DietsFoods)
                .HasForeignKey(f => f.F_Id);

        }   
    }
}
