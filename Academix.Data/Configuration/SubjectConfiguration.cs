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
                },
                new Subject
                {
                    Id = 2,
                    Name = "History",
                    Description = "World and regional history",
                },
                new Subject
                {
                    Id = 3,
                    Name = "Geography",
                    Description = "Study Earth’s lands, features, inhabitants, and natural or human phenomena",
                },
                new Subject
                {
                    Id = 4,
                    Name = "Biology",
                    Description = "Study life and living organisms, including their structure, function, growth, origin, evolution, and distribution.",
                },
                new Subject
                {
                    Id = 5,
                    Name = "Literature",
                    Description = "National Revival literature",
                },
                new Subject
                {
                    Id = 6,
                    Name = "Chemistry",
                    Description = "Organic and inorganic chemistry",
                }
            );
        }
    }
}
