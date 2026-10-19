using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Academix.Data.Models;

namespace Academix.Data.Configuration
{
    public class StudyTaskConfiguration : IEntityTypeConfiguration<StudyTask>
    {
        public void Configure(EntityTypeBuilder<StudyTask> builder)
        {
            builder.HasData(
                new StudyTask
                {
                    Id = 1,
                    Title = "Read Chapter 1",
                    Description = "Introduction to algebra",
                    DueDate = new DateTime(2026, 10, 26),
                    IsCompleted = false,
                    SubjectId = 1
                },
                new StudyTask
                {
                    Id = 2,
                    Title = "Practice problems",
                    Description = "Solve exercises 1-10",
                    DueDate = new DateTime(2026, 10, 29),
                    IsCompleted = false,
                    SubjectId = 1
                },
                new StudyTask
                {
                    Id = 3,
                    Title = "Read about WW2",
                    Description = "Focus on timeline and key events",
                    DueDate = new DateTime(2026, 10, 24),
                    IsCompleted = false,
                    SubjectId = 2
                }
            );
        }
    }
}
