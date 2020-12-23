using System;
using DAL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DAL.Configurations
{
    public class StrudentConfiguration : IEntityTypeConfiguration<Student>
    {
        public void Configure(EntityTypeBuilder<Student> builder)
        {
            builder
                    .Property(s => s.FirstName)
                    .HasMaxLength(30)
                    .IsRequired();

            builder
                    .Property(s => s.LastName)
                    .HasMaxLength(30)
                    .IsRequired();

            builder
                    .HasOne(s => s.Group)
                    .WithMany(g => g.Students)
                    .HasForeignKey(s => s.GroupId)
                    .OnDelete(DeleteBehavior.SetNull);

            builder
                    .Property(s => s.AvgScore)
                    .HasColumnType("decimal(5,2)")
                    .HasDefaultValue(0m);
            
            // .HasDefaultValueSql("SELECT SUM(Score)/count(*) FROM Ratings JOIN Students ON Ratings.StudentId == Students.Id");
            
            builder.HasData(
                    new Student {Id = 1, FirstName = "Kylo", LastName = "Rowland", GroupId = 1},
                    new Student {Id = 2, FirstName = "Mylee", LastName = "Millington", GroupId = 1},
                    new Student {Id = 3, FirstName = "Summer", LastName = "Muir", GroupId = 1},
                    new Student {Id = 4, FirstName = "Shaunie", LastName = "Broughton", GroupId = 1},
                    new Student {Id = 5, FirstName = "Cienna", LastName = "Nixon", GroupId = 1},
                    new Student {Id = 6, FirstName = "Aaliya", LastName = "Arias", GroupId = 2},
                    new Student {Id = 7, FirstName = "Ansh", LastName = "Horne", GroupId = 2},
                    new Student {Id = 8, FirstName = "Tamera ", LastName = "Kramer", GroupId = 2},
                    new Student {Id = 9, FirstName = "Lucca", LastName = "Weiss", GroupId = 2},
                    new Student {Id = 10, FirstName = "June", LastName = "Griffiths", GroupId = 2},
                    new Student {Id = 11, FirstName = "Graeme", LastName = "Dudley", GroupId = 3},
                    new Student {Id = 12, FirstName = "Kya", LastName = "Turnbull", GroupId = 3},
                    new Student {Id = 13, FirstName = "Jermaine", LastName = "Daugherty", GroupId = 3},
                    new Student {Id = 14, FirstName = "Nelson", LastName = "Haden", GroupId = 3},
                    new Student {Id = 15, FirstName = "Jaylan", LastName = "Sloan", GroupId = 3},
                    new Student {Id = 16, FirstName = "Catherine", LastName = "Murillo", GroupId = 4},
                    new Student {Id = 17, FirstName = "Erik", LastName = "Cunningham", GroupId = 4},
                    new Student {Id = 18, FirstName = "Maribel", LastName = "Barnes", GroupId = 4},
                    new Student {Id = 19, FirstName = "Isaac", LastName = "Benton", GroupId = 4},
                    new Student {Id = 20, FirstName = "Elliott", LastName = "Copeland", GroupId = 4},
                    new Student {Id = 21, FirstName = "Elsa", LastName = "Holloway", GroupId = 5},
                    new Student {Id = 22, FirstName = "Odin", LastName = "Haley", GroupId = 5},
                    new Student {Id = 23, FirstName = "Carter", LastName = "Page", GroupId = 5},
                    new Student {Id = 24, FirstName = "Sonia", LastName = "Rose", GroupId = 5},
                    new Student {Id = 25, FirstName = "Johnathan", LastName = "Howell", GroupId = 5},
                    new Student {Id = 26, FirstName = "Nelson", LastName = "Stark", GroupId = 6},
                    new Student {Id = 27, FirstName = "Bianca", LastName = "Bradford", GroupId = 6},
                    new Student {Id = 28, FirstName = "Ariana", LastName = "Hernandez", GroupId = 6},
                    new Student {Id = 29, FirstName = "Darryl", LastName = "Nielsen", GroupId = 6},
                    new Student {Id = 30, FirstName = "Brooke", LastName = "Roberts", GroupId = 6}
            );
        }
    }
}