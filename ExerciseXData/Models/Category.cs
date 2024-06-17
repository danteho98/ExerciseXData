using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ExerciseXData.Models
{
    public class Category
    {
        [Key]
        [DisplayName("Category Id")]
        public int C_Id { get; set; }

        [Display(Name = "Category Image")]
        public string ? C_Image { get; set; }

        [Required]
        [DisplayName("Category Name")]
        public string C_Name { get; set; }

        //Relationships
        public List<Exercise> Exercises { get; set; }
    }
}
