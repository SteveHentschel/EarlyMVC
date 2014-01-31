using System;
using System.ComponentModel.DataAnnotations;

namespace MiniContoso.Models
{
    public class StudentMetadata
    {
        [StringLength(50)]
        public string LastName;

        [StringLength(50)]
        public string FirstName;

        [StringLength(50)]
        public string MiddleName;

        [DataType(DataType.Date)]
        public Nullable<System.DateTime> EnrollmentDate;
    }

    public class EnrollmentMetadata
    {
        [Range(0, 4)]
        public Nullable<decimal> Grade;
    }
}