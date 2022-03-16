using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System;
using ThesisProj.Models.Enums;
namespace ThesisProj.Models
{
    public class MyIdentityUser : IdentityUser <Guid>
    {

        [Display(Name = "Name")]
        [Required(ErrorMessage = "{0} cannot be EMPTY !!!!")]
        [MinLength(3, ErrorMessage = "{0} cannot be less than {1} !!")]
        [StringLength(50, ErrorMessage = "{0} cannot be more than {1} characters")]
        public string DisplayName { get; set; }

        [Display(Name = "Date of Birth")]
        [Required]
        [PersonalData]
        public DateTime DateOfBirth { get; set; }

        [Display(Name = "Phone Number")]
        [MinLength(10, ErrorMessage = "{0} cannot be less then {1}")]
        [Required(ErrorMessage = "{0} cannot be Empty!!")]
        public string MobileNo { get; set; }

        [Required]
        [Display(Name = "Gender")]
        [PersonalData]
        public MyIdentityGenders Gender { get; set; }

        [Required]
        public MyIdentityRoleNames Role { get; set; }


        //#region Navigational Proprties to the Student Model
        //public Student Student { get; set; }
        //#endregion


        //#region Navigational Proprties to the Faculty Model
        //public Faculty Faculty { get; set; }
        //#endregion
    }
}
