using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
namespace ExerciseXData.Models
{
    public class Exercises
    {
        [Key]
        public int E_Id { get; set; }

        // Category Relationship
        [ForeignKey("CategoryId")]
        public int C_Id { get; set; }
        public Categories Category { get; set; }

        [Display(Name ="Exercise Image")]
        public string ? E_Image { get; set; }

        //[Required(ErrorMessage = "Exercise name cannot be empty.")]
        [Display(Name="Exercise Name")] /*This part allows programmer to put any name*/
        public string ? E_Name { get; set; }

        //[Required(ErrorMessage = "Exercise description cannot be empty.")]
        [Display(Name = "Exercise Description")]
        public string ? E_Description { get; set; }

        //[Required(ErrorMessage = "Exercise Pros 1 cannot be empty.")]
        [Display(Name = "Exercise Pros 1")]
        public string ? E_Pros_1 { get; set; }

        [Display(Name = "Exercise Pros 2")]
        public string ? E_Pros_2 { get; set; }

        [Display(Name = "Exercise Pros 3")]
        public string ? E_Pros_3 { get; set; }

        //[Required(ErrorMessage = "Exercise Cons 1 cannot be empty.")]
        [Display(Name = "Exercise Cons 1")]
        public string ? E_Cons_1 { get; set; }

        [Display(Name ="Exercise Cons 2")]
        public string ? E_Cons_2 { get; set; }

        [Display(Name = "Exercise Cons 3")]
        public string ? E_Cons_3 { get; set; }

        [DisplayName("Modified Date")]
        public DateTime E_Modified_Date { get; set; } = DateTime.Now;

        public List<UsersExercises> UserExercises { get; set; }
    }
}