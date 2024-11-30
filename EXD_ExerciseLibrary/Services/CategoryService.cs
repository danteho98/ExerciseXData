
using ExerciseXData_ExerciseLibrary.Data;
using ExerciseXData_ExerciseLibrary.Interface;
using ExerciseXData_ExerciseLibrary.Models;


namespace ExerciseXData_ExerciseLibrary.Services
{

    public class CategoryService : ICategoryService
    {

        private readonly ICategoryRepository _categoryRepository;

        public CategoryService(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public async Task<IEnumerable<CategoriesModel>> GetAllCategoriesAsync()
        {
            return await _categoryRepository.GetAllAsync();
        }

        public async Task AddCategoryAsync(CategoriesModel category)
        {
            await _categoryRepository.AddAsync(category);
            await _categoryRepository.SaveChangesAsync();
        }

        public async Task UpdateCategoryAsync(CategoriesModel category)
        {
            // Fetch the existing category
            var existingCategory = await _categoryRepository.GetByIdAsync(category.C_Id);
            if (existingCategory == null)
                throw new ArgumentException("Category not found");

            // Update the fields only if they are provided
            if (!string.IsNullOrEmpty(category.C_Name))
                existingCategory.C_Name = category.C_Name;

            if (category.C_Image != null)
                existingCategory.C_Image = category.C_Image;

            // Always update the modified date
            existingCategory.C_Modified_Date = DateTime.Now;

            // Update the entity in the repository
            // Assuming EF Core is being used, this is optional as EF tracks changes automatically
            _categoryRepository.UpdateAsync(existingCategory);

            // Save the changes to the database
            await _categoryRepository.SaveChangesAsync();
        }

        public async Task DeleteCategoryAsync(int categoryId)
        {
            var category = await _categoryRepository.GetByIdAsync(categoryId);
            if (category == null) throw new ArgumentException("Category not found");

            _categoryRepository.DeleteAsync(category);
            await _categoryRepository.SaveChangesAsync();
        }

    }
}