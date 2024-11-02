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
    public class ExercisesRepository
    {
        private readonly ExerciseDbContext _exerciseDbContext;

        public ExercisesRepository(ExerciseDbContext exerciseDbContext)
        {
            _exerciseDbContext = exerciseDbContext;
        }

        
    }
}
