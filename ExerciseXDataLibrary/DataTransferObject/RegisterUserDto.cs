using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExerciseXDataLibrary.DataTransferObject
{
    public class RegisterUserDto
    {
        //[Required, EmailAddress]
        public string Email { get; set; }
        public string UserName { get; set; }

        //[Required, MinLength(6)]
        public string Password { get; set; }
        public string Gender { get; set; }
        public int Age { get; set; }
        public double Height { get; set; }
        public double Weight { get; set; }
        public string Goal { get; set; }
    }
}
