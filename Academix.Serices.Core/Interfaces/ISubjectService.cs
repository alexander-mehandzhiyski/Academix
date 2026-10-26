namespace Academix.Serices.Core.Interfaces
{
    using Academix.Web.ViewModels.Subject;
    public interface ISubjectService
    {
        Task<SubjectViewModel?> GetSubjectByIdAsync(
            int subjectId,
            string userId);

        Task<IEnumerable<SubjectViewModel>> GetCatalogSubjectsAsync(string? userId);

        Task<IEnumerable<SubjectViewModel>> GetMySubjectsAsync(string userId);

        Task<bool> AddSubjectToMySubjectsAsync(
            int subjectId,
            string userId);

        Task<bool> RemoveSubjectFromMySubjectsAsync(
            int subjectId,
            string userId);
    }
}
