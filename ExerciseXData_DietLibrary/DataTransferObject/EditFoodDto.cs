using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExerciseXData_DietLibrary.DataTransferObject
{
    public class EditFoodDto
    {
        public int F_Id { get; set; }

        [DisplayName("Food Image")]
        public byte[]? F_Image { get; set; }

        [DisplayName("Food Name")]
        public string? F_Name { get; set; }

        [DisplayName("Food Group")]
        public string? F_Group { get; set; }

        [DisplayName("Food Calorie in kcal")]
        public int? F_Calories { get; set; }
    }
}
