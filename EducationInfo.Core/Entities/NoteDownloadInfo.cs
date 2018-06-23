using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EducationInfo.Core.Entities
{
    public partial class NoteDownloadInfo : IEntityBase
    {
        public int Id { get; set; }
        public int? NoteId { get; set; }
        public int? StudentId { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? DownloadDate { get; set; }

        [ForeignKey("NoteId")]
        [InverseProperty("NoteDownloadInfo")]
        public NoteInfo Note { get; set; }
        [ForeignKey("StudentId")]
        [InverseProperty("NoteDownloadInfo")]
        public Student Student { get; set; }
    }
}
