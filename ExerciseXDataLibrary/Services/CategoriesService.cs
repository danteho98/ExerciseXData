using ExerciseXData.Data;
using ExerciseXData.Interfaces;
using ExerciseXData.Models;
using Microsoft.EntityFrameworkCore;

namespace ExerciseXData.Interfaces
{
    
    public class CategoriesService
    {

        private readonly AppDbContext _context;

        public CategoriesService(AppDbContext context) 
        { 
            _context = context;
        }

       

    }
}