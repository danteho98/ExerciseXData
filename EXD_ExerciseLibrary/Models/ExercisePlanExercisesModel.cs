using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;


namespace ExerciseXData_ExerciseLibrary.Models
{
    public class ExercisePlanExercisesModel
    {
   
        [Required]
        [DisplayName("Exercise Plan")]
        public int ExercisePlanEP_Id { get; set; }
            
        public ExercisePlansModel ExercisePlan { get; set; }

        [Required]
        
        [DisplayName("Exercise")]
        public int ExercisesE_Id { get; set; }
        public ExercisesModel Exercises { get; set; }


        [DisplayName("Sets")]
        public int Sets { get; set; }

        [DisplayName("Reps")]
        public int Reps { get; set; }

        public int Duration { get; set; }

        [DisplayName("Rest Time")]
        public string? RestTime { get; set; } // e.g., "30 seconds"
    }
}
