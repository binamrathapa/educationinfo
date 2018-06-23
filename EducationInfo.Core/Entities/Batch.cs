using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EducationInfo.Core.Entities
{
    public partial class Batch : IEntityBase
    {
        public Batch()
        {
            Assignment = new HashSet<Assignment>();
            Student = new HashSet<Student>();
        }

        public int Id { get; set; }
        [Required]
        [StringLength(50)]
        public string Name { get; set; }
        [Column(TypeName = "date")]
        public DateTime? BatchDate { get; set; }

        [InverseProperty("Batch")]
        public ICollection<Assignment> Assignment { get; set; }
        [InverseProperty("Batch")]
        public ICollection<Student> Student { get; set; }
    }
}
