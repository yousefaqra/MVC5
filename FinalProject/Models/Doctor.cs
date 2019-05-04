using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FinalProject.Models
{
    public class Doctor
    {
        [Key]
        public int ID { get; set; }
        public string Code { get; set; }

        [RegularExpression(@"^[A-Z]+[a-zA-Z""'\s-]*$", ErrorMessage = "Last name should start with an upper case letter and contains no spaces")]
        [StringLength(30, ErrorMessage = "First name cannot be more than 30 characters")]
        public string FirstName { get; set; }

        [RegularExpression(@"^[A-Z]+[a-zA-Z""'\s-]*$", ErrorMessage = "Last name should start with an upper case letter and contains no spaces")]
        [StringLength(30, ErrorMessage = "First name cannot be more than 30 characters")]
        public string LastName { get; set; }
        public string Specialization { get; set; }
        public string Hospital { get; set; }
        public bool isDeleted { get; set; }
        
    }
}
