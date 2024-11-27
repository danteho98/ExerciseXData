using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExerciseXData_UserLibrary.DataTransferObject
{
    public class UpdateUserDto
    {
        public int Age { get; set; }
        public double Height { get; set; }
        public double Weight { get; set; }
        public string Goal {  get; set; }
        public string ? LifestyleCondition1 { get; set; }
        public string ? LifestyleCondition2 { get; set; }
        public string ? LifestyleCondition3 { get; set; }
        public string ? LifestyleCondition4 { get; set; }
        public string ? LifestyleCondition5 { get; set; }

    }
}
