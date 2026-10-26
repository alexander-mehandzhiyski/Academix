using Academix.Web.ViewModels.Exam;

namespace Academix.Serices.Core.Interfaces
{
    public interface IExamService
    {
        Task<bool> CreateExamAsync(ExamInputModel model, string userId);

        Task<IEnumerable<ExamViewModel>> GetExamsBySubjectAsync(
            int subjectId,
            string userId);

        Task<ExamViewModel?> GetExamByIdAsync(
            int examId,
            string userId);

        Task<bool> EditExamAsync(
            int examId,
            ExamInputModel model,
            string userId);

        Task<bool> DeleteExamAsync(
            int examId,
            string userId);

        Task<bool> UserHasAccessToSubjectAsync(
            int subjectId,
            string userId);
    }
}
