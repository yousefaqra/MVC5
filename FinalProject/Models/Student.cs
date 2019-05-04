using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FinalProject.Models
{
    public class Student
    {
        [Key]
        public int ZajelID { get; set; }

        [RegularExpression(@"^[A-Z]+[a-zA-Z""'\s-]*$", ErrorMessage = "First name should start with an upper case letter and contains no spaces")]
        [StringLength(30, ErrorMessage = "First name cannot be more than 30 characters")]
        public string FirstName { get; set; }

        [RegularExpression(@"^[A-Z]+[a-zA-Z""'\s-]*$", ErrorMessage = "Last name should start with an upper case letter and contains no spaces")]
        [StringLength(30, ErrorMessage = "First name cannot be more than 30 characters")]
        public string LastName { get; set; }
        public string Adress { get; set; }
        public char Gender { get; set; }
        public double GDPA { get; set; }
        public bool Toofel { get; set; }
        public int NumberOFHourse { get; set; }
        public int GroupID { get; set; }
      
    }
}
