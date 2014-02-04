using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PhotoGalleryLab1.Controllers
{
    public class PhotoLab1Controller : Controller
    {
        //
        // GET: /PhotoLab1/

        public ActionResult Gallery()
        {
            System.Threading.Thread.Sleep(700);            // to test timeout cancellation token in Index

            return this.File("~/App_Data/Photos.json", "application/json");
        }

    }
}
