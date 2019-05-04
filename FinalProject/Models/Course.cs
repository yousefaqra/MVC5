using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FinalProject.Models
{
    public class Course
    {
      
        public int ID { get; set; }
        public Doctor Doctor { get; set; }

        [StringLength(40)]
        public string Name { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime Date { get; set; }
        public int GroupID { get; set; }
        //public GroupsSetup Group { get; set; }
    }
}
