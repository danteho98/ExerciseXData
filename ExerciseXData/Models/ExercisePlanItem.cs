namespace ExerciseXData.Models
{
    public class ExercisePlanItem
    {
        public int Id { get; set; }
        public Exercise Exercise { get; set; }
        public int TimesPerformed { get; set; }
        public string ExercisePlanId { get; set; }
    }
}
