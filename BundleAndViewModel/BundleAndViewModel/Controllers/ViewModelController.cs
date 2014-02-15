using BundleAndViewModel.Models;
using BundleAndViewModel.MyViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BundleAndViewModel.Controllers
{
    public class ViewModelController : Controller
    {
        //
        // GET: /ViewModel/

        public ActionResult MyCustomerDisplay()
        {
            MyCustomerVM model = new MyCustomerVM();

            model.TxtName = "Leo DaVinci";
            model.TxtAmount = "50";
            
            return View(model);
        }

    }
}
