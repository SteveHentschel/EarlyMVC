using System;

namespace Partial_Class
{
    public partial class Person
    {
        public int Age
        {
            get { return Convert.ToInt32(System.DateTime.UtcNow.Date.Year - _birthDate.Value.Year); }
        }
    }
}