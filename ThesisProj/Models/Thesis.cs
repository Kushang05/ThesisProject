using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System;
using System.Collections.Generic;

namespace ThesisProj.Models
{
    [Table("Theses")]
    public class Thesis
    {
        [Required]
        [Display(Name = "Project ID")]
        [Key]
        public int ThesisId { get; set; }

        [Required(ErrorMessage = "{0} Cannot be Empty")]
        [StringLength(30, ErrorMessage = "{0} cannot be more than {1} characters")]
        [Column("varchar")]
        public string Title { get; set; }

        // Student ID
        [Required]
        [Display(Name = "Student EnrollmentId")]
        [ForeignKey(nameof(Thesis.Student))]
        public string EnrollmentId { get; set; }
        public ICollection<Student> Student{ get; set; }


        //Subject ID
        [Display(Name = "Subject")]
        [Required]
        [ForeignKey(nameof(Thesis.Subject))]
        public int SubjectId { get; set; }

        [Display(Name = "Subject")]
        public Subject Subject { get; set; }



        //Faculty ID
        [Display(Name = "Faculty")]
        [Required]
        [ForeignKey(nameof(Thesis.Faculty))]
        public string FacultyId { get; set; }

        [Display(Name = "Faculty")]
        public ICollection<Faculty> Faculty { get; set; }


    }
}
