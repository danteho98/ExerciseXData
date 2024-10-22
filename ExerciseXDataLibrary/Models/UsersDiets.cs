using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace ExerciseXData.Models
{
    public class UsersDiets
    {
        [Key]
        public int UD_Id {  get; set; }

        //Relationships
        //[ForeignKey("U_Id")]
        public int U_Id { get; set; }
        public Users Users { get; set; }

        //[ForeignKey("D_Id")]
        public int D_Id { get; set; }
        public Diets Diets { get; set; }

        [DisplayName("Custom Diet name")]
        public string ? Custom_Diet_Name { get; set; }

        [DisplayName("Serving Size")]
        public int ? UD_Serving_Size { get; set; }

        [DisplayName("Frequency (Day/week/month)")]
        public string ? UD_Frequency { get; set; }

        [DisplayName("Total Calories")]
        public int ? Total_Calaroies { get; set; }

        [DisplayName("Date Modified")]
        public DateTime UD_Modified_Date { get; set; } = DateTime.Now;

    }
}
