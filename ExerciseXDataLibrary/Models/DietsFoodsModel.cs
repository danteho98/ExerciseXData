using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ExerciseXData.Models
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

        [DisplayName("Modified Date")]
        public DateTime DF_Modified_Date { get; set; } = DateTime.Now;

    }
}
