using Academix.Serices.Core.Interfaces;
using Academix.Web.ViewModels.StudyTask;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Academix.Web.Controllers
{
    [Authorize]
    public class StudyTaskController : BaseController
    {
        private readonly IStudyTaskService studyTaskService;

        public StudyTaskController(IStudyTaskService studyTaskService)
        {
            this.studyTaskService = studyTaskService;
        }

        [HttpGet]
        public async Task<IActionResult> Create([FromQuery] int subjectId)
        {
            StudyTaskInputModel inputModel = new StudyTaskInputModel
            {
                SubjectId = subjectId,
                DueDate = DateTime.Today.AddDays(1)
            };

            return View(inputModel);
        }

        [HttpPost]
        public async Task<IActionResult> Create(StudyTaskInputModel inputModel)
        {
            if (!ModelState.IsValid)
            {
                return View(inputModel);
            }

            string? userId = GetUserId();

            if (userId == null)
            {
                return Unauthorized();
            }

            bool isCreated = await studyTaskService.CreateStudyTaskAsync(inputModel, userId);

            if (!isCreated)
            {
                ModelState.AddModelError(string.Empty, "Failed to create study task.");
                return View(inputModel);
            }

            return RedirectToAction("MySubjects");
        }

        [HttpGet]
        public async Task<IActionResult> TasksOfSubject([FromQuery] int subjectId)
        {
            string? userId = GetUserId();

            if (userId == null)
            {
                return Unauthorized();
            }

            IEnumerable<StudyTaskViewModel> tasks = await studyTaskService.GetStudyTasksBySubjectAsync(subjectId, userId);

            return View(tasks);
        }

        [HttpGet]
        public async Task<IActionResult> Edit([FromQuery] int taskId)
        {
            string? userId = GetUserId();

            if (userId == null)
            {
                return Unauthorized();
            }

            StudyTaskViewModel? task = await studyTaskService.GetStudyTaskByIdAsync(taskId, userId);

            if (task == null)
            {
                return NotFound();
            }

            StudyTaskInputModel inputModel = new StudyTaskInputModel
            {
                Title = task.Title,
                Description = task.Description,
                DueDate = task.DueDate,
                SubjectId = task.SubjectId
            };

            ViewBag.TaskId = taskId;

            return View(inputModel);
        }

        [HttpPost]
        public async Task<IActionResult> Edit([FromQuery] int taskId, StudyTaskInputModel inputModel)
        {
            string? userId = GetUserId();

            if (userId == null)
            {
                return Unauthorized();
            }

            if (!ModelState.IsValid)
            {
                return View(inputModel);
            }

            bool edited = await studyTaskService.EditStudyTaskAsync(taskId, inputModel, userId);

            if (!edited)
            {
                ModelState.AddModelError(string.Empty, "Failed to edit study task.");
                return View(inputModel);
            }

            return RedirectToAction("TasksOfSubject", new { subjectId = inputModel.SubjectId });
        }

        [HttpGet]
        public async Task<IActionResult> Delete([FromQuery] int taskId)
        {
            string? userId = GetUserId();

            if (userId == null)
            {
                return Unauthorized();
            }

            StudyTaskViewModel? task = await studyTaskService.GetStudyTaskByIdAsync(taskId, userId);

            if(task == null)
            {
                return NotFound();
            }

            return View(task);
        }

        [HttpPost]
        public async Task<IActionResult> DeleteConfirmed([FromQuery] int taskId, [FromQuery] int subjectId)
        {
            string? userId = GetUserId();

            if(userId == null)
            {
                return Unauthorized();
            }

            bool deleted = await studyTaskService.DeleteStudyTaskAsync(taskId, userId);

            if(!deleted)
            {
                return BadRequest("Failed to delete study task.");
            }

            return RedirectToAction("TasksOfSubject", new { subjectId });
        }
    }
}
