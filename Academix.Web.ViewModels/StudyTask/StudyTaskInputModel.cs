using Academix.Web.ViewModels.CustomValidationAttributes;
using System.ComponentModel.DataAnnotations;
using static Academix.GCommon.DomainValidation.EntityValidationConstants.StudyTask;

namespace Academix.Web.ViewModels.StudyTask
{
    public class StudyTaskInputModel
    {
        [Required]
        [StringLength(StudyTaskTitleMaxLength, MinimumLength = StudyTaskTitleMinLength)]
        public string Title { get; set; } = null!;

        [StringLength(StudyTaskDescriptionMaxLength, MinimumLength = StudyTaskDescriptionMinLength)]
        public string? Description { get; set; }

        [FutureDate(ErrorMessage = "Date cannot be in the past.")]
        public DateTime DueDate { get; set; }

        public int SubjectId { get; set; }
    }
}
