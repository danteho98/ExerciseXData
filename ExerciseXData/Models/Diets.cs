using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace ExerciseXData.Models
{
    public class Diets
    {
        [Key]
        public int D_Id { get; set; }

        //[Required]
        [DisplayName("Exercise Name")]/*This part allows programmer to put any name*/
        public string ? D_Name { get; set; }

        [DisplayName("Description")]/*This part allows programmer to put any name*/
        public string ? D_Description { get; set; }

        [DisplayName("Food Name")]
        public string ? F_Name { get; set; }

        [DisplayName("Food Amount")]
        public int ? F_Amount { get; set; }

        [DisplayName("Total Calories")]
        public int ? D_Total_Calories { get; set; }

        //[Required]
        [DisplayName("Diets Pros 1")]
        public string ? D_Pros_1 { get; set; }

        [DisplayName("Diets Pros 2")]
        public string ? D_Pros_2 { get; set; }

        [DisplayName("Diets Pros 3")]
        public string ? D_Pros_3 { get; set; }

        //[Required]
        [DisplayName("Diets Cons 1")]
        public string ? D_Cons_1 { get; set; }

        [DisplayName("Diets Cons 2")]
        public string ? D_Cons_2 { get; set; }

        [DisplayName("Diets Cons 3")]
        public string ? D_Cons_3 { get; set; }

        [DisplayName("Modified Date")]
        public DateTime D_Modified_Date { get; set; } = DateTime.Now;


        //Relationships
        public ICollection<DietsFoods> DietsFoods { get; set; }
        public ICollection<UsersDiets> UsersDiets { get; set; }
        
    }
}