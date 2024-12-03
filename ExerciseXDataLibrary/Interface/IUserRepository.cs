using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExerciseXData_UserLibrary.Interface
{
    public interface IUserRepository
    {
        Task<int> GetTotalUsersAsync();
    }
}
