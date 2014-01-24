
using System.ComponentModel.DataAnnotations;

namespace MVC4_ContosoU.Models
{
    public enum Grade
    {
        A, B, C, D, F
    }
    
    public class Enrollment
    {
        public int EnrollmentID { get; set; }

        public int CourseID { get; set; }

        public int PersonID { get; set; }

        [DisplayFormat(NullDisplayText = "No grade")]               // Nice; useful.
        public Grade? Grade { get; set; }

        public virtual Course Course { get; set; }
        public virtual Student Student { get; set; }
    }
}