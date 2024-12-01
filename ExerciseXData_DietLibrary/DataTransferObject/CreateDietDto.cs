using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExerciseXData_DietLibrary.DataTransferObject
{
    public class CreateDietDto
    {
        public string D_Name { get; set; }
        public string D_Description { get; set; }
        public string D_Pros_1 { get; set; }
        public string D_Pros_2 { get; set; }
        public string D_Pros_3 { get; set; }
        public string D_Cons_1 { get; set; }
        public string D_Cons_2 { get; set; }
        public string D_Cons_3 { get; set; }
        public DateTime? D_Modified_Date { get; set; }
    }
}
