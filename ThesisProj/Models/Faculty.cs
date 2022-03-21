using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ThesisProj.Models.Enums;
using System;
using System.Collections.Generic;

namespace ThesisProj.Models
{
    [Table("Faculties")]
    public class Faculty
    {

        [Display(Name = "Faculty")]
        [ForeignKey(nameof(Faculty.User))]
        public Guid FacultyUserId { get; set; }
        public MyIdentityUser User { get; set; }

        [Key]
        [Required(ErrorMessage ="{0} cannot be empty")]
        [StringLength(6, ErrorMessage ="{0} be of lenght {1}")]
        public string FacultyId { get; set; }


        public ICollection<Thesis> Theses { get; set; }
    }
}
