using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static Academix.GCommon.DomainValidation.EntityValidationConstants.Exam;

namespace Academix.Data.Models
{
    public class Exam
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(ExamTitleMaxLength)]
        public string Title { get; set; } = null!;

        [Column(TypeName = "decimal(4, 2)")]
        public decimal? Grade { get; set; }

        [Column(TypeName = "smalldatetime")]
        public DateTime ExamDate { get; set; }

        [ForeignKey(nameof(Subject))]
        public int SubjectId { get; set; }

        public virtual Subject Subject { get; set; } = null!;

        [ForeignKey(nameof(User))]
        public string UserId { get; set; } = null!;

        public virtual IdentityUser User { get; set; } = null!;
    }
}
