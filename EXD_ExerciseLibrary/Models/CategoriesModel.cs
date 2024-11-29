using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ExerciseXData_ExerciseLibrary.Models
{
    [Table("Categories")]
    public class CategoriesModel
    {
        [Key]
        [DisplayName("Category Id")]
        public int C_Id { get; set; }

        [DisplayName ("Category Image")]
        public byte[] ? C_Image { get; set; }

        //[Required]
        [DisplayName("Category Name")]
        public string ? C_Name { get; set; }

        [DisplayName("Modified Date")]
        public DateTime C_Modified_Date { get; set; } = DateTime.Now;

        //Relationships
        // Mark this as non-validated to prevent validation issues
        [ValidateNever] // Prevent validation from trying to enforce exercises during category creation
        public List<ExercisesModel> Exercises { get; set; }
    }
}
