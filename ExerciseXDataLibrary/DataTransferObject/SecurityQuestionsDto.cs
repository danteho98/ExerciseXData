using ExerciseXData_UserLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExerciseXData_UserLibrary.DataTransferObject
{
    public class SecurityQuestionsDto
    {
        public string Email { get; set; }
        public List<SecurityQuestionModel> SecurityQuestions { get; set; }
        public Dictionary<int, string> Answers { get; set; }
    }
}
