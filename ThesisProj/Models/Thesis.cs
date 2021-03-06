using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

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
        [Display(Name = "Student Name")]
        [Required]
        [ForeignKey(nameof(Thesis.Student))]
        public int StudentId { get; set; }

        [Display(Name = "Student Name")]
        public Student Student { get; set; }



        //Subject ID
        [Display(Name = "Subject Name")]
        [Required]
        [ForeignKey(nameof(Thesis.Subject))]
        public int SubjecttId { get; set; }

        [Display(Name = "Subject Name")]
        public Subject Subject { get; set; }



        //Faculty ID
        [Display(Name = "Faculty Name")]
        [Required]
        [ForeignKey(nameof(Thesis.Faculty))]
        public int FacultyId { get; set; }

        [Display(Name = "Faculty Name")]
        public Faculty Faculty { get; set; }



        [Display(Name = "Start Date")]
        public int StartDate{ get; set; }

       
        [Display(Name = "End Date")]
        public int EndDate{ get; set; }

        [Display(Name = "Completed %")]
        public int CompletionPercentage { get; set; }

    }
}
