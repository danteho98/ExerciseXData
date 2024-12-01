
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ExerciseXData_DietLibrary.Models
{
    public class FoodsModel
    {
        [Key]
        public int F_Id { get; set; }

        [DisplayName ("Food Image")]
        public byte[] ? F_Image { get; set; }

        [DisplayName ( "Food Name")]
        public string ? F_Name { get; set; }

        [DisplayName("Food Group")]
        public string ? F_Group { get; set; }

        [DisplayName ("Food Calorie in kcal")]
        public int ? F_Calories { get; set; }

        [DisplayName("Date Modified")]
        public DateTime F_Modified_Date { get; set; } = DateTime.Now;

        //Relationship
        public List<DietsFoodsModel>DietsFoods { get; set; }
        

    }
}
