using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EF_Scaff_Mig.Models
{
    public class Person
    {
        public int PersonID { get; set; }

        public string FirstName { get; set; }

        public string MiddleName { get; set; }

        public string LastName { get; set; }

        [DataType(DataType.Date)]
        public DateTime Birthday { get; set; }
    }
}