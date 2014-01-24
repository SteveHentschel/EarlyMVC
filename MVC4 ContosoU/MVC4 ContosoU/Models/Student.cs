using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MVC4_ContosoU.Models
{
    public class Student : Person
    {
        [DataType(DataType.Date)]
        [Display(Name = "Enrollment Date")]
        public DateTime EnrollmentDate { get; set; }

        public virtual ICollection<Enrollment> Enrollments { get; set; }
    }
}