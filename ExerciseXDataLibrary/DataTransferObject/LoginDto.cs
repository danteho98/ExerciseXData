

using System.ComponentModel.DataAnnotations;

namespace ExerciseXData_UserLibrary.DataTransferObject
{
    public class LoginDto
    {
        public string Email { get; set; }
        public string Password { get; set; }
        [Display(Name = "Remember Me")]
        public bool RememberMe { get; set; }
    }
}
