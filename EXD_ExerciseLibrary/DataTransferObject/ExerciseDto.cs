

namespace ExerciseXData_DietLibrary.DataTransferObject
{
    public class ExerciseDto
    {
        public string Name { get; set; }
        public int Repetition { get; set; }
        public int Duration { get; set; } // in minutes
        public int Sets { get; set; }
    }
}
