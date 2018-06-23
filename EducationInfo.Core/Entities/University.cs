using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EducationInfo.Core.Entities
{
    public partial class University : IEntityBase
    {
        public University()
        {
            College = new HashSet<College>();
            CoursesPerUniversity = new HashSet<CoursesPerUniversity>();
        }

        public int Id { get; set; }
        [StringLength(50)]
        public string Name { get; set; }

        [InverseProperty("University")]
        public ICollection<College> College { get; set; }
        [InverseProperty("University")]
        public ICollection<CoursesPerUniversity> CoursesPerUniversity { get; set; }
    }
}
