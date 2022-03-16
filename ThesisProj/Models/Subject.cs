using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ThesisProj.Models
{
    [Table("Subjects")]
    public class Subject
    {
        [Required]
        [Display(Name = "Subject ID")]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int SubjectId { get; set; }

        [Required(ErrorMessage = "{0} Cannot be Empty")]
        [StringLength(30, ErrorMessage = "{0} cannot be more than {1} characters")]
        public string SubjectName { get; set; }
    }
}
