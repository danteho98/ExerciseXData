using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExerciseXData_ExerciseLibrary.DataTransferObject
{
    public class CategoryIndexDto
    {
        [DisplayName("Category Id")]
        public int C_Id { get; set; }

        [DisplayName("Category Image")]
        public byte[]? C_Image { get; set; }

        //[Required]
        [DisplayName("Category Name")]
        public string? C_Name { get; set; }

        [DisplayName("Modified Date")]
        public DateTime C_ModifiedDate { get; set; } = DateTime.Now;
    }
}
