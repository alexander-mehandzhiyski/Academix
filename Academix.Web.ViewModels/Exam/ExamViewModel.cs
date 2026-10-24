namespace Academix.Web.ViewModels.Exam
{
    public class ExamViewModel
    {
        public int Id { get; set; }

        public string Title { get; set; } = null!;

        public decimal? Grade { get; set; }

        public DateTime ExamDate { get; set; }

        public int SubjectId { get; set; }

        public string SubjectName { get; set; } = null!;
    }
}
