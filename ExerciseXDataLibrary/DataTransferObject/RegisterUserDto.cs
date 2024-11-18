using System.ComponentModel;
using static ExerciseXDataLibrary.Models.UserGender;
using static ExerciseXDataLibrary.Models.UsersModel;

namespace ExerciseXDataLibrary.DataTransferObject
{
    public class RegisterUserDto
    {
        //[Required, EmailAddress]
        public string Email { get; set; }
        public string UserName { get; set; }

        //[Required, MinLength(6)]
        public string Password { get; set; }
        public Gender Gender { get; set; }
        public int Age { get; set; }
        public double Height { get; set; }
        public double Weight { get; set; }
        public string Goal { get; set; }

        [DisplayName("Lifestyle Condition 1")]
        public string? Lifestyle_Condition_1 { get; set; }

        [DisplayName("Lifestyle Condition 2")]
        public string? Lifestyle_Condition_2 { get; set; }

        [DisplayName("Lifestyle Condition 3")]
        public string? Lifestyle_Condition_3 { get; set; }

        [DisplayName("Lifestyle Condition 4")]
        public string? Lifestyle_Condition_4 { get; set; }

        [DisplayName("Lifestyle Condition 5")]
        public string? Lifestyle_Condition_5 { get; set; }
    }
}
