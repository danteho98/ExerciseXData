using ExerciseXDataLibrary.Repositories;
using ExerciseXDataLibrary.Data;
using static ExerciseXDataLibrary.Models.UsersModel;
using static ExerciseXDataLibrary.Models.UserGender;
using ExerciseXDataLibrary.DataTransferObject;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace ExerciseXDataLibrary.Services
{
    public class UsersService
    {
        private readonly UserDbContext _userDbContext;
        private readonly UsersRepository _usersRepository;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;

        public UsersService(UserDbContext userDbContext, UsersRepository usersRepository, 
            UserManager<IdentityUser> userManager, 
            SignInManager<IdentityUser> signInManager)
        {
            _userDbContext = userDbContext;
            _usersRepository = usersRepository;
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public async Task<IdentityResult> RegisterUserAsync(string email, string userName, string password, string gender, int age, 
            double height, double weight, string goal, string lifeStyle1, string lifeStyle2, string lifeStyle3, string lifeStyle4, string lifeStyle5)
        {
            if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password))
            {
                throw new ArgumentException("Email and Password are required");
            }

            if (!Enum.TryParse<Gender>(gender, out var parsedGender))
            {
                parsedGender = Gender.PreferNotToSay;
            }

            var user = new IdentityUser { UserName = userName, Email = email };
            var result = await _userManager.CreateAsync(user, password);

            if (result.Succeeded)
            {
                await _usersRepository.RegisterUserAsync(
                    email,
                    userName,
                    password, // Store hashed password
                    parsedGender,
                    age,
                    height,
                    weight,
                    goal,
                    lifeStyle1,
                    lifeStyle2,
                    lifeStyle3,
                    lifeStyle4,
                    lifeStyle5);
            }

            return result;
        }


        public async Task<SignInResult> LoginUserAsync(string email, string password)
        {
            if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password))
            {
                throw new ArgumentException("Email and Password are required");
            }

            return await _signInManager.PasswordSignInAsync(email, password, isPersistent: false, lockoutOnFailure: false);
        }


        public async Task<UserDashboardDto> FindUserByEmailAsync(string email)
        {
            var user = await _userDbContext.Users
                .FirstOrDefaultAsync(u => u.U_Email == email);

            if (user == null) return null;

            return new UserDashboardDto
            {
                Username = user.U_Username,
                Email = user.U_Email,
                Gender = user.U_Gender.ToString(),
                Role = user.U_Role,
                Age = user.U_Age,
                Height_CM = user.U_Height_CM,
                Weight_KG = user.U_Weight_KG,
                Goal = user.U_Goal,
                Lifestyle_Condition_1 = user.U_Lifestyle_Condition_1,
                Lifestyle_Condition_2 = user.U_Lifestyle_Condition_2,
                Lifestyle_Condition_3 = user.U_Lifestyle_Condition_3,
                Lifestyle_Condition_4 = user.U_Lifestyle_Condition_4,
                Lifestyle_Condition_5 = user.U_Lifestyle_Condition_5
            };
        }
    }
}
