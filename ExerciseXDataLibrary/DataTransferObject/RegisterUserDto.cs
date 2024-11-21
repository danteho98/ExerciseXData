

using ExerciseXData_UserLibrary.Models;

namespace ExerciseXData_UserLibrary.DataTransferObject
{
        public class RegisterUserDto
        {
            public string Email { get; set; }
            public string UserName { get; set; }
            public string Password { get; set; }
            public string ConfirmPassword { get; set; }
            public UserGender.Gender Gender { get; set; }
            public int Age { get; set; }
            public double Height { get; set; }
            public double Weight { get; set; }
            public string Goal { get; set; }
            public string ? LifestyleCondition1 { get; set; }
            public string ? LifestyleCondition2 { get; set; }
            public string ? LifestyleCondition3 { get; set; }
            public string ? LifestyleCondition4 { get; set; }
            public string ? LifestyleCondition5 { get; set; }
        }
    }



