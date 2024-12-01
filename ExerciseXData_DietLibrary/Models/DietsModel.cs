﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel;


namespace ExerciseXData_DietLibrary.Models
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
        public ICollection<DietsFoodsModel> DietsFoods { get; set; }
    
    }
}