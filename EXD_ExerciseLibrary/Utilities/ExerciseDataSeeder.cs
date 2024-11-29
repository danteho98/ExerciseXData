using ExerciseXData_ExerciseLibrary.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExerciseXData_ExerciseLibrary.Utilities
{
    public static class ExerciseDataSeeder
    {
        public static void SeedData(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CategoriesModel>().HasData(
                new CategoriesModel { C_Id = 1, C_Name = "Cardio", C_Modified_Date = DateTime.Now },
                new CategoriesModel { C_Id = 2, C_Name = "Strength", C_Modified_Date = DateTime.Now }
            );

            modelBuilder.Entity<ExercisesModel>().HasData(
                new ExercisesModel { E_Id = 1, E_Name = "Running", CategoriesC_Id = 1 },
                new ExercisesModel { E_Id = 2, E_Name = "Push-ups", CategoriesC_Id = 2 }
            );
        }
    }

}
