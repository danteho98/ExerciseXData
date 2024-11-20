using ExerciseXData_DietLibrary.Data;
using ExerciseXData_DietLibrary.Models;
using ExerciseXData_UserLibrary.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExerciseXData_DietLibrary.Services
{
    public class UsersDietsService
    {
        private readonly UserDbContext _userDbContext;
        private readonly DietDbContext _dietDbContext;

        public UsersDietsService(UserDbContext userDbContext, DietDbContext dietDbContext)
        {
            _userDbContext = userDbContext;
            _dietDbContext = dietDbContext;
        }

        
    }
}

