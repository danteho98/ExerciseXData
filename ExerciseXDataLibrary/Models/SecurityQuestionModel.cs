using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExerciseXData_UserLibrary.Models
{
    public class SecurityQuestionModel
    {
        [DisplayName("Security Question Id")]
        public int SQ_Id { get; set; }
        public string Question { get; set; }
        public string Answer { get; set; }

        [DisplayName("User Id")]
        public string U_Id { get; set; } // Foreign Key to UsersModel
        public UsersModel Users { get; set; }
    }
}
