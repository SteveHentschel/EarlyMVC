using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVC4_ContosoU.DataAccessLayer;
using MVC4_ContosoU.ViewModels;

namespace MVC4_ContosoU.Controllers
{
    public class HomeController : Controller
    {
        private SchoolContext db = new SchoolContext();

        public ActionResult Index()
        {
            ViewBag.Message = "Welcome to Contoso University !";

            return View();
        }

        public ActionResult About()
        {
   //         var data = from student in db.Students                                //  DB access via LINQ
   //                    group student by student.EnrollmentDate into dateGroup
   //                    select new EnrollmentDateGroup()
   //                    {
   //                        EnrollmentDate = dateGroup.Key,
   //                        StudentCount = dateGroup.Count()
   //                    };

            var query = "SELECT EnrollmentDate, COUNT(*) AS StudentCount "          // Raw SQL Query example
                        + "FROM Person "                                            //  eg: return non-entity items
                        + "WHERE EnrollmentDate IS NOT NULL "
                        + "GROUP BY EnrollmentDate";
            var data = db.Database.SqlQuery<EnrollmentDateGroup>(query);            //  direct access via DB.SqlQuery

            return View(data);
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}
