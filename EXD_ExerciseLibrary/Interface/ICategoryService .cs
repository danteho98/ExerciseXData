using ExerciseXData_ExerciseLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExerciseXData_ExerciseLibrary.Interface
{
    public interface ICategoryService
    {
        Task<IEnumerable<CategoriesModel>> GetAllCategoriesAsync();
        Task AddCategoryAsync(CategoriesModel model);
        Task UpdateCategoryAsync(CategoriesModel model);
        Task DeleteCategoryAsync(int categoryId);
    }

}
