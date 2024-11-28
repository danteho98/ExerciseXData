using ExerciseXData_DietLibrary.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExerciseXData_DietLibrary.Utilities
{
    public static class DietDataSeeder
    {
        public static void SeedData(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DietsModel>().HasData(
                new DietsModel { D_Id = 1, D_Name = "Keto Diet" },
                new DietsModel { D_Id = 2, D_Name = "Mediterranean Diet" }
            );

            modelBuilder.Entity<FoodsModel>().HasData(
                new FoodsModel { F_Id = 1, F_Name = "Avocado", F_Calories = 160 },
                new FoodsModel { F_Id = 2, F_Name = "Salmon", F_Calories = 208 }
            );
        }
    }

}
