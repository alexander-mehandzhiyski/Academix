
using Academix.Data;
using Academix.Data.Models;
using Academix.Serices.Core.Interfaces;
using Academix.Web.ViewModels.StudyTask;
using Microsoft.EntityFrameworkCore;

namespace Academix.Serices.Core
{
    public class StudyTaskService : IStudyTaskService
    {
        private readonly ApplicationDbContext dbContext;

        public StudyTaskService(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<bool> CreateStudyTaskAsync(
            StudyTaskInputModel inputModel, string userId)
        {
            bool hasAccess = await dbContext.UsersSubjects
                .AnyAsync(us =>
                    us.SubjectId == inputModel.SubjectId &&
                    us.UserId == userId);

            if (!hasAccess ||
                inputModel.DueDate.Date < DateTime.Today)
            {
                return false;
            }

            StudyTask studyTask = new StudyTask
            {
                Title = inputModel.Title,
                Description = inputModel.Description,
                DueDate = inputModel.DueDate,
                SubjectId = inputModel.SubjectId,
                UserId = userId,
                IsCompleted = false
            };

            await dbContext.StudyTasks.AddAsync(studyTask);
            await dbContext.SaveChangesAsync();

            return true;
        }

        public async Task<bool> DeleteStudyTaskAsync(
            int taskId, string userId)
        {
            var studyTask = await dbContext.StudyTasks
                .FirstOrDefaultAsync(st =>
                    st.Id == taskId &&
                    st.UserId == userId &&
                    dbContext.UsersSubjects.Any(us =>
                        us.UserId == userId &&
                        us.SubjectId == st.SubjectId));

            if (studyTask == null)
            {
                return false;
            }

            dbContext.StudyTasks.Remove(studyTask);
            await dbContext.SaveChangesAsync();

            return true;
        }

        public async Task<bool> EditStudyTaskAsync(
            int taskId, StudyTaskInputModel model, string userId)
        {
            if (model.DueDate.Date < DateTime.Today)
            {
                return false;
            }

            var studyTask = await dbContext.StudyTasks
                .FirstOrDefaultAsync(st =>
                    st.Id == taskId &&
                    st.UserId == userId &&
                    st.SubjectId == model.SubjectId &&
                    dbContext.UsersSubjects.Any(us =>
                        us.UserId == userId &&
                        us.SubjectId == st.SubjectId));

            if (studyTask == null)
            {
                return false;
            }

            studyTask.Title = model.Title;
            studyTask.Description = model.Description;
            studyTask.DueDate = model.DueDate;

            await dbContext.SaveChangesAsync();

            return true;
        }

        public async Task<StudyTaskViewModel?> GetStudyTaskByIdAsync(
            int taskId, string userId)
        {
            return await dbContext.StudyTasks
                .Where(st =>
                    st.Id == taskId &&
                    st.UserId == userId &&
                    dbContext.UsersSubjects.Any(us =>
                        us.UserId == userId &&
                        us.SubjectId == st.SubjectId))
                .Select(st => new StudyTaskViewModel
                {
                    Id = st.Id,
                    Title = st.Title,
                    Description = st.Description,
                    DueDate = st.DueDate,
                    SubjectId = st.SubjectId,
                    SubjectName = st.Subject.Name,
                    IsCompleted = st.IsCompleted
                })
                .FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<StudyTaskViewModel>>
            GetStudyTasksBySubjectAsync(int subjectId, string userId)
        {
            bool hasAccess = await dbContext.UsersSubjects
                .AnyAsync(us =>
                    us.SubjectId == subjectId &&
                    us.UserId == userId);

            if (!hasAccess)
            {
                return Enumerable.Empty<StudyTaskViewModel>();
            }

            return await dbContext.StudyTasks
                .Where(st =>
                    st.SubjectId == subjectId &&
                    st.UserId == userId)
                .Select(st => new StudyTaskViewModel
                {
                    Id = st.Id,
                    Title = st.Title,
                    Description = st.Description,
                    DueDate = st.DueDate,
                    SubjectId = st.SubjectId,
                    SubjectName = st.Subject.Name,
                    IsCompleted = st.IsCompleted
                })
                .OrderByDescending(st => st.DueDate)
                .ThenBy(st => st.Title)
                .ThenBy(st => st.Id)
                .ToListAsync();
        }

        public async Task<bool> SetStudyTaskCompletedAsync(
            int taskId, bool isCompleted, string userId)
        {
            var studyTask = await dbContext.StudyTasks
                .FirstOrDefaultAsync(st =>
                    st.Id == taskId &&
                    st.UserId == userId &&
                    dbContext.UsersSubjects.Any(us =>
                        us.UserId == userId &&
                        us.SubjectId == st.SubjectId));

            if (studyTask == null)
            {
                return false;
            }

            studyTask.IsCompleted = isCompleted;

            await dbContext.SaveChangesAsync();

            return true;
        }

        public async Task<bool> UserHasAccessToSubjectAsync(
            int subjectId, string userId)
        {
            return await dbContext.UsersSubjects
                .AnyAsync(us =>
                    us.SubjectId == subjectId &&
                    us.UserId == userId);
        }
    }
}
