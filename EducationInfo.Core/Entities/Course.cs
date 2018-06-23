using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EducationInfo.Core.Entities
{
    public partial class Course : IEntityBase
    {
        public Course()
        {
            CoursesPerUniversity = new HashSet<CoursesPerUniversity>();
            NoteInfo = new HashSet<NoteInfo>();
        }

        public int Id { get; set; }
        [Required]
        [StringLength(50)]
        public string Title { get; set; }
        [StringLength(250)]
        public string Description { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? CreateDate { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? PublishDate { get; set; }
        public bool? IsPublish { get; set; }

        [InverseProperty("Course")]
        public virtual ICollection<CoursesPerUniversity> CoursesPerUniversity { get; set; }
        [InverseProperty("Course")]
        public virtual ICollection<NoteInfo> NoteInfo { get; set; }
    }
}
