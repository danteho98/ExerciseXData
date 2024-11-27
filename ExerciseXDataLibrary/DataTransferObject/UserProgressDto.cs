using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExerciseXData_UserLibrary.DataTransferObject
{
    public class UserProgressDto
    {
        public string UserName { get; set; }
        public double ExerciseCompletionRate { get; set; }
        public double DietAdherencePercentage { get; set; }
        public int TotalExercisesCompleted { get; set; }
        public string CurrentGoal { get; set; }
    }

}
