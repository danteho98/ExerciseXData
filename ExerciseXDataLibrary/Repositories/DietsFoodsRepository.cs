using ExerciseXData.Data;
using ExerciseXData.Models;
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
        private readonly AppDbContext _context;
        public DietsFoodsRepository(AppDbContext context) { _context = context; }

        public Task<List<DietsFoods>> GetByDietId(int dietId) =>
            _context.DietsFoods.Where(df => df.D_Id == dietId).ToListAsync();
    }
}
