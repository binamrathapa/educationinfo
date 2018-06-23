using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EducationInfo.Core.Entities
{
    public partial class CoursesPerUniversity : IEntityBase
    {
        public int Id { get; set; }
        public int? CourseId { get; set; }
        public int? UniversityId { get; set; }

        [ForeignKey("CourseId")]
        [InverseProperty("CoursesPerUniversity")]
        public Course Course { get; set; }
        [ForeignKey("UniversityId")]
        [InverseProperty("CoursesPerUniversity")]
        public University University { get; set; }
    }
}
