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
        //[ForeignKey("Category Id")]
        public int ? C_Id { get; set; }
        public Categories Categories { get; set; }

        [DisplayName ("Exercises Image")]
        public string ? E_Image { get; set; }

        //[Required(ErrorMessage = "Exercises name cannot be empty.")]
        [Display(Name="Exercises Name")] /*This part allows programmer to put any name*/
        public string ? E_Name { get; set; }

        //[Required(ErrorMessage = "Exercises description cannot be empty.")]
        [Display(Name = "Exercises Description")]
        public string ? E_Description { get; set; }

        //[Required(ErrorMessage = "Exercises Pros 1 cannot be empty.")]
        [Display(Name = "Exercises Pros 1")]
        public string ? E_Pros_1 { get; set; }

        [Display(Name = "Exercises Pros 2")]
        public string ? E_Pros_2 { get; set; }

        [Display(Name = "Exercises Pros 3")]
        public string ? E_Pros_3 { get; set; }

        //[Required(ErrorMessage = "Exercises Cons 1 cannot be empty.")]
        [Display(Name = "Exercises Cons 1")]
        public string ? E_Cons_1 { get; set; }

        [Display(Name ="Exercises Cons 2")]
        public string ? E_Cons_2 { get; set; }

        [Display(Name = "Exercises Cons 3")]
        public string ? E_Cons_3 { get; set; }

        [DisplayName("Modified Date")]
        public DateTime E_Modified_Date { get; set; } = DateTime.Now;

        public List<UsersExercises> UsersExercises { get; set; }
    }
}