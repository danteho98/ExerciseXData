using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace ExerciseXData.Models
{
    public class UserExercise
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Please enter the number of times you want to perform this exercise.")]
        [DisplayName("Times performed")]
        public int Times_Performed { get; set; }

        [DisplayName("Modify Date")]
        public DateTime Modify_Date { get; set; } = DateTime.Now;

        //Relationship
        [ForeignKey("UserId")]
        public int UserId { get; set; }
        public User User { get; set; }

        
        [ForeignKey("ExerciseId")]
        public int ExerciseId { get; set; }
        public Exercise Exercise { get; set; }
        
    }
}