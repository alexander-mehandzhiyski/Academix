using Academix.Web.ViewModels.StudyTask;

namespace Academix.Serices.Core.Interfaces
{
    public interface IStudyTaskService
    {
        Task<bool> CreateStudyTaskAsync(
            StudyTaskInputModel model,
            string userId);

        Task<IEnumerable<StudyTaskViewModel>> GetStudyTasksBySubjectAsync(
            int subjectId,
            string userId);

        Task<StudyTaskViewModel?> GetStudyTaskByIdAsync(
            int taskId,
            string userId);

        Task<bool> EditStudyTaskAsync(
            int taskId,
            StudyTaskInputModel model,
            string userId);

        Task<bool> DeleteStudyTaskAsync(
            int taskId,
            string userId);

        Task<bool> SetStudyTaskCompletedAsync(
            int taskId,
            bool isCompleted,
            string userId);
    }
}
