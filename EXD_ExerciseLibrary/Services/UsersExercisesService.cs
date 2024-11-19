using ExerciseXDataLibrary.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace ExerciseXDataLibrary.Services
{
    public class UsersExercisesService
    {
        private readonly UsersRepository _userRepository;
        private readonly ExercisesRepository _exerciseRepository;

        public UsersExercisesService(UsersRepository userRepository, ExercisesRepository exerciseRepository)
        {
            _userRepository = userRepository;
            _exerciseRepository = exerciseRepository;
        }

        
    }
}
