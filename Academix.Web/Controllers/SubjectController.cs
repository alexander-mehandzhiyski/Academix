using Academix.Serices.Core;
using Academix.Serices.Core.Interfaces;
using Academix.Web.ViewModels.Subject;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Academix.Web.Controllers
{
    [Authorize]
    public class SubjectController : Controller
    {
        private readonly ISubjectService subjectService;

        public SubjectController(ISubjectService subjectService)
        {
            this.subjectService = subjectService;
        }

        [AllowAnonymous]
        public async Task<IActionResult> Index()
        {
            string userId = GetUserId();

            IEnumerable<SubjectViewModel> subjects = await subjectService.GetAllSubjectsAsync(userId);

            return View(subjects);
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            return View();
        }
        private string GetUserId()
        {
            return User.FindFirstValue(ClaimTypes.NameIdentifier)!;
        }
    }
}
