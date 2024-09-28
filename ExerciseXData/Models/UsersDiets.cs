using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace ExerciseXData.Models
{
    public class UsersDiets
    {
        [Key]
        //public int UD_Id { get; set; }

        //Relationships
        //[ForeignKey("U_Id")]
        public int U_Id { get; set; }
        public Users Users { get; set; }

        //[ForeignKey("D_Id")]
        public int D_Id { get; set; }
        public Diets Diets { get; set; }

        [DisplayName("Food name")]
        public int ? Food_Name { get; set; }

        [DisplayName("Food quantity")]
        public int ? Food_Quantity { get; set; }

        [DisplayName("Food Calories")]
        public int ? Food_Calories { get; set; }

        [DisplayName("Total Calories")]
        public int ? Total_Calaroies { get; set; }

        [DisplayName("Date Modified")]
        public DateTime UD_Modified_Date { get; set; } = DateTime.Now;

    }
}
