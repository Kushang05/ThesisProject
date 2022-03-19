﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.Extensions.Logging;
using ThesisProj.Models;
using ThesisProj.Models.Enums;

namespace ThesisProj.Areas.Identity.Pages.Account
{
    [AllowAnonymous]
    public class RegisterStudentModel : PageModel
    {
        private const string StandardPASSWORD = "Password@1234";

        private readonly SignInManager<MyIdentityUser> _signInManager;
        private readonly UserManager<MyIdentityUser> _userManager;
        private readonly ILogger<RegisterModel> _logger;
        private readonly IEmailSender _emailSender;

        public RegisterStudentModel(
            UserManager<MyIdentityUser> userManager,
            SignInManager<MyIdentityUser> signInManager,
            ILogger<RegisterModel> logger,
            IEmailSender emailSender)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _logger = logger;
            _emailSender = emailSender;
        }

        [BindProperty]
        public InputModel Input { get; set; }

        public string ReturnUrl { get; set; }

        public IList<AuthenticationScheme> ExternalLogins { get; set; }

        public class InputModel
        {
            [Required]
            [EmailAddress]
            [Display(Name = "Email")]
            public string Email { get; set; }

            [Display(Name = "Name")]
            [Required(ErrorMessage = "{0} cannot be EMPTY !!!!")]
            [MinLength(3, ErrorMessage = "{0} cannot be less than {1} !!")]
            [StringLength(50, ErrorMessage = "{0} cannot be more than {1} characters")]
            public string DisplayName { get; set; }

            [Display(Name = "Date of Birth")]
            [Required]
            [PersonalData]
            public DateTime DateOfBirth { get; set; }

            //[Required(ErrorMessage = "{0} Cannot be Empty")]
            //[Display(Name = "Enrolment ID")]
            //[MinLength(10, ErrorMessage = "")]
            //[StringLength(10, ErrorMessage = "{0} cannot be more than {1}")]
            //public string EnrollmentId { get; set; }

            [Display(Name = "Phone Number")]
            [MinLength(10, ErrorMessage = "{0} cannot be less then {1}")]
            [Required(ErrorMessage = "{0} cannot be Empty!!")]
            public string MobileNo { get; set; }

            [Required]
            [Display(Name = "Gender")]
            [PersonalData]
            public MyIdentityGenders Gender { get; set; }

      
        }

        public async Task OnGetAsync(string returnUrl = null)
        {
            ReturnUrl = returnUrl;
            ExternalLogins = (await _signInManager.GetExternalAuthenticationSchemesAsync()).ToList();
        }

        public async Task<IActionResult> OnPostAsync(string returnUrl = null)
        {
            returnUrl ??= Url.Content("~/");
            ExternalLogins = (await _signInManager.GetExternalAuthenticationSchemesAsync()).ToList();
            if (ModelState.IsValid)
            {
                var user = new MyIdentityUser 
                { 
                    UserName = Input.Email,
                    Email = Input.Email, 
                    DisplayName= Input.DisplayName,
                    DateOfBirth = Input.DateOfBirth,
                    MobileNo = Input.MobileNo,
                    Gender=Input.Gender,

                };
                var result = await _userManager.CreateAsync(user, StandardPASSWORD);
                if (result.Succeeded)
                {
                    await _userManager.AddToRolesAsync(user, new string[] { MyIdentityRoleNames.Student.ToString() });
                    _logger.LogInformation("User created a new account with password.");

                    var code = await _userManager.GenerateEmailConfirmationTokenAsync(user);
                    code = WebEncoders.Base64UrlEncode(Encoding.UTF8.GetBytes(code));
                    var callbackUrl = Url.Page(
                        "/Account/ConfirmEmail",
                        pageHandler: null,
                        values: new { area = "Identity", userId = user.Id, code = code, returnUrl = returnUrl },
                        protocol: Request.Scheme);

                    await _emailSender.SendEmailAsync(Input.Email, "Confirm your email",
                        $"Please confirm your account by <a href='{HtmlEncoder.Default.Encode(callbackUrl)}'>clicking here</a>.");

                    if (_userManager.Options.SignIn.RequireConfirmedAccount)
                    {
                        return RedirectToPage("RegisterConfirmation", new { email = Input.Email, returnUrl = returnUrl });
                    }
                    else
                    {
                        await _signInManager.SignInAsync(user, isPersistent: false);
                        return LocalRedirect(returnUrl);
                    }
                }
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
            }

            // If we got this far, something failed, redisplay form
            return Page();
        }
    }
}