using DAL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DAL.Configurations
{
    public class SubjectConfiguration : IEntityTypeConfiguration<Subject>
    {
        public void Configure(EntityTypeBuilder<Subject> builder)
        {
            builder
                    .Property(s => s.Title)
                    .HasMaxLength(50)
                    .IsRequired();
            
            builder.HasData(
                    new Subject {Id = 1, Title = "Information Systems"},
                    new Subject {Id = 2, Title = "Computer Science"},
                    new Subject {Id = 3, Title = "Software Engineering"},
                    new Subject {Id = 4, Title = "Artificial Intelligence"},
                    new Subject {Id = 5, Title = "Network engineering"},
                    new Subject {Id = 6, Title = "Data analytics"}
            );
        }
    }
}