using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExerciseXData_DietLibrary.DataTransferObject
{
    public class EditDietDto
    {
        public int D_Id { get; set; } // Primary key of the diet being edited

        public string ? D_Name { get; set; } // Diet name - required
        public string? D_Description { get; set; } // Optional description of the diet

        public string? D_Pros_1 { get; set; } // Optional Pro #1
        public string? D_Pros_2 { get; set; } // Optional Pro #2
        public string? D_Pros_3 { get; set; } // Optional Pro #3

        public string? D_Cons_1 { get; set; } // Optional Con #1
        public string? D_Cons_2 { get; set; } // Optional Con #2
        public string? D_Cons_3 { get; set; }
    }
}
