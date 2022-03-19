using System;
using System.ComponentModel.DataAnnotations;

namespace ThesisProj.ViewModels
{
    public class StudentListViewModel
    {
        [Key]
        [Display(Name="Student Id")]
        public Guid Id { get; set; }

        [Display(Name="Name")]
        public string DisplayName { get; set; }
        
        //[Display(Name="Enrollment Id")]
        //public string EnrollmentId { get; set; }

        [Display(Name = "Email")]
        public string Email { get; set; }



    }
}
