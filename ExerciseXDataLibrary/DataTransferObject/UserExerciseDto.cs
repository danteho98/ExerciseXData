using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExerciseXData_UserLibrary.DataTransferObject
{
    public class UserExerciseDto
    {
        public string ExerciseName { get; set; }
        public DateTime ExerciseDate { get; set; }
        public bool IsCompleted { get; set; }
    }
}