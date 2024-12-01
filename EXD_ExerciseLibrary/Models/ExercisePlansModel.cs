using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;


namespace ExerciseXData_ExerciseLibrary.Models
{
    public class ExercisePlansModel
    {
        [Key]
        public int EP_Id { get; set; }

        [Required]
        [DisplayName("Plan Name")]
        [StringLength(255)]
        public string EP_Name { get; set; }

        [DisplayName("Description")]
        public string? EP_Description { get; set; }

        [DisplayName("Created Date")]
        public DateTime CreatedDate { get; set; } = DateTime.Now;

        // Navigation property for related exercises
        public ICollection<ExercisePlanExercisesModel> ExercisePlanExercises { get; set; }
    }
}
