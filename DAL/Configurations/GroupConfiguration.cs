using DAL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DAL.Configurations
{
    public class GroupConfiguration : IEntityTypeConfiguration<Group>
    {
        public void Configure(EntityTypeBuilder<Group> builder)
        {
            builder
                    .Property(g => g.Number)
                    .HasMaxLength(10)
                    .IsRequired();

            builder.HasData(
                    new Group {Id = 1, Number = "IS-11"},
                    new Group {Id = 2, Number = "IS-12"},
                    new Group {Id = 3, Number = "IS-13"},
                    new Group {Id = 4, Number = "IS-21"},
                    new Group {Id = 5, Number = "IS-22"},
                    new Group {Id = 6, Number = "IS-23"}
            );
        }
    }
}