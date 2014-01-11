using AJAX_Training.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

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

        [HttpGet]
        public ActionResult _CreatePopUp()
        {
            return PartialView("_CreatePopUp");
        }

        [HttpPost]
        public void Create(Training training)
        {
            _trainingRepository.InsertTraining(training);
        }

        [HttpGet]
        public JsonResult GetInstructorList()
        {
            var allInstructors = _trainingRepository.GetInstructor().ToList();
            return Json(allInstructors, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult _EditPopUp(string id)
        {
            int selectedTrainingId = Convert.ToInt32(id);
            Training selectedTraining = _trainingRepository.GetTrainingByID(selectedTrainingId);

            return PartialView("_EditPopUp", selectedTraining);
        }

        [HttpPost]
        public void Edit(Training training)
        {
            _trainingRepository.EditTraining(training);
        }

        public void Delete(string id)
        {
            int selectedTrainingId = Convert.ToInt32(id);
            _trainingRepository.DeleteTraining(selectedTrainingId);
        }
    }
}
