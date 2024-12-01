using ExerciseXData_DietLibrary.Data;
using ExerciseXData_DietLibrary.Models;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExerciseXData_DietLibrary.Services
{
    public class UsersDietsService
    {
      
        private readonly DietDbContext _dietDbContext;

        public UsersDietsService( DietDbContext dietDbContext)
        {
           
            _dietDbContext = dietDbContext;
        }

        
    }
}

