using ExerciseXData_DietLibrary.Data;
using ExerciseXData_SharedLibrary.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExerciseXData_SharedLibrary.Data
{
    public class SharedDbContext : DbContext
    {
        public SharedDbContext(DbContextOptions<SharedDbContext> options) : base(options) { }

        public DbSet<UsersDietsModel> UsersDiets { get; set; }

        public DbSet<UsersExercisesModel> UsersExercises { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configure UsersDietsModel
            modelBuilder.Entity<UsersDietsModel>()
                .HasKey(ud => new { ud.U_Id, ud.D_Id });

            modelBuilder.Entity<UsersExercisesModel>()
                .HasKey(ue => ue.UE_Id);

        }
    }
}
