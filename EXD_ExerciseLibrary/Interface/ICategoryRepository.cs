using ExerciseXData_ExerciseLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExerciseXData_ExerciseLibrary.Interface
{
    public interface ICategoryRepository
    {
        Task AddAsync(CategoriesModel model);
        Task<IEnumerable<CategoriesModel>> GetAllAsync();
        Task<CategoriesModel> GetByIdAsync(int c_Id);
        Task SaveChangesAsync();
        void UpdateAsync(CategoriesModel model);
        void DeleteAsync(CategoriesModel model);
    }

}
