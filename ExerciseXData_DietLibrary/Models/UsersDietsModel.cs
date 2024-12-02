﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;


namespace ExerciseXData_DietLibrary.Models
{
    public class UsersDietsModel
    {

        [DisplayName("User Id")]
        public string U_Id { get; set; }
       // public UsersModel Users { get; set; }

        [ForeignKey("D_Id")]
        [DisplayName("Diet Id")]
        public int D_Id { get; set; }
        public DietsModel Diets { get; set; }

        [DisplayName("Custom Diet name")]
        public string? Custom_Diet_Name { get; set; }

        [DisplayName("Serving Size")]
        public int? UD_Serving_Size { get; set; }

        [DisplayName("Frequency (Day/week/month)")]
        public string? UD_Frequency { get; set; }

        [DisplayName("Total Calories")]
        public int? UD_Total_Calaroies { get; set; }

        [DisplayName("Date Modified")]
        public DateTime UD_Modified_Date { get; set; } = DateTime.Now;

        public DateTime UD_Start_Date { get; set; }

        public DateTime UD_End_Date { get; set; }

        public bool UD_Completed { get; set; }  

    }
}
