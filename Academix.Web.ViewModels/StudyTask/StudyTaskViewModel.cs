namespace Academix.Web.ViewModels.StudyTask
{
    public class StudyTaskViewModel
    {
        public int Id { get; set; }

        public string Title { get; set; } = null!;

        public string? Description { get; set; }

        public DateTime DueDate { get; set; }

        public int SubjectId { get; set; }

        public string SubjectName { get; set; } = null!;

        public bool IsCompleted { get; set; }
    }
}
