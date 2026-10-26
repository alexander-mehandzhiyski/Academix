using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Academix.Data.Models;

namespace Academix.Data.Configuration
{
    public class ExamConfiguration : IEntityTypeConfiguration<Exam>
    {
        public void Configure(EntityTypeBuilder<Exam> builder)
        {
            //builder.HasData(
            //    new Exam
            //    {
            //        Id = 1,
            //        Title = "Midterm Mathematics",
            //        Grade = null,
            //        ExamDate = new DateTime(2026, 11, 19),
            //        SubjectId = 1
            //    },
            //    new Exam
            //    {
            //        Id = 2,
            //        Title = "Final History",
            //        Grade = null,
            //        ExamDate = new DateTime(2026, 12, 19),
            //        SubjectId = 2
            //    }
            //);
        }
    }
}
