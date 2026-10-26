using Academix.Serices.Core.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Academix.Web.Controllers
{
    [Authorize]
    public class SubjectController : BaseController
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
        public async Task<IActionResult> MySubjects()
        {
            string? userId = GetUserId();

            if(userId == null)
            {
                return Unauthorized();
            }

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
                TempData["Message"] = "Subject not found or already added.";
            }
            else
            {
                TempData["Message"] = "Subject added successfully!";
            }

            return RedirectToAction("MySubjects");
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

        [HttpPost]
        public async Task<IActionResult> RemoveFromMySubjects(int subjectId)
        {
            string? userId = GetUserId();

            if(userId == null)
            {
                return Unauthorized();
            }

            bool isRemoved = await subjectService.RemoveSubjectFromMySubjectsAsync(subjectId, userId);

            if(!isRemoved)
            {
                TempData["Message"] = "Subject not found or not added.";
            }
            else
            {
                TempData["Message"] = "Subject removed successfully!";
            }

            return RedirectToAction("MySubjects");
        }
    }
}
