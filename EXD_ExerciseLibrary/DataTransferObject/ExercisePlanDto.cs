namespace ExerciseXData_ExerciseLibrary.DataTransferObject
{
    public class ExercisePlanDto
    {
        public string Name { get; set; }
        public int Repetition { get; set; }
        public int Duration { get; set; } // in minutes
        public int Sets { get; set; }
    }
}
