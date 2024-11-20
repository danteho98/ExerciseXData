using ExerciseXData_UserLibrary.Data;
using Microsoft.Extensions.Logging;
using System.Security.Cryptography;
using System.Text;


namespace ExerciseXDataLibrary.Repositories
{
    public class UsersRepository
    {
        private readonly UserDbContext _userDbContext;
        private readonly ILogger<UsersRepository> _logger;

        public UsersRepository(UserDbContext userDbContext, ILogger<UsersRepository> logger)
        {
            _userDbContext = userDbContext;
            _logger = logger;
        }

        

       

        private string GenerateSalt()
        {
            var saltBytes = new byte[16];
            using var rng = RandomNumberGenerator.Create();
            rng.GetBytes(saltBytes);
            return Convert.ToBase64String(saltBytes);
        }

        private string GenerateHash(string password, string salt)
        {
            using var sha256 = SHA256.Create();
            var saltedPassword = $"{salt}{password}";
            var saltedPasswordBytes = Encoding.UTF8.GetBytes(saltedPassword);
            var hashBytes = sha256.ComputeHash(saltedPasswordBytes);
            return Convert.ToBase64String(hashBytes);
        }
    }
}
