using ExerciseXData_ExerciseLibrary.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
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
                new CategoriesModel { C_Id = 2, C_Name = "Strength", C_Modified_Date = DateTime.Now },
                new CategoriesModel { C_Id = 3, C_Name = "Core", C_Modified_Date = DateTime.Now },
                new CategoriesModel { C_Id = 4, C_Name = "Flexibility & Movement", C_Modified_Date = DateTime.Now }
            );

            modelBuilder.Entity<ExercisesModel>().HasData(
                new ExercisesModel 
                { 
                    E_Id = 1, 
                    E_Name = "Running", 
                    CategoriesC_Id = 1, 
                    E_Description = "Step one leg forward into a deep lunge, with your back leg extended behind you.\r\n Keep your back straight and push your hips forward to feel a stretch in your hip flexors and thighs.",
                    E_Pros_1 = "Improves flexibility", 
                    E_Cons_1 = "May cause injury to knees",
                    E_Modified_Date = DateTime.Now
                },
                new ExercisesModel 
                { 
                    E_Id = 2, 
                    E_Name = "Cycling", 
                    CategoriesC_Id = 1,
                    E_Description = " A low - impact cardio exercise that strengthens the lower body and improves endurance.",
                    E_Pros_1 = "Enhances cardiovascular health.",
                    E_Cons_1 = "Requires access to a bike or cycling equipment",
                    E_Modified_Date = DateTime.Now
                },
                new ExercisesModel { E_Id = 3, E_Name = "Swimming", CategoriesC_Id = 1,
                    E_Description = "A full-body workout that improves cardiovascular health and builds strength.",
                    E_Pros_1 = "Low impact, ideal for joint health.",
                    E_Cons_1 = " Requires access to a pool.",
                    E_Modified_Date = DateTime.Now
                },
                new ExercisesModel
                {
                   E_Id = 4,
                   E_Name = "Walking",
                   CategoriesC_Id = 1,
                   E_Description = "A simple and effective way to improve overall fitness and maintain a healthy weight.",
                   E_Pros_1 = "Easy to start, no equipment needed",
                   E_Cons_1 = "Less effective for building muscle compared to other exercises",
                    E_Modified_Date = DateTime.Now
                },
                new ExercisesModel
                {
                    E_Id = 5,
                    E_Name = "Push-ups",
                    CategoriesC_Id = 2,
                    E_Description = "A bodyweight exercise targeting the chest, shoulders, and triceps.",
                    E_Pros_1 = "Builds upper body strength without equipment",
                    E_Cons_1 = "Can strain wrists if not performed correctly",
                    E_Modified_Date = DateTime.Now
                },
                new ExercisesModel
                {
                    E_Id = 6,
                    E_Name = "Squats",
                    CategoriesC_Id = 2,
                    E_Description = "A compound exercise that strengthens the lower body and core.",
                    E_Pros_1 = "Builds leg strength and improves balance",
                    E_Cons_1 = "May cause knee pain if done incorrectly",
                    E_Modified_Date = DateTime.Now
                },
                new ExercisesModel
                {
                    E_Id = 7,
                    E_Name = "Lunges",
                    CategoriesC_Id = 2,
                    E_Description = "A lower body exercise that improves flexibility and balance.",
                    E_Pros_1 = "Great for strengthening legs and glutes",
                    E_Cons_1 = "Can cause knee strain if form is improper",
                    E_Modified_Date = DateTime.Now
                },
                new ExercisesModel
                {
                    E_Id = 8,
                    E_Name = "Push-ups",
                    CategoriesC_Id = 2,
                    E_Description = "A bodyweight exercise targeting the chest, shoulders, and triceps.",
                    E_Pros_1 = "Builds upper body strength without equipment",
                    E_Cons_1 = "Can strain wrists if not performed correctly",
                    E_Modified_Date = DateTime.Now
                },
                new ExercisesModel
                {
                    E_Id = 9,
                    E_Name = "Planks",
                    CategoriesC_Id = 3,
                    E_Description = "A core-strengthening exercise that improves posture and stability.",
                    E_Pros_1 = "Enhances core strength and stability",
                    E_Cons_1 = "Can be challenging for beginners to hold for long periods",
                    E_Modified_Date = DateTime.Now
                },
                new ExercisesModel
                {
                    E_Id = 10,
                    E_Name = "Crunches",
                    CategoriesC_Id = 3,
                    E_Description = "A classic core exercise targeting the abdominal muscles.",
                    E_Pros_1 = "Focuses on abdominal muscle strength",
                    E_Cons_1 = "Can strain the neck if performed improperly",
                    E_Modified_Date = DateTime.Now
                },
                new ExercisesModel
                {
                    E_Id = 11,
                    E_Name = "Leg Raises",
                    CategoriesC_Id = 3,
                    E_Description = "An abdominal exercise focusing on the lower abs and hip flexors.",
                    E_Pros_1 = "Strengthens core and improves hip mobility",
                    E_Cons_1 = "May cause lower back strain if the core is weak",
                    E_Modified_Date = DateTime.Now
                },
                new ExercisesModel
                {
                    E_Id = 12,
                    E_Name = "Mountain Climbers",
                    CategoriesC_Id = 3,
                    E_Description = "A high-intensity exercise that combines cardio and strength training.",
                    E_Pros_1 = "Boosts heart rate and burns calories quickly",
                    E_Cons_1 = "Requires good wrist and shoulder stability",
                    E_Modified_Date = DateTime.Now
                },
                new ExercisesModel
                {
                    E_Id = 13,
                    E_Name = "Hamstring Stretch",
                    CategoriesC_Id = 4,
                    E_Description = "A flexibility exercise that stretches the hamstring muscles.",
                    E_Pros_1 = "Improves flexibility and reduces injury risk",
                    E_Cons_1 = "Provides no cardio or strength benefits",
                    E_Modified_Date = DateTime.Now
                },
                new ExercisesModel
                {
                    E_Id = 14,
                    E_Name = "Shoulder Stretch",
                    CategoriesC_Id = 4,
                    E_Description = "A simple stretch to improve shoulder mobility and reduce tension.",
                    E_Pros_1 = "Alleviates tension and improves flexibility",
                    E_Cons_1 = "Does not build muscle or burn calories",
                    E_Modified_Date = DateTime.Now
                },
                new ExercisesModel
                {
                    E_Id = 15,
                    E_Name = "Neck Stretch",
                    CategoriesC_Id = 4,
                    E_Description = "A gentle stretch to reduce tension and stiffness in the neck.",
                    E_Pros_1 = "Relieves neck stiffness and improves mobility",
                    E_Cons_1 = "Limited to improving neck flexibility only",
                    E_Modified_Date = DateTime.Now
                },
                new ExercisesModel 
                { 
                    E_Id = 16, 
                    E_Name = "Lunge Stretch", 
                    CategoriesC_Id = 4,
                    E_Description = "Sit or stand with your back straight. Slowly tilt your head towards your right shoulder, bringing your ear closer to it.\r\nHold for 15-20 seconds and then switch to the other side.",
                    E_Pros_1 = "Improves flexibility",
                    E_Cons_1 = "May cause injury to knees",
                    E_Modified_Date = DateTime.Now
                }  
            );
        }
    }
}
