using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EducationInfo.Core.Entities
{
    public partial class User : IEntityBase
    {
        public User()
        {
            Student = new HashSet<Student>();
        }

        public int Id { get; set; }
        [Required]
        [StringLength(50)]
        public string UserName { get; set; }
        [Required]
        [StringLength(50)]
        public string Password { get; set; }
        public int? UsetType { get; set; }

        [InverseProperty("User")]
        public ICollection<Student> Student { get; set; }
    }
}
