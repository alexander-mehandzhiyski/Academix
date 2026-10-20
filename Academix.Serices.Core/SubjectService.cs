using Academix.Data;
using Academix.Data.Models;
using Academix.Serices.Core.Interfaces;
using Academix.Web.ViewModels.Subject;
using Microsoft.EntityFrameworkCore;

namespace Academix.Serices.Core
{
    public class SubjectService : ISubjectService
    {
        private readonly ApplicationDbContext dbContext;
        public SubjectService(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public async Task<IEnumerable<SubjectViewModel>> GetAllSubjectsAsync(string userId)
        {
            return await dbContext.Subjects
                .Where(s => s.UserId == userId)
                .Select(s => new SubjectViewModel
                {
                    Name = s.Name,
                    Description = s.Description ?? string.Empty
                })
                .OrderBy(s => s.Name)
                .ThenBy(s => s.Description)
                .ToListAsync();
        }
        public async Task<bool> CreateSubjectAsync(SubjectInputModel model, string userId)
        {
            Subject subject = new Subject
            {
                Name = model.Name,
                Description = model.Description,
                UserId = userId
            };

            await dbContext.Subjects.AddAsync(subject);
            await dbContext.SaveChangesAsync();

            return true;
        }

        public async Task<bool> DeleteSubjectAsync(int subjectId, string userId)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> EditSubjectAsync(int subjectId, SubjectInputModel model, string userId)
        {
            throw new NotImplementedException();
        }

        public async Task<SubjectViewModel?> GetSubjectByIdAsync(int subjectId, string userId)
        {
            throw new NotImplementedException();
        }
    }
}
