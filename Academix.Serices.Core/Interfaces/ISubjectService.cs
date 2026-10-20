namespace Academix.Serices.Core.Interfaces
{
    using Academix.Web.ViewModels.Subject;
    public interface ISubjectService
    {
        Task<IEnumerable<SubjectViewModel>> GetAllSubjectsAsync(string userId);
        Task<SubjectViewModel?> GetSubjectByIdAsync(
            int subjectId,
            string userId);

        Task<bool> CreateSubjectAsync(
            SubjectInputModel model,
            string userId);

        Task<bool> EditSubjectAsync(
            int subjectId,
            SubjectInputModel model,
            string userId);

        Task<bool> DeleteSubjectAsync(
            int subjectId,
            string userId);
    }
}
