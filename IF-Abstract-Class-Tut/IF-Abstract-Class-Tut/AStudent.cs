using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IF_Abstract_Class_Tut
{
    abstract class AStudent
    {
        public DateTime DateOfBirth { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string EnrollmentNumber { get; set; }

        public int GetAge(DateTime currentDate)
        {
            return currentDate.Year - DateOfBirth.Year;
        }

        public abstract double GetFee();
    }

    class RegularStudent : AStudent
    {
        public override Double GetFee()
        {
            // find fee from somewhere and return
            return 10000f;
        }
    }
}
