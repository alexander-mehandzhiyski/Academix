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
            return await dbContext.UsersSubjects
                .Where(s=>s.SubjectId == subjectId && s.UserId == userId)
                .Select(s=> new SubjectViewModel
                {
                    Id = s.Subject.Id,
                    Name = s.Subject.Name,
                    Description = s.Subject.Description ?? string.Empty,
                    IsAdded = userId != null &&
                        dbContext.UsersSubjects.Any(us =>
                            us.SubjectId == s.SubjectId &&
                            us.UserId == userId)
                })
                .FirstOrDefaultAsync();
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
            return await dbContext.UsersSubjects
                .Include(us => us.Subject)
                .Where(us => us.UserId == userId)
                .Select(us => new SubjectViewModel
                {
                    Id = us.Subject.Id,
                    Name = us.Subject.Name,
                    Description = us.Subject.Description ?? string.Empty,
                    IsAdded = true
                })
                .OrderBy(s => s.Name)
                .ThenBy(s => s.Id)
                .ToListAsync();
        }

        public async Task<bool> AddSubjectToMySubjectsAsync(int subjectId, string userId)
        {
            bool subjectExists = await dbContext.Subjects.AnyAsync(s => s.Id == subjectId);

            if(!subjectExists)
            {
                return false;
            }

            bool isAlreadyAdded = await dbContext.UsersSubjects.AnyAsync(us => us.SubjectId == subjectId && us.UserId == userId);

            if(isAlreadyAdded)
            {
                return false;
            }

            UserSubject userSubject = new UserSubject
            {
                UserId = userId,
                SubjectId = subjectId
            };

            await dbContext.UsersSubjects.AddAsync(userSubject);

            await dbContext.SaveChangesAsync();

            return true;
        }
    }
}
