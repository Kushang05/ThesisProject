using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ThesisProj.ViewModels
{
    public class FacultyListViewModel
    {
        [Key]
        public Guid FacultyId { get; set; }


        [Display(Name = "Name")]
        public string DisplayName { get; set; }

        [Display(Name = "Email")]
        public string Email { get; set; }

        [Display(Name = "Roles of the User")]
        public List<string> RolesOfUser { get; set; }
    }
}
