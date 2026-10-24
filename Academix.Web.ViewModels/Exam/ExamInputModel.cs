using System.ComponentModel.DataAnnotations;
using static Academix.GCommon.DomainValidation.EntityValidationConstants.Exam;

namespace Academix.Web.ViewModels.Exam
{
    public class ExamInputModel
    {
        [Required]
        [StringLength(ExamTitleMaxLength, MinimumLength = ExamTitleMinLength)]
        public string Title { get; set; } = null!;

        [Range(ExamGradeMinValue, ExamGradeMaxValue)]
        public decimal? Grade { get; set; }

        public DateTime ExamDate { get; set; }

        public int SubjectId { get; set; }
    }
}
