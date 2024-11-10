using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExerciseXDataLibrary.DataTransferObject
{
    public class UserDashboardDto
    {
        public string Username { get; set; }
        public string Email { get; set; }
        public int Age { get; set; }
        public double Height_CM { get; set; }
        public double Weight_KG { get; set; }
        public string Goal { get; set; }
        public List<ExerciseDto> Exercises { get; set; }
        public List<DietDto> DietPlans { get; set; }
    }

    public class ExerciseDto
    {
        public string Name { get; set; }
        public int Duration { get; set; } // in minutes
    }

    public class DietDto
    {
        public string Name { get; set; }
        public int Calories { get; set; } // in kcal
    }
}

