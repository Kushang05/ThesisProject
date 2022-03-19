using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Threading.Tasks;
using ThesisProj.Data;
using ThesisProj.Models;
using ThesisProj.ViewModels;
using System.Linq;

namespace ThesisProj.Controllers
{
    public class FacultiesController : Controller
    {
        private readonly ILogger<FacultiesController> _logger;
        private readonly UserManager<MyIdentityUser> _userManager;
        private readonly ApplicationDbContext _context;

        public FacultiesController(
            ILogger<FacultiesController> logger,
            UserManager<MyIdentityUser> userManager,
            ApplicationDbContext context)

        {
            _logger = logger;
            _userManager = userManager;
            _context = context;     
        }


        public async Task<IActionResult> Index()
        {
            var users = from user in _context.Users
                        where user.Role == Models.Enums.MyIdentityRoleNames.Student
                        select user;

            List<FacultyListViewModel> viewModelList = new List<FacultyListViewModel>();

            foreach (var user in users)
            {
                var viewModel = new FacultyListViewModel
                {
                    FacultyId = user.Id,
                    Email = user.Email,
                    DisplayName = user.DisplayName,
                    RolesOfUser = await _userManager.GetRolesAsync(user) as List<string>


                };
                viewModelList.Add(viewModel);

            }


            return View();
        }
    }
}
