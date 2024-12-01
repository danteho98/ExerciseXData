

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
        public string Goal { get; set; }
        public string Lifestyle_Condition_1 { get; set; }
        public string Lifestyle_Condition_2 { get; set; }
        public string Lifestyle_Condition_3 { get; set; }
        public string Lifestyle_Condition_4 { get; set; }
        public string Lifestyle_Condition_5 { get; set; }
        public List<ExercisePlanDto> ExercisePlans { get; set; }
        public List<DietPlanDto> DietPlans { get; set; }
        
    }  
}

