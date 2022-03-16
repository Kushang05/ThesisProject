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


        //Thesis Id
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

        [Required(ErrorMessage ="Cannot be Empty")]
        public MyStatus Status { get; set; }

        //[Display(Name = "Reviewed By")]
        //public string ReviewedBy { get; set; }


        //[Display(Name = "Reviewed Date")]
        //public int ReviewedDate { get; set; }

        [MaxLength(50,ErrorMessage ="{0} cannot be more than {1}")]
        public string Remarks { get; set; }

    }
}
