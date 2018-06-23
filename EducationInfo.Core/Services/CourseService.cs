using EducationInfo.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace EducationInfo.Core.Services
{    
     public class CourseService : ICourseService
    {
        private readonly IUnitOfWork uow;

        public CourseService(IUnitOfWork uow) 
        {
            this.uow = uow;
        }
        #region Web Methods

        public Course GetById(int? Id)
        {
            return uow.Repository<Course>().GetById(Id);
        }
        public IEnumerable<Course> GetAll()
        {
            return uow.Repository<Course>().Query().Include(n => n.NoteInfo).Get();//.GetAll();
        }

        public IEnumerable<Course> GetBy(Func<Course, bool> predicate = null)
        {
            return uow.Repository<Course>().GetBy(predicate);
        }

        public Course Add(Course course)
        {
            uow.Repository<Course>().Add(course);
            return course;
        }

        public Course Update(Course course)
        {
            uow.Repository<Course>().Update(course);
            return course;
        }

        public void Delete(int Id)
        {
            uow.Repository<Course>().Delete(Id);
        }

        #endregion

    }
}
