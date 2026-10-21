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
            string? userId = GetUserId(); 

            var subject = await subjectService.GetCatalogSubjectsAsync(userId);

            return View(subject);
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(SubjectInputModel inputModel)
        {
            if (!ModelState.IsValid)
            {
                return View(inputModel);
            }
            string userId = GetUserId();
            bool isCreated = await subjectService.CreateSubjectAsync(inputModel, userId);
            if (!isCreated)
            {
                ModelState.AddModelError(string.Empty, "Failed to create subject.");
                return View(inputModel);
            }
            return RedirectToAction(nameof(Index));
        }
        private string GetUserId()
        {
            return User.FindFirstValue(ClaimTypes.NameIdentifier)!;
        }
    }
}
