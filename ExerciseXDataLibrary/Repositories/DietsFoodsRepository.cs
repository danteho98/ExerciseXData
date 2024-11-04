using ExerciseXData.Data;
using ExerciseXData.Models;
using ExerciseXDataLibrary.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExerciseXDataLibrary.Repositories
{
    public class DietsFoodsRepository
    {
        private readonly DietDbContext _dietContext;
        public DietsFoodsRepository(DietDbContext dietContext) 
        {
            _dietContext = dietContext; 
        }

        public Task<List<DietsFoodsModel>> GetByDietId(int dietId) =>
            _dietContext.DietsFoods.Where(df => df.D_Id == dietId).ToListAsync();
    }
}
