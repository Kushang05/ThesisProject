using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ThesisProj.Models
{
    [Table("Students")]
    public class Student
    {  
        [Key]
        [Display(Name = "Student ID")]
        [ForeignKey(nameof(Student.User))]
        public Guid UserId { get; set; }
        public MyIdentityUser User { get; set; }
        
        [Required(ErrorMessage = "{0} Cannot be Empty")]
        [StringLength(10, ErrorMessage ="{0} should be of {1} characters")]
        public string EnrollmentId { get; set; }


        [Display(Name = "Parent Name")]
        [Required(ErrorMessage = "{0} Cannot be Empty")]
        [StringLength(50, ErrorMessage = "{0} cannot be more than {1} characters")]
        public string ParentName { get; set; }

        public ICollection<Thesis> Theses { get; set; }
    }
}