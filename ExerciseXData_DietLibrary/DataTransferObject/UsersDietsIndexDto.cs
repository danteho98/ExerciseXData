using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExerciseXData_DietLibrary.DataTransferObject
{
    public class UsersDietsIndexDto
    {
        public int UD_Id { get; set; }
        public string Id { get; set; } // User Id
        public string UserName { get; set; } // User Name

        public int D_Id { get; set; } // Diet Id
        public string DietName { get; set; } // Diet Name

        public string? CustomDietName { get; set; }
        public int? UD_ServingSize { get; set; }
        public string? UD_Frequency { get; set; }
        public int? UD_TotalCalories { get; set; }

        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public bool IsCompleted { get; set; }
        public DateTime UD_Modified_Date { get; set; }
    }
}
