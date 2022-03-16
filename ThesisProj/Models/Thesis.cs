using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System;

namespace ThesisProj.Models
{
    [Table("Theses")]
    public class Thesis
    {
        [Required]
        [Display(Name = "Project ID")]
        [Key]
        public int ProjectID { get; set; }

        [Required(ErrorMessage = "{0} Cannot be Empty")]
        [StringLength(30, ErrorMessage = "{0} cannot be more than {1} characters")]
        [Column("varchar")]
        public string ProjectTitle { get; set; }
        
        
        [Required(ErrorMessage = "{0} Cannot be Empty")]
        public string ProjectDescription { get; set; }


        // Student ID

        [Required]
        [Display(Name = "Student ID")]
        [ForeignKey(nameof(Thesis.User))]
        public Guid UserId { get; set; }
        public MyIdentityUser User { get; set; }


        //Subject ID
        [Display(Name = "Subject Name")]
        [Required]
        [ForeignKey(nameof(Thesis.Subject))]
        public int SubjecttId { get; set; }

        [Display(Name = "Subject Name")]
        public Subject Subject { get; set; }



        //Faculty ID
        [Display(Name = "Mentor Name")]
        [Required]
        [ForeignKey(nameof(Thesis.Faculty))]
        public int FacultyId { get; set; }

        [Display(Name = "Faculty Name")]
        public Faculty Faculty { get; set; }


        //[Display(Name = "Start Date")]
        //public DateTime StartDate{ get; set; }


        //[Display(Name = "End Date")]
        //public DateTime EndDate{ get; set; }


        //[Display(Name = "Completed %")]
        //public int CompletionPercentage { get; set; }

    }
}
