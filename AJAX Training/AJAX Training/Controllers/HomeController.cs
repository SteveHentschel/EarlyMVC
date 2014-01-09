using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AJAX_Training.Models;

namespace AJAX_Training.Controllers
{
    public class HomeController : Controller
    {
        TrainingRepo _trainingRepository = new TrainingRepo();

        public ActionResult Index()
        {
            List<Training> allTrainings = _trainingRepository.GetTrainings().ToList();
            return View(allTrainings);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}