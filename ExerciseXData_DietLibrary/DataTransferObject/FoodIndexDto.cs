using ExerciseXData_DietLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExerciseXData_DietLibrary.DataTransferObject
{
    public class FoodIndexDto
    {
        public List<FoodsModel> Foods { get; set; }
        public List<DietsFoodsModel>? DietsFoods { get; set; }
    }
}
