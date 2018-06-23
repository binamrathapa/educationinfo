using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EducationInfo.Core.Entities
{
    public partial class Assignment:IEntityBase
    {
        public Assignment()
        {
            AssignmentSubmittedByStudent = new HashSet<AssignmentSubmittedByStudent>();
        }

        public int Id { get; set; }
        [Required]
        [StringLength(50)]
        public string Title { get; set; }
        [Column(TypeName = "text")]
        public string Description { get; set; }
        public int? BatchId { get; set; }
        public int? SemesterId { get; set; }
        public int? CollegeId { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? CreateDate { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? SubmitDate { get; set; }
        [StringLength(250)]
        public string AssignmentLocation { get; set; }
        public bool? Active { get; set; }

        [ForeignKey("BatchId")]
        [InverseProperty("Assignment")]
        public Batch Batch { get; set; }
        [ForeignKey("CollegeId")]
        [InverseProperty("Assignment")]
        public College College { get; set; }
        [ForeignKey("SemesterId")]
        [InverseProperty("Assignment")]
        public Semester Semester { get; set; }
        [InverseProperty("Assignment")]
        public ICollection<AssignmentSubmittedByStudent> AssignmentSubmittedByStudent { get; set; }
    }
}
