using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ExerciseXData.Models
{
    public class Categories
    {
        [Key]
        [DisplayName("Category Id")]
        public int C_Id { get; set; }

        [DisplayName ("Category Image")]
        public string ? C_Image { get; set; }

        //[Required]
        [DisplayName("Category Name")]
        public string ? C_Name { get; set; }

        [DisplayName("Modified Date")]
        public DateTime C_Modified_Date { get; set; } = DateTime.Now;

        //Relationships
        public List<Exercises> Exercises { get; set; }
    }
}
