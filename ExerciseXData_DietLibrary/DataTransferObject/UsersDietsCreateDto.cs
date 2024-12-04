using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExerciseXData_DietLibrary.DataTransferObject
{
    public class UsersDietsCreateEditDto
    {
        public int UD_Id { get; set; }
        public string Id { get; set; } // User Id
        public int D_Id { get; set; } // Diet Id

        public string? CustomDietName { get; set; }
        public int? UD_ServingSize { get; set; }
        public string? UD_Frequency { get; set; }
        public int? UD_TotalCalories { get; set; }

        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public bool IsCompleted { get; set; }
    }
}
