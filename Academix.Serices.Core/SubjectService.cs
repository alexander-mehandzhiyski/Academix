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
            throw new NotImplementedException();
        }
        public async Task<bool> CreateSubjectAsync(SubjectInputModel model, string userId)
        {
            throw new NotImplementedException();
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

        public async Task<IEnumerable<SubjectViewModel>> GetCatalogSubjectsAsync(string? userId)
        {
            return await dbContext.Subjects
                .Select(s => new SubjectViewModel
                {
                    Id = s.Id,
                    Name = s.Name,
                    Description = s.Description ?? string.Empty,
                    IsAdded = userId != null &&
                        dbContext.UsersSubjects.Any(us =>
                            us.SubjectId == s.Id &&
                            us.UserId == userId)
                })
                .OrderBy(s => s.Name)
                .ToListAsync();
        }

        public async Task<IEnumerable<SubjectViewModel>> GetMySubjectsAsync(string userId)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> AddSubjectToUserAsync(int subjectId, string userId)
        {
            throw new NotImplementedException();
        }
    }
}
