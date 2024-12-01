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
                new DietsModel { D_Id = 2, D_Name = "Mediterranean Diet" },
                new DietsModel { D_Id = 3, D_Name = "Vegetarian Diet" }
            );

            modelBuilder.Entity<FoodsModel>().HasData(
                new FoodsModel { F_Id = 1, F_Name = "Avocado", F_Calories = 160 },
                new FoodsModel { F_Id = 2, F_Name = "Salmon", F_Calories = 208 },
                new FoodsModel { F_Id = 3, F_Name = "Broccoli ", F_Calories = 208 },
                new FoodsModel { F_Id = 4, F_Name = "Potato ", F_Calories = 161 },
                new FoodsModel { F_Id = 5, F_Name = "Brown rice", F_Calories = 216 },
                new FoodsModel { F_Id = 6, F_Name = "White rice", F_Calories = 205 },
                new FoodsModel { F_Id = 7, F_Name = "Tofu ", F_Calories = 76 },
                new FoodsModel { F_Id = 8, F_Name = "Egg", F_Calories = 72 },
                new FoodsModel { F_Id = 9, F_Name = "Beef steak ", F_Calories = 271 },
                new FoodsModel { F_Id = 10, F_Name = "Chicken breast ", F_Calories = 165},
                new FoodsModel { F_Id = 11, F_Name = "Beef steak ", F_Calories = 271 },
                new FoodsModel { F_Id = 12, F_Name = "Yogurt  ", F_Calories = 95 }
            );
        }
    }

}
