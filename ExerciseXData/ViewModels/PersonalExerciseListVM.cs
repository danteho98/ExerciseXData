using System.ComponentModel;

namespace ExerciseXData.ViewModels
{
    public class PersonalExerciseListVM
    {

        public string Name { get; set; }

        public string Category { get; set; }

        [DisplayName("Times performed")]
        public int TimesPerformed { get; set; }

        [DisplayName("Modify date")]
        public DateTime ModifyDate { get; set; } = DateTime.Now;
    }
}
