using ExerciseXData.Data;
using ExerciseXData_UserLibrary.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExerciseXDataLibrary.Repositories
{
    public class CategoriesRepository 
    {
        private readonly UserDbContext _userContext;

        public CategoriesRepository(UserDbContext userContext)
        {
            _userContext = userContext;
        }
    }

}
