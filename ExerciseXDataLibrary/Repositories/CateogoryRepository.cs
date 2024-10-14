using ExerciseXData.Data;
using ExerciseXData.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExerciseXDataLibrary.Repositories
{
    public class CateogoryRepository 
    {
        private readonly AppDbContext _context;

        public CateogoryRepository(AppDbContext context)
        {
            _context = context;
        }
    }

}
