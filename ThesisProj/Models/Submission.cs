using Microsoft.AspNetCore.Authorization;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ThesisProj.Models.Enums;

namespace ThesisProj.Models
{
    [Table("Submissions")]
    public class Submission
    {
        [Required]
        [Display(Name = "Submission ID")]
        [Key]
        public int SubmissionId { get; set; }

        [Display(Name = "Thesis Name")]
        [Required]
        [ForeignKey(nameof(Submission.Thesis))]
        public int ThesisId { get; set; }
        [Display(Name = "Thesis Name")]
        public Thesis Thesis { get; set; }

        [Display(Name ="Description")]
        public string SubmissionDescription { get; set; }
             
        [Required]
        [Display(Name = "Submitted Date")]
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public int SubmittedDate { get; set; }

        [StringLength(150)]
        public string FileUrl { get; set; }
        
        [StringLength(60)]
        public string FileCOntentType { get; set; }
    }
}
      