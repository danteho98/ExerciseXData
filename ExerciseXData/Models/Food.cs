﻿using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ExerciseXData.Models
{
    public class Food
    {
        [Key]
        public int F_Id { get; set; }

        [Display(Name = "Food Image")]
        public string ? F_Image { get; set; }

        [Display(Name = "Food Name")]
        public string F_Name { get; set; }

        [Display(Name = "Food Calorie in kcal (per 100 grams)")]
        public int F_Food_Calories { get; set; }

        //public date Modify_Date_ { get; set; }

        //Relationship
        public List<UserDiet> UserDiet { get; set; }

        //Diets
        [Display(Name ="Diet Id")]
        [ForeignKey("DietId")]
        public int DietId { get; set; }
        public Diet Diet { get; set; }

        
    }
}
