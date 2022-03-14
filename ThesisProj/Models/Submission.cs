using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


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



        [Required(ErrorMessage = "{0} Cannot be Empty")]
        public string SubmissionDescription { get; set; }


        [Display(Name = "Due Date")]
        public int SubmissionDue { get; set; }

        [Required]
        [Display(Name = "Submitted Date")]
        public int SubmittedDate { get; set; }


        [Display(Name = "Submitted Date")]
        public bool Status { get; set; }


        [Display(Name = "Reviewed By")]
        public string ReviewedBy { get; set; }


        [Display(Name = "Reviewed Date")]
        public int ReviewedDate { get; set; }


        public string Remarks { get; set; }

    }
}
