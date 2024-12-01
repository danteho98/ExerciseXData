using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;


namespace ExerciseXData_ExerciseLibrary.Models
{
    public class ExercisePlanExercisesModel
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [ForeignKey("ExercisePlans")]
        [DisplayName("Exercise Plan")]
        public int EP_Id { get; set; }

        public ExercisePlansModel ExercisePlan { get; set; }

        [Required]
        [ForeignKey("Exercises")]
        [DisplayName("Exercise")]
        public int E_Id { get; set; }

        public ExercisesModel Exercise { get; set; }

        [DisplayName("Order")]
        public int? Order { get; set; }

        [DisplayName("Sets")]
        public int Sets { get; set; }

        [DisplayName("Reps")]
        public int Reps { get; set; }

        [DisplayName("Rest Time")]
        public string? RestTime { get; set; } // e.g., "30 seconds"
    }
}
