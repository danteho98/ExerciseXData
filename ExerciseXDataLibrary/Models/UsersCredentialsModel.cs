using ExerciseXData.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExerciseXDataLibrary.Models
{
    public class UsersCredentialsModel
    {
        [Key]
        [DisplayName ("Credential Id")]
        public int Cre_Id { get; set; }

        [ForeignKey("U_Id")]
        [DisplayName("User Id")]
        public int U_Id { get; set; }
        public UsersModel Users { get; set; }

        //[DisplayName ("Password")]
        //public string? Password { get; set; }

        [DisplayName("Password Hush")]
        public string Password_Hush { get; set; }

        [DisplayName("Password Salt")]
        public string Password_Salt { get; set; }

        [DisplayName("Last Updated")]
        public DateTime Last_Updated { get; set; }
    }
}
