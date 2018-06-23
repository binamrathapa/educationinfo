using System;
using System.Collections.Generic;
using EducationInfo.Core.Entities;

namespace EducationInfo.Core.Services
{
    public interface ICourseService
    {
        Course Add(Course product);
        void Delete(int Id);
        IEnumerable<Course> GetBy(Func<Course, bool> predicate = null);
        IEnumerable<Course> GetAll();
        Course GetById(int? Id);
        Course Update(Course product);
    }
}