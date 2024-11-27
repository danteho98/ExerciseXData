using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExerciseXData_UserLibrary.DataTransferObject
{
    public class UserDietDto
    {
        public string MealName { get; set; }
        public DateTime MealDate { get; set; }
        public bool IsAdhered { get; set; }
    }

}
