using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static Academix.GCommon.DomainValidation.EntityValidationConstants.StudyTask;

namespace Academix.Data.Models
{
    public class StudyTask
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(StudyTaskTitleMaxLength)]
        public string Title { get; set; } = null!;

        [MaxLength(StudyTaskDescriptionMaxLength)]
        public string? Description { get; set; }

        [Column(TypeName = "smalldatetime")]
        public DateTime DueDate { get; set; }

        public bool IsCompleted { get; set; }

        [ForeignKey(nameof(Subject))]
        public int SubjectId { get; set; }

        public Subject Subject { get; set; } = null!;

        public string UserId { get; set; } = null!;

        [ForeignKey(nameof(UserId))]
        public virtual IdentityUser User { get; set; } = null!;
    }
}
