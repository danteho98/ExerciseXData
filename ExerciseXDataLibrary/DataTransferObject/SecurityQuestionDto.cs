using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExerciseXData_UserLibrary.DataTransferObject
{
    public class SecurityQuestionViewModel
    {
        [Required(ErrorMessage = "Please select a security question.")]
        public string SelectedQuestion { get; set; }

        [Required(ErrorMessage = "Please provide an answer to the selected question.")]
        public string Answer { get; set; }
        public List<string> AvailableQuestions { get; set; } = new List<string>
    {
        "What is your mother’s maiden name?",
        "What was the name of your first pet?",
        "What was the make and model of your first car?",
        "What elementary school did you attend?",
        "What is the name of the town or city where you were born?",
        "What is your favorite childhood memory?",
        "What is your favorite book or movie?",
        "What is your father’s middle name?",
        "What was your childhood nickname?",
        "What was the name of your first school teacher?"
    };
    }

}
