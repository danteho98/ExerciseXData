﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace ExerciseXData.Models
{
    public class DietsModel
    {
        [Key]
        public int D_Id { get; set; }

        //[Required]
        [DisplayName("Diets Name")]/*This part allows programmer to put any name*/
        public string ? D_Name { get; set; }

        [DisplayName("Description")]/*This part allows programmer to put any name*/
        public string ? D_Description { get; set; }

        [DisplayName("Serving Size")]
        public string ? D_Serving_Size { get; set; }

        [DisplayName("Recommended Servings")]
        public string ? D_Recommended_Servings { get; set; }

        [DisplayName("Frequency")]
        public string ? D_Frequency { get; set; }

        //[Required]
        [DisplayName("Pros 1")]
        public string ? D_Pros_1 { get; set; }

        [DisplayName("Pros 2")]
        public string ? D_Pros_2 { get; set; }

        [DisplayName("Pros 3")]
        public string ? D_Pros_3 { get; set; }

        //[Required]
        [DisplayName("Cons 1")]
        public string ? D_Cons_1 { get; set; }

        [DisplayName("Cons 2")]
        public string ? D_Cons_2 { get; set; }

        [DisplayName("Cons 3")]
        public string ? D_Cons_3 { get; set; }

        [DisplayName("Modified Date")]
        public DateTime D_Modified_Date { get; set; } = DateTime.Now;


        //Relationships
        public List<DietsFoodsModel> DietsFoods { get; set; }
        public List<UsersDietsModel> UsersDiets { get; set; }
        
    }
}