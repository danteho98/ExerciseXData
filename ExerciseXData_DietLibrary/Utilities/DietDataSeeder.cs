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
                new DietsModel { D_Id = 1, D_Name = "Mediterranean Diet" },
                new DietsModel { D_Id = 2, D_Name = "Keto Diet" },
                new DietsModel { D_Id = 3, D_Name = "Vegetarian Diet" }
            );

            modelBuilder.Entity<FoodsModel>().HasData(
                 new FoodsModel { F_Id = 1, F_Name = "Avocado", F_Group = "Fruit", F_Calories = 160 },
            new FoodsModel { F_Id = 2, F_Name = "Tofu", F_Group = "Protein", F_Calories = 94 },
            new FoodsModel { F_Id = 3, F_Name = "Lentils", F_Group = "Legume", F_Calories = 115 },
            new FoodsModel { F_Id = 4, F_Name = "Chickpeas", F_Group = "Legume", F_Calories = 135 },
            new FoodsModel { F_Id = 5, F_Name = "Quinoa", F_Group = "Grain", F_Calories = 222 },
            new FoodsModel { F_Id = 6, F_Name = "Spinach", F_Group = "Vegetable", F_Calories = 41 },
            new FoodsModel { F_Id = 7, F_Name = "Almonds", F_Group = "Nut", F_Calories = 160 },
            new FoodsModel { F_Id = 8, F_Name = "Sweet Potatoes", F_Group = "Vegetable", F_Calories = 112 },
            new FoodsModel { F_Id = 9, F_Name = "Broccoli", F_Group = "Vegetable", F_Calories = 55 },
            new FoodsModel { F_Id = 10, F_Name = "Carrots", F_Group = "Vegetable", F_Calories = 25 },
            new FoodsModel { F_Id = 11, F_Name = "Avocado Oil", F_Group = "Oil", F_Calories = 120 },
            new FoodsModel { F_Id = 12, F_Name = "Edamame", F_Group = "Legume", F_Calories = 120 },
            new FoodsModel { F_Id = 13, F_Name = "Chia Seeds", F_Group = "Seed", F_Calories = 138 },
            new FoodsModel { F_Id = 14, F_Name = "Cucumbers", F_Group = "Vegetable", F_Calories = 8 },
            new FoodsModel { F_Id = 15, F_Name = "Mushrooms", F_Group = "Vegetable", F_Calories = 35 },
            new FoodsModel { F_Id = 16, F_Name = "Greek Yogurt", F_Group = "Dairy", F_Calories = 100 }

            );

            modelBuilder.Entity<DietsFoodsModel>().HasData(
                new DietsFoodsModel
                {
                    DietsD_Id = 1, // Assuming Diet ID for Mediterranean Diet
                    FoodsF_Id = 1, // Food ID for Olive Oil
                    DF_Serving_Size = "1 tablespoon",
                    DF_Recommended_Servings = "2-3 servings/day",
                    DF_Frequency = "Daily",
                    DF_Total_Calories = 119,
                    DF_Modified_Date = DateTime.Now
                },

            // Example Diet-Food Pair 2: Fish (Salmon)
            new DietsFoodsModel
            {
                DietsD_Id = 1,
                FoodsF_Id = 2, // Food ID for Salmon
                DF_Serving_Size = "4 oz",
                DF_Recommended_Servings = "2-3 servings/week",
                DF_Frequency = "Weekly",
                DF_Total_Calories = 232,
                DF_Modified_Date = DateTime.Now
            },

            // Example Diet-Food Pair 3: Whole Grains (Quinoa)
            new DietsFoodsModel
            {
                DietsD_Id = 1,
                FoodsF_Id = 3, // Food ID for Quinoa
                DF_Serving_Size = "1 cup",
                DF_Recommended_Servings = "1-2 servings/day",
                DF_Frequency = "Daily",
                DF_Total_Calories = 222,
                DF_Modified_Date = DateTime.Now
            },

            // Example Diet-Food Pair 4: Vegetables (Spinach)
            new DietsFoodsModel
            {
                DietsD_Id = 1,
                FoodsF_Id = 4, // Food ID for Spinach
                DF_Serving_Size = "1 cup cooked",
                DF_Recommended_Servings = "1-2 servings/day",
                DF_Frequency = "Daily",
                DF_Total_Calories = 41,
                DF_Modified_Date = DateTime.Now
            },

            // Example Diet-Food Pair 5: Fruits (Berries)
            new DietsFoodsModel
            {
                DietsD_Id = 1,
                FoodsF_Id = 5, // Food ID for Berries (e.g., Blueberries, Strawberries)
                DF_Serving_Size = "1 cup",
                DF_Recommended_Servings = "1-2 servings/day",
                DF_Frequency = "Daily",
                DF_Total_Calories = 60,
                DF_Modified_Date = DateTime.Now
            },

            // Example Diet-Food Pair 6: Legumes (Chickpeas)
            new DietsFoodsModel
            {
                DietsD_Id = 1,
                FoodsF_Id = 6, // Food ID for Chickpeas
                DF_Serving_Size = "1/2 cup cooked",
                DF_Recommended_Servings = "3-4 servings/week",
                DF_Frequency = "Weekly",
                DF_Total_Calories = 134,
                DF_Modified_Date = DateTime.Now
            },

            // Example Diet-Food Pair 7: Nuts (Almonds)
            new DietsFoodsModel
            {
                DietsD_Id = 1,
                FoodsF_Id = 7, // Food ID for Almonds
                DF_Serving_Size = "1 ounce",
                DF_Recommended_Servings = "1-2 servings/day",
                DF_Frequency = "Daily",
                DF_Total_Calories = 160,
                DF_Modified_Date = DateTime.Now
            },

            // Example Diet-Food Pair 8: Herbs (Oregano)
            new DietsFoodsModel
            {
                DietsD_Id = 1,
                FoodsF_Id = 8, // Food ID for Oregano
                DF_Serving_Size = "1 teaspoon dried",
                DF_Recommended_Servings = "1-2 servings/day",
                DF_Frequency = "Daily",
                DF_Total_Calories = 3,
                DF_Modified_Date = DateTime.Now
            },

            // Example Diet-Food Pair 9: Yogurt (Greek Yogurt)
            new DietsFoodsModel
            {
                DietsD_Id = 1,
                FoodsF_Id = 9, // Food ID for Greek Yogurt
                DF_Serving_Size = "1/2 cup",
                DF_Recommended_Servings = "1-2 servings/day",
                DF_Frequency = "Daily",
                DF_Total_Calories = 100,
                DF_Modified_Date = DateTime.Now
            },

            // Example Diet-Food Pair 10: Wine (Red Wine)
            new DietsFoodsModel
            {
                DietsD_Id = 1,
                FoodsF_Id = 10, // Food ID for Red Wine
                DF_Serving_Size = "5 oz",
                DF_Recommended_Servings = "1 serving/day",
                DF_Frequency = "Daily",
                DF_Total_Calories = 125,
                DF_Modified_Date = DateTime.Now
            },

            // Example Diet-Food Pair 1: Avocados
            new DietsFoodsModel
            {
                DietsD_Id = 2, // Assuming Diet ID for Keto Diet
                FoodsF_Id = 1, // Food ID for Avocados
                DF_Serving_Size = "1/2 avocado",
                DF_Recommended_Servings = "1 serving/day",
                DF_Frequency = "Daily",
                DF_Total_Calories = 160,
                DF_Modified_Date = DateTime.Now
            },

            // Example Diet-Food Pair 2: Eggs
            new DietsFoodsModel
            {
                DietsD_Id = 2,
                FoodsF_Id = 2, // Food ID for Eggs
                DF_Serving_Size = "1 large egg",
                DF_Recommended_Servings = "3-4 servings/day",
                DF_Frequency = "Daily",
                DF_Total_Calories = 72,
                DF_Modified_Date = DateTime.Now
            },

            // Example Diet-Food Pair 3: Chicken
            new DietsFoodsModel
            {
                DietsD_Id = 2,
                FoodsF_Id = 3, // Food ID for Chicken
                DF_Serving_Size = "4 oz",
                DF_Recommended_Servings = "1-2 servings/day",
                DF_Frequency = "Daily",
                DF_Total_Calories = 187,
                DF_Modified_Date = DateTime.Now
            },

            // Example Diet-Food Pair 4: Bacon
            new DietsFoodsModel
            {
                DietsD_Id = 2,
                FoodsF_Id = 4, // Food ID for Bacon
                DF_Serving_Size = "2 slices",
                DF_Recommended_Servings = "1-2 servings/day",
                DF_Frequency = "Daily",
                DF_Total_Calories = 80,
                DF_Modified_Date = DateTime.Now
            },

            // Example Diet-Food Pair 5: Cheese (Cheddar)
            new DietsFoodsModel
            {
                DietsD_Id = 2,
                FoodsF_Id = 5, // Food ID for Cheddar Cheese
                DF_Serving_Size = "1 oz",
                DF_Recommended_Servings = "2-3 servings/day",
                DF_Frequency = "Daily",
                DF_Total_Calories = 115,
                DF_Modified_Date = DateTime.Now
            },

            // Example Diet-Food Pair 6: Olive Oil
            new DietsFoodsModel
            {
                DietsD_Id = 2,
                FoodsF_Id = 6, // Food ID for Olive Oil
                DF_Serving_Size = "1 tablespoon",
                DF_Recommended_Servings = "2-3 servings/day",
                DF_Frequency = "Daily",
                DF_Total_Calories = 119,
                DF_Modified_Date = DateTime.Now
            },

            // Example Diet-Food Pair 7: Almonds
            new DietsFoodsModel
            {
                DietsD_Id = 2,
                FoodsF_Id = 7, // Food ID for Almonds
                DF_Serving_Size = "1 ounce",
                DF_Recommended_Servings = "1 serving/day",
                DF_Frequency = "Daily",
                DF_Total_Calories = 160,
                DF_Modified_Date = DateTime.Now
            },

            // Example Diet-Food Pair 8: Salmon
            new DietsFoodsModel
            {
                DietsD_Id = 2,
                FoodsF_Id = 8, // Food ID for Salmon
                DF_Serving_Size = "4 oz",
                DF_Recommended_Servings = "2-3 servings/week",
                DF_Frequency = "Weekly",
                DF_Total_Calories = 232,
                DF_Modified_Date = DateTime.Now
            },

            // Example Diet-Food Pair 9: Cauliflower (Used as rice substitute)
            new DietsFoodsModel
            {
                DietsD_Id = 2,
                FoodsF_Id = 9, // Food ID for Cauliflower
                DF_Serving_Size = "1 cup",
                DF_Recommended_Servings = "2-3 servings/day",
                DF_Frequency = "Daily",
                DF_Total_Calories = 25,
                DF_Modified_Date = DateTime.Now
            },

            // Example Diet-Food Pair 10: Zucchini (Used in noodles or stir-fried)
            new DietsFoodsModel
            {
                DietsD_Id = 2,
                FoodsF_Id = 10, // Food ID for Zucchini
                DF_Serving_Size = "1 medium zucchini",
                DF_Recommended_Servings = "1-2 servings/day",
                DF_Frequency = "Daily",
                DF_Total_Calories = 33,
                DF_Modified_Date = DateTime.Now
            },

            // Example Diet-Food Pair 11: Spinach
            new DietsFoodsModel
            {
                DietsD_Id = 2,
                FoodsF_Id = 11, // Food ID for Spinach
                DF_Serving_Size = "1 cup cooked",
                DF_Recommended_Servings = "1-2 servings/day",
                DF_Frequency = "Daily",
                DF_Total_Calories = 41,
                DF_Modified_Date = DateTime.Now
            },

            // Example Diet-Food Pair 12: Coconut Oil
            new DietsFoodsModel
            {
                DietsD_Id = 2,
                FoodsF_Id = 12, // Food ID for Coconut Oil
                DF_Serving_Size = "1 tablespoon",
                DF_Recommended_Servings = "1-2 servings/day",
                DF_Frequency = "Daily",
                DF_Total_Calories = 117,
                DF_Modified_Date = DateTime.Now
            },

            // Example Diet-Food Pair 13: Dark Chocolate (85% or higher)
            new DietsFoodsModel
            {
                DietsD_Id = 2,
                FoodsF_Id = 13, // Food ID for Dark Chocolate
                DF_Serving_Size = "1 oz",
                DF_Recommended_Servings = "1 serving/day",
                DF_Frequency = "Daily",
                DF_Total_Calories = 170,
                DF_Modified_Date = DateTime.Now
            },

            // Example Diet-Food Pair 14: Mushrooms
            new DietsFoodsModel
            {
                DietsD_Id = 2,
                FoodsF_Id = 14, // Food ID for Mushrooms
                DF_Serving_Size = "1 cup cooked",
                DF_Recommended_Servings = "1-2 servings/day",
                DF_Frequency = "Daily",
                DF_Total_Calories = 35,
                DF_Modified_Date = DateTime.Now
            },

            // Example Diet-Food Pair 15: Chia Seeds
            new DietsFoodsModel
            {
                DietsD_Id = 2,
                FoodsF_Id = 15, // Food ID for Chia Seeds
                DF_Serving_Size = "2 tablespoons",
                DF_Recommended_Servings = "1-2 servings/day",
                DF_Frequency = "Daily",
                DF_Total_Calories = 138,
                DF_Modified_Date = DateTime.Now
            },

            new DietsFoodsModel
            {
                DietsD_Id = 3, // Assuming Diet ID for Vegetarian Diet
                FoodsF_Id = 1, // Food ID for Avocados
                DF_Serving_Size = "1/2 avocado",
                DF_Recommended_Servings = "1 serving/day",
                DF_Frequency = "Daily",
                DF_Total_Calories = 160,
                DF_Modified_Date = DateTime.Now
            },

            // Example Diet-Food Pair 2: Tofu
            new DietsFoodsModel
            {
                DietsD_Id = 3,
                FoodsF_Id = 2, // Food ID for Tofu
                DF_Serving_Size = "4 oz",
                DF_Recommended_Servings = "1-2 servings/day",
                DF_Frequency = "Daily",
                DF_Total_Calories = 94,
                DF_Modified_Date = DateTime.Now
            },

            // Example Diet-Food Pair 3: Lentils
            new DietsFoodsModel
            {
                DietsD_Id = 3,
                FoodsF_Id = 3, // Food ID for Lentils
                DF_Serving_Size = "1/2 cup cooked",
                DF_Recommended_Servings = "2-3 servings/day",
                DF_Frequency = "Daily",
                DF_Total_Calories = 115,
                DF_Modified_Date = DateTime.Now
            },

            // Example Diet-Food Pair 4: Chickpeas
            new DietsFoodsModel
            {
                DietsD_Id = 3,
                FoodsF_Id = 4, // Food ID for Chickpeas
                DF_Serving_Size = "1/2 cup cooked",
                DF_Recommended_Servings = "1-2 servings/day",
                DF_Frequency = "Daily",
                DF_Total_Calories = 135,
                DF_Modified_Date = DateTime.Now
            },

            // Example Diet-Food Pair 5: Quinoa
            new DietsFoodsModel
            {
                DietsD_Id = 3,
                FoodsF_Id = 5, // Food ID for Quinoa
                DF_Serving_Size = "1 cup cooked",
                DF_Recommended_Servings = "1-2 servings/day",
                DF_Frequency = "Daily",
                DF_Total_Calories = 222,
                DF_Modified_Date = DateTime.Now
            },

            // Example Diet-Food Pair 6: Spinach
            new DietsFoodsModel
            {
                DietsD_Id = 3,
                FoodsF_Id = 6, // Food ID for Spinach
                DF_Serving_Size = "1 cup cooked",
                DF_Recommended_Servings = "1-2 servings/day",
                DF_Frequency = "Daily",
                DF_Total_Calories = 41,
                DF_Modified_Date = DateTime.Now
            },

            // Example Diet-Food Pair 7: Almonds
            new DietsFoodsModel
            {
                DietsD_Id = 3,
                FoodsF_Id = 7, // Food ID for Almonds
                DF_Serving_Size = "1 ounce",
                DF_Recommended_Servings = "1 serving/day",
                DF_Frequency = "Daily",
                DF_Total_Calories = 160,
                DF_Modified_Date = DateTime.Now
            },

            // Example Diet-Food Pair 8: Sweet Potatoes
            new DietsFoodsModel
            {
                DietsD_Id = 3,
                FoodsF_Id = 8, // Food ID for Sweet Potatoes
                DF_Serving_Size = "1 medium potato",
                DF_Recommended_Servings = "1 serving/day",
                DF_Frequency = "Daily",
                DF_Total_Calories = 112,
                DF_Modified_Date = DateTime.Now
            },

            // Example Diet-Food Pair 9: Broccoli
            new DietsFoodsModel
            {
                DietsD_Id = 3,
                FoodsF_Id = 9, // Food ID for Broccoli
                DF_Serving_Size = "1 cup cooked",
                DF_Recommended_Servings = "1-2 servings/day",
                DF_Frequency = "Daily",
                DF_Total_Calories = 55,
                DF_Modified_Date = DateTime.Now
            },

            // Example Diet-Food Pair 10: Carrots
            new DietsFoodsModel
            {
                DietsD_Id = 3,
                FoodsF_Id = 10, // Food ID for Carrots
                DF_Serving_Size = "1 medium carrot",
                DF_Recommended_Servings = "1-2 servings/day",
                DF_Frequency = "Daily",
                DF_Total_Calories = 25,
                DF_Modified_Date = DateTime.Now
            },

            // Example Diet-Food Pair 11: Avocado Oil
            new DietsFoodsModel
            {
                DietsD_Id = 3,
                FoodsF_Id = 11, // Food ID for Avocado Oil
                DF_Serving_Size = "1 tablespoon",
                DF_Recommended_Servings = "1-2 servings/day",
                DF_Frequency = "Daily",
                DF_Total_Calories = 120,
                DF_Modified_Date = DateTime.Now
            },

            // Example Diet-Food Pair 12: Edamame
            new DietsFoodsModel
            {
                DietsD_Id = 3,
                FoodsF_Id = 12, // Food ID for Edamame
                DF_Serving_Size = "1/2 cup",
                DF_Recommended_Servings = "1-2 servings/day",
                DF_Frequency = "Daily",
                DF_Total_Calories = 120,
                DF_Modified_Date = DateTime.Now
            },

            // Example Diet-Food Pair 13: Chia Seeds
            new DietsFoodsModel
            {
                DietsD_Id = 3,
                FoodsF_Id = 13, // Food ID for Chia Seeds
                DF_Serving_Size = "2 tablespoons",
                DF_Recommended_Servings = "1 serving/day",
                DF_Frequency = "Daily",
                DF_Total_Calories = 138,
                DF_Modified_Date = DateTime.Now
            },

            // Example Diet-Food Pair 14: Cucumbers
            new DietsFoodsModel
            {
                DietsD_Id = 3,
                FoodsF_Id = 14, // Food ID for Cucumbers
                DF_Serving_Size = "1/2 cucumber",
                DF_Recommended_Servings = "1-2 servings/day",
                DF_Frequency = "Daily",
                DF_Total_Calories = 8,
                DF_Modified_Date = DateTime.Now
            },

            // Example Diet-Food Pair 15: Mushrooms
            new DietsFoodsModel
            {
                DietsD_Id = 3,
                FoodsF_Id = 15, // Food ID for Mushrooms
                DF_Serving_Size = "1 cup cooked",
                DF_Recommended_Servings = "1-2 servings/day",
                DF_Frequency = "Daily",
                DF_Total_Calories = 35,
                DF_Modified_Date = DateTime.Now
            },

            // Example Diet-Food Pair 16: Greek Yogurt
            new DietsFoodsModel
            {
                DietsD_Id = 3,
                FoodsF_Id = 16, // Food ID for Greek Yogurt
                DF_Serving_Size = "1/2 cup",
                DF_Recommended_Servings = "1 serving/day",
                DF_Frequency = "Daily",
                DF_Total_Calories = 100,
                DF_Modified_Date = DateTime.Now
            }

            );


        }
    }
}
