using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Academix.Data.Models
{
    [PrimaryKey(nameof(UserId), nameof(SubjectId))]
    public class UserSubject
    {
        [Required]
        public string UserId { get; set; } = null!;

        [ForeignKey(nameof(UserId))]
        public virtual IdentityUser User { get; set; } = null!;

        [Required]
        public int SubjectId { get; set; }

        [ForeignKey(nameof(SubjectId))]
        public virtual Subject Subject { get; set; } = null!;
    }
}