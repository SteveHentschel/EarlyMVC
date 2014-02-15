using BundleAndViewModel.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BundleAndViewModel.MyViewModels
{
    public class MyCustomerVM
    {
        private MyCustomer Customer = new MyCustomer();
        public string TxtName
        {
            get { return Customer.CustomerName; }
            set { Customer.CustomerName = value; }
        }

        public string TxtAmount
        {
            get { return Customer.Amount.ToString(); }
            set { Customer.Amount = Convert.ToDouble(value); }
        }

        public string CustomerLevelColor
        {
            get
            {
                if (Customer.Amount > 2000)
                {
                    return "red";
                }
                else if (Customer.Amount > 1500)
                {
                    return "orange";
                }
                else
                {
                    return "yellow";
                }
            }

        }
    }
}