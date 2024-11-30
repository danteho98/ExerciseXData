using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExerciseXData_DietLibrary.Interface
{
    public interface IDietRepository
    {
        Task<int> GetTotalDietsAsync();
    }

}
