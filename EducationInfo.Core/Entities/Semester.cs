using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EducationInfo.Core.Entities
{
    public partial class Semester : IEntityBase
    {
        public Semester()
        {
            Assignment = new HashSet<Assignment>();
            Student = new HashSet<Student>();
        }

        public int Id { get; set; }
        [StringLength(50)]
        public string Name { get; set; }

        [InverseProperty("Semester")]
        public ICollection<Assignment> Assignment { get; set; }
        [InverseProperty("Semester")]
        public ICollection<Student> Student { get; set; }
    }
}
