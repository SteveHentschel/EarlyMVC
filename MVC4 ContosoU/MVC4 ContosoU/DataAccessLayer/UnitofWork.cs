using MVC4_ContosoU.Models;
using System;

namespace MVC4_ContosoU.DataAccessLayer
{
    public class UnitOfWork : IDisposable
    {
        private SchoolContext context = new SchoolContext();                //  Create db Context variables
        private GenericRepository<Department> departmentRepository;         //    and specific repositories
  //      private GenericRepository<Course> courseRepository;
        private CourseRepository courseRepository;                          //  ** Raw SQL Update example

        public GenericRepository<Department> DepartmentRepository
        {
            get
            {

                if (this.departmentRepository == null)
                {
                    this.departmentRepository = new GenericRepository<Department>(context);
                }
                return departmentRepository;
            }
        }

 //       public GenericRepository<Course> CourseRepository                 //  ** remove Generic for SQL update
        public CourseRepository CourseRepository
        {
            get
            {

                if (this.courseRepository == null)
                {
  //                  this.courseRepository = new GenericRepository<Course>(context);
                    this.courseRepository = new CourseRepository(context);
                }
                return courseRepository;
            }
        }

        public void Save()
        {
            context.SaveChanges();
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}