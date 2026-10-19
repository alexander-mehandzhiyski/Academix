using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static Academix.GCommon.DomainValidation.EntityValidationConstants.Subject;

namespace Academix.Data.Models
{
    public class Subject
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(SubjectNameMaxLength)]
        public string Name { get; set; } = null!;

        [MaxLength(SubjectDescriptionMaxLength)]
        public string? Description { get; set; }

        [ForeignKey(nameof(User))]
        public string? UserId { get; set; }

        public virtual IdentityUser? User { get; set; }

        public virtual ICollection<StudyTask> StudyTasks { get; set; }
            = new HashSet<StudyTask>();
    }
}
