using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExerciseXData_UserLibrary.Models
{
    public class UserSecurityQuestionModel
    {
        [DisplayName("User Id")]
        public string U_Id { get; set; }
        public UsersModel Users { get; set; }

        public int SecurityQuestionId { get; set; }
        public SecurityQuestionModel UserSecurityQuestions { get; set; }

        public string Answer { get; set; }
    }

}
