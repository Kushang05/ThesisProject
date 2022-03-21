using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Identity;
using ThesisProj.Models;
using ThesisProj.Data;
using System.Collections.Generic;
using ThesisProj.ViewModels;

namespace ThesisProj.Controllers
{
    public class StudentsRegisterController : Controller
    {
        private readonly ILogger<StudentsRegisterController> _logger;
        private readonly UserManager<MyIdentityUser> _userManager;
        private readonly ApplicationDbContext _context;

        public StudentsRegisterController(
            ILogger<StudentsRegisterController> logger,
            UserManager<MyIdentityUser> userManager,
            ApplicationDbContext context)
        {
            _logger = logger;
            _userManager = userManager;
            _context = context;
        }

        public  IActionResult Index()
        {
            var users = from user in _context.Users
                        where user.Role == Models.Enums.MyIdentityRoleNames.Student
                        select user;
                        
            List<StudentListViewModel> viewModelList = new List<StudentListViewModel>();
            foreach (var user in users)
            {
                var viewModel = new StudentListViewModel
                {
                    Id = user.Id,
                    DisplayName = user.DisplayName,
                    //EnrollmentId = user.
                    Email = user.Email

                };
                viewModelList.Add(viewModel);
            }

            return View(viewModelList);
        }
    }
}
