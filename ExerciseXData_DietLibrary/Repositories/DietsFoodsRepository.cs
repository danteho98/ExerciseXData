

using ExerciseXData_DietLibrary.Data;
using ExerciseXData_DietLibrary.Models;
using Microsoft.EntityFrameworkCore;


namespace ExerciseXData_DietLibrary.Repositories
{
    public class DietsFoodsRepository
    {
        private readonly DietDbContext _dietContext;
        public DietsFoodsRepository(DietDbContext dietContext) 
        {
            _dietContext = dietContext; 
        }

        //public Task<List<DietsFoodsModel>> GetByDietId(int dietId) =>
        //    _dietContext.DietsFoods.Where(df => df.D_Id == dietId).ToListAsync();
    }
}
