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
            modelBuilder.Entity<Categories>()
                .HasMany(c => c.Exercises)
                .WithOne(e => e.Categories)
                .HasForeignKey(e => e.C_Id);

            //UsersExercises junction table
            modelBuilder.Entity<UsersExercises>()
                .HasKey(ue => ue.UE_Id);

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
               .HasKey(ud =>  ud.UD_Id );

            modelBuilder.Entity<UsersDiets>()
                .HasOne(ud => ud.Users)
                .WithMany(u => u.UsersDiets)
                .HasForeignKey(ud => ud.U_Id);

            modelBuilder.Entity<UsersDiets>()
                .HasOne(ud => ud.Diets)
                .WithMany(d => d.UsersDiets)
                .HasForeignKey(ud => ud.D_Id);

            //DietsFoods junction table
            modelBuilder.Entity<DietsFoods>()
                .HasKey(df => df.DF_Id );
            
            modelBuilder.Entity<DietsFoods>()
                .HasOne(df => df.Diets)
                .WithMany(d => d.DietsFoods)
                .HasForeignKey(df => df.D_Id);

            modelBuilder.Entity<DietsFoods>()
                .HasOne(df => df.Foods)
                .WithMany(f => f.DietsFoods)
                .HasForeignKey(df => df.F_Id);

        }   
    }
}
