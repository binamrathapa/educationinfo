using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EducationInfo.Core.Entities
{
    public partial class College : IEntityBase
    {
        public College()
        {
            Assignment = new HashSet<Assignment>();
        }

        public int Id { get; set; }
        [Required]
        [StringLength(250)]
        public string Name { get; set; }
        [StringLength(150)]
        public string AffiliatedBy { get; set; }
        public int? UniversityId { get; set; }

        [ForeignKey("UniversityId")]
        [InverseProperty("College")]
        public University University { get; set; }
        [InverseProperty("College")]
        public ICollection<Assignment> Assignment { get; set; }
    }
}
