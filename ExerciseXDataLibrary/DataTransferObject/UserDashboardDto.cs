

//using ExerciseXData_SharedLibrary.Enum;

namespace ExerciseXData_UserLibrary.DataTransferObject
{
    public class UserDashboardDto
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string Username { get; set; }
        public string Gender { get; set; }
        public string Role { get; set; }
        public int Age { get; set; }
        public double Height_CM { get; set; }
        public double Weight_KG { get; set; }
        public string FitnessGoal { get; set; }
        //public ActivityLevel ActivityLevel { get; set; } // Add the ActivityLevel enum here
        public string DietaryPreferences { get; set; }
        public List<string> HealthConditions { get; set; }
        public string SleepPatterns { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime LastLogin { get; set; }
        public bool ConsentToDataCollection { get; set; }

        // Optionally, you can also add related exercise or diet plans if needed
        public List<string> ExercisePlans { get; set; }
        public List<string> DietPlans { get; set; }



    }  
}

