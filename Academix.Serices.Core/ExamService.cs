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
       
        public async Task<bool> DeleteExamAsync(int examId, string userId)
        {
            var exam = await dbContext.Exams
                .Where(e => e.Id == examId && dbContext.UsersSubjects.Any(us => us.UserId == userId && us.SubjectId == e.SubjectId))
                .FirstOrDefaultAsync();

            if(exam == null)
            {
                return false;
            }

            dbContext.Exams.Remove(exam);
            await dbContext.SaveChangesAsync();

            return true;
        }

        public async Task<bool> EditExamAsync(int examId, ExamInputModel model, string userId)
        {
            var exam = await dbContext.Exams
                .FirstOrDefaultAsync(e => e.Id == examId 
                && dbContext.UsersSubjects
                .Any(us => us.UserId == userId 
                && us.SubjectId == e.SubjectId));

            if(exam == null)
            {
                return false;
            }

            if(exam.SubjectId != model.SubjectId)
            {
                return false;
            }

            if (model.ExamDate < DateTime.Now)
            {
                return false;
            }

            exam.Title = model.Title;
            exam.Grade = model.Grade;
            exam.ExamDate = model.ExamDate;

            await dbContext.SaveChangesAsync();

            return true;
        }

        public async Task<ExamViewModel?> GetExamByIdAsync(int examId, string userId)
        {
            return await dbContext.Exams
                .Where(e=>e.Id==examId && dbContext.UsersSubjects.Any(us => us.UserId == userId && us.SubjectId == e.SubjectId))
                .Select(e=>new ExamViewModel
                {
                    Id = e.Id,
                    Title = e.Title,
                    Grade = e.Grade,
                    ExamDate = e.ExamDate,
                    SubjectId = e.SubjectId,
                    SubjectName = e.Subject.Name
                })
                .FirstOrDefaultAsync();
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
