using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExerciseXData_SharedContracts.Interfaces
{
    public interface IDietRepository
    {
        Task<int> GetTotalDietsAsync();
    }

}
