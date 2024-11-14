using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExerciseXDataLibrary.DataTransferObject
{
    public class ExerciseDto
    {
        public string Name { get; set; }
        public int Repetition { get; set; }
        public int Duration { get; set; } // in minutes
        public int Sets { get; set; }
    }
}
