using Academix.Data.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Academix.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(
            DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public virtual DbSet<Exam> Exams { get; set; } = null!;

        public virtual DbSet<Subject> Subjects { get; set; } = null!;

        public virtual DbSet<StudyTask> StudyTasks { get; set; } = null!;

        public virtual DbSet<UserSubject> UsersSubjects { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.ApplyConfiguration(new Configuration.SubjectConfiguration());
        }
    }
}
