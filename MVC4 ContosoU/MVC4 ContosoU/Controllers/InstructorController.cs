using System;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;
using MVC4_ContosoU.Models;
using MVC4_ContosoU.ViewModels;
using MVC4_ContosoU.DataAccessLayer;
using System.Collections.Generic;

namespace MVC4_ContosoU.Controllers
{
    public class InstructorController : Controller
    {
        private SchoolContext db = new SchoolContext();

        //
        // GET: /Instructor/

        public ActionResult Index(int? id, int? courseID)
        {
            var viewModel = new InstructorIndexData();
            viewModel.Instructors = db.Instructors
                .Include(i => i.OfficeAssignment)                       // Eager loading for Instructor.OfficeAssignment
                .Include(i => i.Courses.Select(c => c.Department))      // Eager loading also for Instructor.Department
                .OrderBy(i => i.LastName);                              //  (all in one db query; efficient for this case)

            if (id != null)
            {
                ViewBag.PersonID = id.Value;                        
                viewModel.Courses = viewModel.Instructors.Where(
                    i => i.PersonID == id.Value).Single().Courses;
            }

            if (courseID != null)
            {
                ViewBag.CourseID = courseID.Value;

                var selectedCourse = viewModel.Courses.Where(x => x.CourseID == courseID).Single();
                ViewBag.Course = selectedCourse;                                    // Add for Course Display (slh)

                db.Entry(selectedCourse).Collection(x => x.Enrollments).Load();     // Adding "Explicit Loading" for example only   
                foreach (Enrollment enrollment in selectedCourse.Enrollments)       //  (lazy loading <by default> 
                {                                                                   //    would have worked fine here as well)
                    db.Entry(enrollment).Reference(x => x.Student).Load();
                }

                viewModel.Enrollments = selectedCourse.Enrollments;
            }

            return View(viewModel);
        }

        //
        // GET: /Instructor/Details/5

        public ActionResult Details(int id = 0)
        {
            Instructor instructor = db.Instructors.Find(id);
            if (instructor == null)
            {
                return HttpNotFound();
            }
            return View(instructor);
        }

        //
        // GET: /Instructor/Create

        public ActionResult Create()
        {
            ViewBag.PersonID = new SelectList(db.OfficeAssignments, "PersonID", "Location");
            return View();
        }

        //
        // POST: /Instructor/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Instructor instructor)
        {
            if (ModelState.IsValid)
            {
                db.Instructors.Add(instructor);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.PersonID = new SelectList(db.OfficeAssignments, "PersonID", "Location", instructor.PersonID);
            return View(instructor);
        }

        //
        // GET: /Instructor/Edit/5

        public ActionResult Edit(int id)
        {
            Instructor instructor = db.Instructors
                .Include(i => i.OfficeAssignment)                       // Use eager loading to get Office data
                .Include(i => i.Courses)                                //   and Course data
                .Where(i => i.PersonID == id)
                .Single();

            PopulateAssignedCourseData(instructor);
            return View(instructor);
        }

        private void PopulateAssignedCourseData(Instructor instructor)
        {
            var allCourses = db.Courses;
            var instructorCourses = new HashSet<int>(instructor.Courses.Select(c => c.CourseID));
            var viewModel = new List<AssignedCourseData>();
            foreach (var course in allCourses)
            {
                viewModel.Add(new AssignedCourseData
                {
                    CourseID = course.CourseID,
                    Title = course.Title,
                    Assigned = instructorCourses.Contains(course.CourseID)
                });
            }
            ViewBag.Courses = viewModel;
        }

        //
        // POST: /Instructor/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, FormCollection formCollection, string[] selectedCourses)
        {
            var instructorToUpdate = db.Instructors
                .Include(i => i.OfficeAssignment)
                .Include(i => i.Courses)
                .Where(i => i.PersonID == id)
                .Single();

            if (TryUpdateModel(instructorToUpdate, "",
                                    new string[] { "LastName", "FirstMidName", "HireDate", "OfficeAssignment" }))
            {
                try
                {
                    if (String.IsNullOrWhiteSpace(instructorToUpdate.OfficeAssignment.Location))
                    {
                        instructorToUpdate.OfficeAssignment = null;
                    }

                    UpdateInstructorCourses(selectedCourses, instructorToUpdate);

                    db.Entry(instructorToUpdate).State = EntityState.Modified;
                    db.SaveChanges();

                    return RedirectToAction("Index");
                }
                catch (DataException /* dex */)
                {
                    //Log the error (uncomment dex variable name after DataException and add a line here to write a log.
                    ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists, see your system administrator.");
                }
            }

            PopulateAssignedCourseData(instructorToUpdate);
            return View(instructorToUpdate);
        }

        private void UpdateInstructorCourses(string[] selectedCourses, Instructor instructorToUpdate)
        {
            if (selectedCourses == null)
            {
                instructorToUpdate.Courses = new List<Course>();
                return;
            }

            var selectedCoursesHS = new HashSet<string>(selectedCourses);
            var instructorCourses = new HashSet<int>
                (instructorToUpdate.Courses.Select(c => c.CourseID));
            foreach (var course in db.Courses)
            {
                if (selectedCoursesHS.Contains(course.CourseID.ToString()))
                {
                    if (!instructorCourses.Contains(course.CourseID))
                    {
                        instructorToUpdate.Courses.Add(course);
                    }
                }
                else
                {
                    if (instructorCourses.Contains(course.CourseID))
                    {
                        instructorToUpdate.Courses.Remove(course);
                    }
                }
            }
        }

        //
        // GET: /Instructor/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Instructor instructor = db.Instructors.Find(id);
            if (instructor == null)
            {
                return HttpNotFound();
            }
            return View(instructor);
        }

        //
        // POST: /Instructor/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Instructor instructor = db.Instructors
              .Include(i => i.OfficeAssignment)
              .Where(i => i.PersonID == id)
              .Single();

            instructor.OfficeAssignment = null;                     // Make sure to clear any office space
            db.Instructors.Remove(instructor);
            db.SaveChanges();

            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}