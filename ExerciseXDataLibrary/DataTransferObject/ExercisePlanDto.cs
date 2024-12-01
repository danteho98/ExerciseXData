namespace ExerciseXData_UserLibrary.DataTransferObject
{
    public class ExercisePlanDto
    {
        public string Name { get; set; }
        public int Repetition { get; set; }
        public int Duration { get; set; } // in minutes
        public int Sets { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}
