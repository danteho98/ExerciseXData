﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExerciseXData_UserLibrary.DataTransferObject
{
    public class ResetPasswordDto
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
