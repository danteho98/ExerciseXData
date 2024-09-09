using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
namespace ExerciseXData.Models
{
    public class Exercise
    {
        [Key]
        public int E_Id { get; set; }

        [Display(Name ="Exercise C_Image")]
        public string ? C_Image { get; set; }

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

        [DisplayName("Modify Date")]
        public DateTime ModifyDate { get; set; } = DateTime.Now;

        //Relationships
        //Category
        [ForeignKey("CategoryId")]
        public int C_Id { get; set; }
        public Category Category { get; set; }

        public List<UserExercise> UserExercises { get; set; }
    }
}