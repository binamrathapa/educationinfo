using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EducationInfo.Core.Entities
{
    public partial class AssignmentSubmittedByStudent : IEntityBase
    {
        public int Id { get; set; }
        public int? StudentId { get; set; }
        public int? AssignmentId { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? SubmittedDate { get; set; }
        [Column(TypeName = "decimal(18, 0)")]
        public decimal? AssignmentMarks { get; set; }
        [StringLength(250)]
        public string ProjectLocation { get; set; }

        [ForeignKey("AssignmentId")]
        [InverseProperty("AssignmentSubmittedByStudent")]
        public Assignment Assignment { get; set; }
        [ForeignKey("StudentId")]
        [InverseProperty("AssignmentSubmittedByStudent")]
        public Student Student { get; set; }
    }
}
