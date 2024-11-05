using ExerciseXData.Models;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ExerciseXDataLibrary.Models
{
    public class DietsFoodsModel
    {
        [Key]
        public int DF_Id {  get; set; }

        [DisplayName("Diet Id")]
        //[ForeignKey("D_Id")]
        public int D_Id { get; set; }
        public DietsModel Diets { get; set; }

        [DisplayName("Food Id")]
        //[ForeignKey("F_Id")]
        public int ? F_Id { get; set; }
        public FoodsModel Foods { get; set; }

        [DisplayName("Serving Size")]
        public string? DF_Serving_Size { get; set; }

        [DisplayName("Recommended Servings")]
        public string? DF_Recommended_Servings { get; set; }

        [DisplayName("Frequency")]
        public string? DF_Frequency { get; set; }

        [DisplayName("Total Colories")]
        public string ? DF_Total_Calories { get; set; }

        [DisplayName("Modified Date")]
        public DateTime DF_Modified_Date { get; set; } = DateTime.Now;

    }
}
