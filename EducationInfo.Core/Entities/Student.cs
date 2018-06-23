using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EducationInfo.Core.Entities
{
    public partial class Student : IEntityBase
    {
        public Student()
        {
            AssignmentSubmittedByStudent = new HashSet<AssignmentSubmittedByStudent>();
            NoteDownloadInfo = new HashSet<NoteDownloadInfo>();
        }

        public int Id { get; set; }
        [Required]
        [StringLength(50)]
        public string Name { get; set; }
        [Required]
        [StringLength(50)]
        public string Email { get; set; }
        public int? CollegeId { get; set; }
        public int? BatchId { get; set; }
        public int? SemesterId { get; set; }
        public int? UserId { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? CreateDate { get; set; }
        public bool? Active { get; set; }

        [ForeignKey("BatchId")]
        [InverseProperty("Student")]
        public Batch Batch { get; set; }
        [ForeignKey("SemesterId")]
        [InverseProperty("Student")]
        public Semester Semester { get; set; }
        [ForeignKey("UserId")]
        [InverseProperty("Student")]
        public User User { get; set; }
        [InverseProperty("Student")]
        public ICollection<AssignmentSubmittedByStudent> AssignmentSubmittedByStudent { get; set; }
        [InverseProperty("Student")]
        public ICollection<NoteDownloadInfo> NoteDownloadInfo { get; set; }
    }
}
