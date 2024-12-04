using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using ExerciseXData_UserLibrary.Models;


namespace ExerciseXData_DietLibrary.Models
{
    public class UsersDietsModel
    {
        public int UD_Id { get; set; }

        [DisplayName("User Id")]
        public string UserId { get; set; }
        public UsersModel User { get; set; }

        [ForeignKey("D_Id")]
        [DisplayName("Diet Id")]
        public int D_Id { get; set; }
        public DietsModel Diet { get; set; }

        [DisplayName("Custom Diet name")]
        public string? CustomDietName { get; set; }

        [DisplayName("Serving Size")]
        public int? UD_ServingSize { get; set; }

        [DisplayName("Frequency (Day/week/month)")]
        public string? UD_Frequency { get; set; }

        [DisplayName("Total Calories")]
        public int? UD_TotalCalaroies { get; set; }

        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public bool IsCompleted { get; set; }

        [DisplayName("Date Modified")]
        public DateTime UD_Modified_Date { get; set; } = DateTime.Now;

  

    }
}
