using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ThesisProj.Models.Enums;
using System;

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
        [Required]
        public int FacultyId { get; set; }

        [Required(ErrorMessage = "{0} Cannot be Empty")]
        [StringLength(30, ErrorMessage = "{0} cannot be more than {1} characters")]
        [Column("varchar")]
        public string FacultyType { get; set; }


        [Display(Name = "Subject Id")]
        [ForeignKey(nameof(Faculty.Subject))]
        public int Subjects { get; set; }
        public Subject Subject { get; set; }

    }
}
