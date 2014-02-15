using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BundleAndViewModel.Models
{
    public class MyCustomer
    {
        private string _CustomerName;

        public string CustomerName
        {
            get { return _CustomerName; }
            set { _CustomerName = value; }
        }

        private double _Amount;

        public double Amount
        {
            get { return _Amount; }
            set { _Amount = value; }
        }
    }
}