using Academix.Data;
using Academix.Data.Models;
using Academix.Serices.Core.Interfaces;
using Academix.Web.ViewModels.Exam;
using Microsoft.EntityFrameworkCore;

namespace Academix.Serices.Core
{
    public class ExamService : IExamService
    {
        private readonly ApplicationDbContext dbContext;

        public ExamService(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public async Task<bool> CreateExamAsync(ExamInputModel model, string userId)
        {
            bool hasAccess = await dbContext.UsersSubjects.AnyAsync(us => us.UserId == userId && us.SubjectId == model.SubjectId);

            if (!hasAccess)
            {
                return false;
            }

            Exam exam = new Exam
            {
                Title = model.Title,
                Grade = model.Grade,
                ExamDate = model.ExamDate,
                SubjectId = model.SubjectId
            };

            await dbContext.Exams.AddAsync(exam);

            await dbContext.SaveChangesAsync();

            return true;
        }
       
        public Task<bool> DeleteExamAsync(int examId, string userId)
        {
            throw new NotImplementedException();
        }

        public Task<bool> EditExamAsync(int examId, ExamInputModel model, string userId)
        {
            throw new NotImplementedException();
        }

        public Task<ExamViewModel?> GetExamByIdAsync(int examId, string userId)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<ExamViewModel>> GetExamsBySubjectAsync(int subjectId, string userId)
        {
            bool hasAccsess = await dbContext.UsersSubjects.AnyAsync(us => us.UserId == userId && us.SubjectId == subjectId);

            if (!hasAccsess)
            {
                return Enumerable.Empty<ExamViewModel>();
            }

            return await dbContext.Exams
                .Where(e=>e.SubjectId == subjectId)
                .OrderByDescending(e => e.ExamDate)
                .Select(e=>new ExamViewModel
                {
                    Id = e.Id,
                    Title = e.Title,
                    Grade = e.Grade,
                    ExamDate = e.ExamDate,
                    SubjectId = e.SubjectId,
                    SubjectName = e.Subject.Name
                })
                .ToListAsync();
        }
    }
}
