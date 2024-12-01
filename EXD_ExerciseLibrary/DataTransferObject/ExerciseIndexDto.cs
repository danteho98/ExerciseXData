using ExerciseXData_ExerciseLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExerciseXData_ExerciseLibrary.DataTransferObject
{
    public class ExerciseIndexDto
    {
        public List<ExercisesModel> Exercises { get; set; }
        public List<CategoriesModel> Categories { get; set; }
    }

}
