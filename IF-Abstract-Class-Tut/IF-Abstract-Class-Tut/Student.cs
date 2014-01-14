using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IF_Abstract_Class_Tut
{
    class Student
    {
        public DateTime DateOfBirth { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string EnrollmentNumber { get; set; }

        public int GetAge(DateTime currentDate)
        {
            return currentDate.Year - DateOfBirth.Year;
        }
    }
}
