using ExerciseXData.Data;
using ExerciseXData.Interfaces;
using ExerciseXData.Models;
using Microsoft.EntityFrameworkCore;

namespace ExerciseXData.Services
{
    public class DietsService
    {
        private readonly AppDbContext _context;

        public DietsService(AppDbContext context)
        {
            _context = context;
        }

       

    }
}
