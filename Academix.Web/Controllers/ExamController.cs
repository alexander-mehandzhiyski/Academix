using Academix.Serices.Core.Interfaces;
using Academix.Web.ViewModels.Exam;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Academix.Web.Controllers
{
    [Authorize]
    public class ExamController : BaseController
    {
        private readonly IExamService examService;

        public ExamController(IExamService examService)
        {
            this.examService = examService;
        }

        [HttpGet]
        public async Task<IActionResult> Create(int subjectId)
        {
            ExamInputModel inputModel = new ExamInputModel
            {
                SubjectId = subjectId,
                ExamDate = DateTime.Today.AddDays(1)
            };

            return View(inputModel);
        }

        [HttpPost]
        public async Task<IActionResult> Create(ExamInputModel inputModel)
        {
            string? userId = GetUserId();

            if (userId == null)
            {
                return Unauthorized();
            }

            if(!ModelState.IsValid)
            {
                return View(inputModel);
            }

            bool result = await examService.CreateExamAsync(inputModel, userId);

            if (!result)
            {
                ModelState.AddModelError(string.Empty, "Unable to create exam for this subject.");

                return View(inputModel);
            }

            return RedirectToAction("ExamsOfSubject", new { subjectId = inputModel.SubjectId });
        }

        [HttpGet]
        public async Task<IActionResult> ExamsOfSubject([FromQuery] int subjectId)
        {
            string? userId = GetUserId();

            if (userId == null)
            {
                return Unauthorized();
            }

            IEnumerable<ExamViewModel> exams = await examService.GetExamsBySubjectAsync(subjectId, userId);

            return View(exams);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int examId)
        {
            string? userId = GetUserId();

            if(userId == null)
            {
                return Unauthorized();
            }

            ExamViewModel? exam = await examService.GetExamByIdAsync(examId, userId);

            if (exam == null)
            {
                return NotFound();
            }

            
            ExamInputModel inputModel = new()
            {
                Title = exam.Title,
                Grade = exam.Grade,
                ExamDate = exam.ExamDate,
                SubjectId = exam.SubjectId
            };
         
            ViewBag.ExamId = exam.Id;

            return View(inputModel);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int examId, ExamInputModel inputModel)
        {
            string? userId = GetUserId();

            if (userId == null)
            {
                return Unauthorized();
            }

            if(!ModelState.IsValid)
            {
                ViewBag.ExamId = examId;
                return View(inputModel);
            }

            bool result = await examService.EditExamAsync(examId, inputModel, userId);

            if (!result)
            {
                ModelState.AddModelError(string.Empty, "Unable to edit exam.");
                ViewBag.ExamId = examId;
                return View(inputModel);
            }

            return RedirectToAction("ExamsOfSubject", new { subjectId = inputModel.SubjectId });
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int examId)
        {
            string? userId = GetUserId();

            if(userId == null)
            {
                return Unauthorized();
            }

            ExamViewModel? exam = await examService.GetExamByIdAsync(examId, userId);

            if (exam == null)
            {
                return NotFound();
            }

            return View(exam);
        }

        [HttpPost]
        public async Task<IActionResult> DeleteConfirmed(int examId)
        {
            string? userId = GetUserId();

            if(userId == null)
            {
                return Unauthorized();
            }

            ExamViewModel? exam = await examService.GetExamByIdAsync(examId, userId);

            if(exam == null)
            {
                return NotFound();
            }
            
            bool result = await examService.DeleteExamAsync(examId, userId);

            if (!result)
            {
                ModelState.AddModelError(string.Empty, "Unable to delete exam.");
                return View("Delete", exam);
            }

            return RedirectToAction("ExamsOfSubject", new { subjectId = exam.SubjectId });
        }
    }
}
