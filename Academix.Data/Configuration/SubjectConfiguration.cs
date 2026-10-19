using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Academix.Data.Models;

namespace Academix.Data.Configuration
{
    public class SubjectConfiguration : IEntityTypeConfiguration<Subject>
    {
        public void Configure(EntityTypeBuilder<Subject> builder)
        {
            builder.HasData(
                new Subject
                {
                    Id = 1,
                    Name = "Mathematics",
                    Description = "Algebra, calculus and geometry",
                    UserId = null
                },
                new Subject
                {
                    Id = 2,
                    Name = "History",
                    Description = "World and regional history",
                    UserId = null
                }
            );
        }
    }
}
