using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace ExerciseXData.Models
{
    public class UsersExercises
    {
        [Key]
        public int UE_Id { get; set; }

        //Relationship
        //[ForeignKey("U_Id")]
        public int U_Id { get; set; }
        public Users Users { get; set; }

        //[ForeignKey("E_Id")]
        public int E_Id { get; set; }
        public Exercises Exercises { get; set; }

        //[Required(ErrorMessage = "Please enter the number of times you want to perform this exercise.")]
        [DisplayName("Times performed")]
        public int ? Times_Performed { get; set; }

        [DisplayName("Duration (secs)")]
        public int ? Duration { get; set; }

        [DisplayName("Modified Date")]
        public DateTime UE_Modify_Date { get; set; } = DateTime.Now;
    }
}