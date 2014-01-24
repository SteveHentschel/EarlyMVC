using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MVC4_ContosoU.Models
{
    public class Person
    {
        [Key]
        public int PersonID { get; set; }

        [RegularExpression(@"^[A-Z]+[a-zA-Z''-'\s]*$"), StringLength(50, MinimumLength = 1)]    // Can combine ...
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Column("FirstName")]
        [Display(Name = "First Name")]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "First name must be between 2 and 50 characters.")]
        public string FirstMidName { get; set; }

        public string FullName
        {
            get
            {
                return LastName + ", " + FirstMidName;
            }
        }
    }
}