using ExerciseXData_ExerciseLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExerciseXData_ExerciseLibrary.Interface
{
    public class ICategoryRepository
    {
        internal async Task AddAsync(CategoriesModel model)
        {
            throw new NotImplementedException();
        }

        internal async Task<IEnumerable<CategoriesModel>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        internal async Task GetByIdAsync(int c_Id)
        {
            throw new NotImplementedException();
        }

        internal async Task SaveChangesAsync()
        {
            throw new NotImplementedException();
        }
    }
}
