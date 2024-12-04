using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExerciseXData_SharedLibrary.Dto
{
    public class UserDietDto
    {
        public string UserId { get; set; }
        public string UserName { get; set; }
        public int DietId { get; set; }
        public string DietName { get; set; }
        public string CustomDietName { get; set; }
        public int? ServingSize { get; set; }
        public string Frequency { get; set; }
        public bool IsCompleted { get; set; }
    }

}
