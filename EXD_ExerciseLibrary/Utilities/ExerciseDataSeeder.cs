using ExerciseXData_ExerciseLibrary.Models;
using Microsoft.EntityFrameworkCore;
using ExerciseXData_SharedLibrary.Enum;

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
                    E_Description = "A bodyweight exercise targeting the chest, shoulders, and triceps." +
                    "\r\nPerform a plank position and lower your body to the ground, then push back up" +
                    "\r\nWide push-ups or diamond push-ups for targeting different muscles.",
                    E_Pros_1 = "Builds upper body strength without equipment",
                    E_Cons_1 = "Can strain wrists if not performed correctly",
                    E_Modified_Date = DateTime.Now
                },
                new ExercisesModel
                {
                    E_Id = 6,
                    E_Name = "Wall Push-ups",
                    CategoriesC_Id = 2,
                    E_Description = "A beginner-friendly exercise to build strength in the chest, shoulders, and triceps." +
                    "\r\nHow: Stand facing a wall, place your hands shoulder-width apart on the wall, and perform push-ups by bending your elbows and leaning toward the wall, then pushing back to the starting position." +
                    "\r\nVariation: Adjust the angle by stepping closer or farther from the wall to make it easier or harder.",
                    E_Pros_1 = "Builds arm strength",
                    E_Cons_1 = "May cause elbow pain if done incorrectly",
                    E_Modified_Date = DateTime.Now
                },
                new ExercisesModel
                {
                    E_Id = 7,
                    E_Name = "Plank-to-Shoulder Taps",
                    CategoriesC_Id = 2,
                    E_Description = "Builds core stability and strengthens shoulders and chest." +
                    "\r\nHow: Start in a plank position and tap one shoulder at a time with the opposite hand while maintaining balance.",
                    E_Pros_1 = "Great for strengthening upper body, legs and glutes",
                    E_Cons_1 = "Can cause joint strain if form is improper",
                    E_Modified_Date = DateTime.Now
                },
                new ExercisesModel
                {
                    E_Id = 8,
                    E_Name = "Dips",
                    CategoriesC_Id = 2,
                    E_Description = "Focuses on the triceps, chest, and shoulders." +
                    "\r\nHow: Use a sturdy surface like a chair or perform parallel bar dips to push yourself up and down.",
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

            modelBuilder.Entity<ExercisePlansModel>().HasData(
                new ExercisePlansModel
                {
                    EP_Id = 1,
                    EP_Name = "Upper Body focus",
                    EP_Difficulty = (ExercisePlanDifficulty)1,
                    EP_Description = "Exercises that taregets the upper body.",
                    EP_CreatedDate = DateTime.Now
                },
                new ExercisePlansModel
                {
                    EP_Id = 2,
                    EP_Name = "Lower Body focus",
                    EP_Difficulty = (ExercisePlanDifficulty)2,
                    EP_Description = "Exercises that taregets the lower body.",
                    EP_CreatedDate = DateTime.Now
                },
                new ExercisePlansModel
                {
                    EP_Id = 3,
                    EP_Name = "Full Body focus",
                    EP_Difficulty = (ExercisePlanDifficulty)3,
                    EP_Description = "Exercises that taregets the full body.",
                    EP_CreatedDate = DateTime.Now
                }

            );

            modelBuilder.Entity<ExercisePlanExercisesModel>().HasData(
   new ExercisePlanExercisesModel { Id = 1, EP_Id = 1, E_Id = 1, Sets = 1, Reps = 0, Duration = 600, RestTime = "2 minutes" }, // Running: 10 minutes
   new ExercisePlanExercisesModel { Id = 2, EP_Id = 1, E_Id = 2, Sets = 1, Reps = 0, Duration = 600, RestTime = "2 minutes" }, // Cycling: 10 minutes
   new ExercisePlanExercisesModel { Id = 3, EP_Id = 1, E_Id = 3, Sets = 1, Reps = 0, Duration = 600, RestTime = "2 minutes" }, // Swimming: 10 minutes
   new ExercisePlanExercisesModel { Id = 4, EP_Id = 2, E_Id = 5, Sets = 3, Reps = 12, Duration = 0, RestTime = "30 seconds" },  // Push-ups
   new ExercisePlanExercisesModel { Id = 5, EP_Id = 2, E_Id = 6, Sets = 3, Reps = 15, Duration = 0, RestTime = "30 seconds" },  // Wall Push-ups
   new ExercisePlanExercisesModel { Id = 6, EP_Id = 2, E_Id = 7, Sets = 3, Reps = 10, Duration = 0, RestTime = "30 seconds" },  // Plank-to-Shoulder Taps
   new ExercisePlanExercisesModel { Id = 7, EP_Id = 2, E_Id = 8, Sets = 3, Reps = 8, Duration = 0, RestTime = "45 seconds" },  // Dips
   new ExercisePlanExercisesModel { Id = 8, EP_Id = 3, E_Id = 9, Sets = 3, Reps = 0, Duration = 60, RestTime = "30 seconds" },  // Planks: 1 minute hold
   new ExercisePlanExercisesModel { Id = 9, EP_Id = 3, E_Id = 10, Sets = 3, Reps = 20, Duration = 0, RestTime = "30 seconds" }, // Crunches
   new ExercisePlanExercisesModel { Id = 10, EP_Id = 3, E_Id = 11, Sets = 3, Reps = 15, Duration = 0, RestTime = "30 seconds" }, // Leg Raises
   new ExercisePlanExercisesModel { Id = 11, EP_Id = 3, E_Id = 12, Sets = 3, Reps = 20, Duration = 0, RestTime = "30 seconds" }, // Mountain Climbers
   new ExercisePlanExercisesModel { Id = 12, EP_Id = 4, E_Id = 13, Sets = 1, Reps = 0, Duration = 30, RestTime = "15 seconds" }, // Hamstring Stretch: 30 seconds
   new ExercisePlanExercisesModel { Id = 13, EP_Id = 4, E_Id = 14, Sets = 1, Reps = 0, Duration = 30, RestTime = "15 seconds" }, // Shoulder Stretch: 30 seconds
   new ExercisePlanExercisesModel { Id = 14, EP_Id = 4, E_Id = 15, Sets = 1, Reps = 0, Duration = 30, RestTime = "15 seconds" }, // Neck Stretch: 30 seconds
   new ExercisePlanExercisesModel { Id = 15, EP_Id = 4, E_Id = 16, Sets = 1, Reps = 0, Duration = 30, RestTime = "15 seconds" }  // Lunge Stretch: 30 seconds
);
        }
    }
}
