using ExerciseXData_ExerciseLibrary.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using Microsoft.AspNetCore.Mvc.Rendering;
using System.Web.Mvc;


namespace ExerciseXData_ExerciseLibrary.DataTransferObject
{
    public class CreateExerciseViewModel
    {
       
        public int CategoriesC_Id { get; set; }

        [DisplayName("Exercises Image")]
        public byte[]? E_Image { get; set; }

        //[Required(ErrorMessage = "Exercises name cannot be empty.")]
        [DisplayName("Exercises Name")] /*This part allows programmer to put any name*/
        public string ? E_Name { get; set; }

        //[Required(ErrorMessage = "Exercises description cannot be empty.")]
        [DisplayName("Exercises Description")]
        public string? E_Description { get; set; }

        //[Required(ErrorMessage = "Exercises Pros 1 cannot be empty.")]
        [DisplayName("Exercises Pros 1")]
        public string? E_Pros_1 { get; set; }

        [DisplayName("Exercises Pros 2")]
        public string? E_Pros_2 { get; set; }

        [DisplayName("Exercises Pros 3")]
        public string? E_Pros_3 { get; set; }

        //[Required(ErrorMessage = "Exercises Cons 1 cannot be empty.")]
        [DisplayName("Exercises Cons 1")]
        public string? E_Cons_1 { get; set; }

        [DisplayName("Exercises Cons 2")]
        public string? E_Cons_2 { get; set; }

        [DisplayName("Exercises Cons 3")]
        public string? E_Cons_3 { get; set; }
    }
}


