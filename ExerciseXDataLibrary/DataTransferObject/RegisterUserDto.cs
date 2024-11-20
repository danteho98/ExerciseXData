using System.ComponentModel;
using static ExerciseXData_UserLibrary.Models.UserGender;
using static ExerciseXData_UserLibrary.Models.UsersModel;

namespace ExerciseXData_UserLibrary.DataTransferObject
{
    namespace ExerciseXData_UserLibrary.DTOs
    {
        public class RegisterUserDto
        {
            public string Email { get; set; }
            public string UserName { get; set; }
            public string Password { get; set; }
            public string ConfirmPassword { get; set; }
            public string Gender { get; set; }
            public int Age { get; set; }
            public double Height { get; set; }
            public double Weight { get; set; }
            public string Goal { get; set; }
            public string LifeStyle1 { get; set; }
            public string LifeStyle2 { get; set; }
            public string LifeStyle3 { get; set; }
            public string LifeStyle4 { get; set; }
            public string LifeStyle5 { get; set; }
        }
    }

}

