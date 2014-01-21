
namespace MVC4_ContosoU.ViewModels
{
    public class AssignedCourseData                 // Used for Instructor Courses checkbox list
    {
        public int CourseID { get; set; }
        public string Title { get; set; }
        public bool Assigned { get; set; }
    }
}