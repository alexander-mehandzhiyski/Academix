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

        [HttpGet]
        public async Task<IActionResult> MySubjects()
        {
            string userId = GetUserId();

            var subjects = await subjectService.GetMySubjectsAsync(userId);

            return View(subjects);
        }

        [HttpPost]
        public async Task<IActionResult> AddToMySubjects(int subjectId)
        {
            string? userId = GetUserId();

            if(userId == null)
            {
                return Unauthorized();
            }

            bool isAdded = await subjectService.AddSubjectToMySubjectsAsync(subjectId, userId);

            if(!isAdded)
            {
                TempData["Message"] = "Предметът не съществува или вече е добавен.";
            }
            else
            {
                TempData["Message"] = "Предметът е добавен успешно!";
            }

            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> Details([FromRoute] int id)
        {
            string? userId = GetUserId();

            if(userId == null)
            {
                return Unauthorized();
            }

            var subject = await subjectService.GetSubjectByIdAsync(id, userId);

            if(subject == null)
            {
                return NotFound();
            }

            return View(subject);
        }
        private string GetUserId()
        {
            return User.FindFirstValue(ClaimTypes.NameIdentifier)!;
        }
    }
}
