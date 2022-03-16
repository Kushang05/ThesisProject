using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ThesisProj.Models.Enums
{
    public enum MyIdentityGenders
    {
     
            [Display(Name ="Male")]
            Male,

            [Display(Name ="Female")]
            Female,

            [Display(Name ="ThirdGender")]
            ThirdGender
     
    }
}
