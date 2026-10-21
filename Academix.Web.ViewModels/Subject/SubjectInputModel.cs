using System.ComponentModel.DataAnnotations;
using static Academix.GCommon.DomainValidation.EntityValidationConstants.Subject;

namespace Academix.Web.ViewModels.Subject
{
    public class SubjectInputModel
    {
        [Required]
        [StringLength(SubjectNameMaxLength, MinimumLength = SubjectNameMinLength)]
        public string Name { get; set; } = null!;

        [MaxLength(SubjectDescriptionMaxLength)]
        public string? Description { get; set; }
    }
}
