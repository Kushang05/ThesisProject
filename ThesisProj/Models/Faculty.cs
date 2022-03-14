using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ThesisProj.Models.Enums;
using System;

namespace ThesisProj.Models
{
    [Table("Faculties")]
    public class Faculty
    {
        [Required]
        [Display(Name = "User ID")]
        [ForeignKey(nameof(Faculty.User))]
        public Guid FacultyId { get; set; }
        public MyIdentityUser User { get; set; }


        [Required(ErrorMessage = "{0} Cannot be Empty")]
        [StringLength(30, ErrorMessage = "{0} cannot be more than {1} characters")]
        [Column("varchar")]
        public string FacultyType { get; set; }


        [Display(Name = "Subject Id")]
        [ForeignKey(nameof(Faculty.Student))]
        public int Subjects { get; set; }
        public Student Student { get; set; }

    }
}
