using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EducationInfo.Core.Entities
{
    
    public class NoteInfo : IEntityBase
    {
        public NoteInfo()
        {
            NoteDownloadInfo = new HashSet<NoteDownloadInfo>();
        }

        public int Id { get; set; }
        [StringLength(50)]
        public string Title { get; set; }
        [StringLength(250)]
        public string NoteLocation { get; set; }
        public int? CourseId { get; set; }
        [Column(TypeName = "datetime")]
        [DisplayFormat(DataFormatString = "{0: dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime CreateDate { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? PublishDate { get; set; }
        public bool IsPublish { get; set; }

        [ForeignKey("CourseId")]
        [InverseProperty("NoteInfo")]
        public Course Course { get; set; }
        [InverseProperty("Note")]
        public ICollection<NoteDownloadInfo> NoteDownloadInfo { get; set; }
    }
}
