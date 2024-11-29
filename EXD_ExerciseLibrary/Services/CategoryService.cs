﻿
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

        public async Task AddCategoryAsync(CategoriesModel model)
        {
            await _categoryRepository.AddAsync(model);
            await _categoryRepository.SaveChangesAsync();
        }

        public async Task UpdateCategoryAsync(CategoriesModel model)
        {
            var existingCategory = await _categoryRepository.GetByIdAsync(model.C_Id);
            if (existingCategory == null) throw new ArgumentException("Category not found");

            if (!string.IsNullOrEmpty(model.C_Name))
                existingCategory.C_Name = model.C_Name;

            if (model.C_Image != null)
                existingCategory.C_Image = model.C_Image;

            existingCategory.C_Modified_Date = DateTime.Now;

             _categoryRepository.UpdateAsync(existingCategory);
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