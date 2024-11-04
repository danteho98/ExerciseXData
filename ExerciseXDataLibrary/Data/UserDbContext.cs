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
    public class UserDbContext: DbContext
    {
        public UserDbContext(DbContextOptions<UserDbContext> options) : base(options) {}
        public DbSet<UsersModel> Users { get; set; }
        public DbSet<UsersCredentialsModel> UsersCredentials { get; set; }
        public DbSet<UsersDietsModel> UsersDiets { get; set; }
        public DbSet<UsersExercisesModel> UsersExercises { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder) 
        {
            //1 to many relationship to UsersCredentials
            modelBuilder.Entity<UsersModel>()
                .HasMany(u => u.UsersCredentials)
                .WithOne(uc => uc.Users)
                .HasForeignKey(uc => uc.U_Id);

            //UsersExercises junction table
            modelBuilder.Entity<UsersExercisesModel>()
                .HasKey(ue => ue.UE_Id);

            modelBuilder.Entity<UsersExercisesModel>()
                .HasOne(ue => ue.Users)
                .WithMany(u => u.UsersExercises)
                .HasForeignKey(ue => ue.U_Id);

            modelBuilder.Entity<UsersExercisesModel>()
                .HasOne(ue => ue.Exercises)
                .WithMany(e => e.UsersExercises)
                .HasForeignKey(ue => ue.E_Id);

            //UsersDiets junction table
            modelBuilder.Entity<UsersDietsModel>()
                   .HasKey(ud => ud.UD_Id);

            modelBuilder.Entity<UsersDietsModel>()
                    .HasOne(ud => ud.Users)
                    .WithMany(u => u.UsersDiets)
                    .HasForeignKey(ud => ud.U_Id);

            modelBuilder.Entity<UsersDietsModel>()
                    .HasOne(ud => ud.Diets)
                    .WithMany(d => d.UsersDiets)
                    .HasForeignKey(ud => ud.D_Id);
        }
    }
}
