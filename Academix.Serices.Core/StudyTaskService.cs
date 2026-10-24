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
        public async Task<bool> CreateStudyTaskAsync(StudyTaskInputModel inputModel, string userId)
        {
            bool subjectsBelongsToUser = await dbContext.UsersSubjects
                .AnyAsync(us => us.SubjectId == inputModel.SubjectId && us.UserId == userId);

            if (!subjectsBelongsToUser)
            {
                return false;
            }

            if (inputModel.DueDate < DateTime.Now)
            {
                return false;
            }

            StudyTask studyTask = new StudyTask
            {
                Title = inputModel.Title,
                Description = inputModel.Description,
                DueDate = inputModel.DueDate,
                SubjectId = inputModel.SubjectId,
                IsCompleted = false
            };

            await dbContext.StudyTasks.AddAsync(studyTask);
            await dbContext.SaveChangesAsync();

            return true;
        }

        public async Task<bool> DeleteStudyTaskAsync(int taskId, string userId)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> EditStudyTaskAsync(int taskId, StudyTaskInputModel model, string userId)
        {
            if(model.DueDate < DateTime.Now)
            {
                return false;
            }

            var studyTask = await dbContext.StudyTasks
                .FirstOrDefaultAsync(t =>
                t.Id == taskId &&
                t.SubjectId == model.SubjectId &&
                dbContext.UsersSubjects.Any(us =>
                us.SubjectId == t.SubjectId &&
                us.UserId == userId));

            if (studyTask == null)
            {
                return false;
            }

            if (studyTask.SubjectId != model.SubjectId)
            {
                return false;
            }

            studyTask.Title = model.Title;
            studyTask.Description = model.Description;
            studyTask.DueDate = model.DueDate;

            await dbContext.SaveChangesAsync();

            return true;
        }

        public async Task<StudyTaskViewModel?> GetStudyTaskByIdAsync(int taskId, string userId)
        {
            return await dbContext.StudyTasks
                .Where(st => st.Id == taskId && dbContext.UsersSubjects.Any(us => us.UserId == userId && us.SubjectId == st.SubjectId))
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

        public async Task<IEnumerable<StudyTaskViewModel>> GetStudyTasksBySubjectAsync(int subjectId, string userId)
        {
            bool subjectsBelongsToUser = await dbContext.UsersSubjects
                .AnyAsync(us => us.SubjectId == subjectId && us.UserId == userId);

            if (!subjectsBelongsToUser)
            {
                return Enumerable.Empty<StudyTaskViewModel>();
            }

            return await dbContext.StudyTasks
                .Where(st => st.SubjectId == subjectId)
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

        public async Task<bool> SetStudyTaskCompletedAsync(int taskId, bool isCompleted, string userId)
        {
            throw new NotImplementedException();
        }
    }
}
