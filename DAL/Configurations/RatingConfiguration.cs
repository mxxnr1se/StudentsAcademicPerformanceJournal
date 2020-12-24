using DAL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DAL.Configurations
{
    public class RatingConfiguration : IEntityTypeConfiguration<Rating>
    {
        public void Configure(EntityTypeBuilder<Rating> builder)
        {
            builder
                    .Property(r => r.Score)
                    .HasColumnType("decimal(5,2)")
                    .IsRequired();

            builder
                    .HasOne(r => r.Subject)
                    .WithMany(s => s.Ratings)
                    .HasForeignKey(r => r.SubjectId)
                    .OnDelete(DeleteBehavior.Cascade);

            builder
                    .HasOne(r => r.Student)
                    .WithMany(s => s.Ratings)
                    .HasForeignKey(r => r.StudentId)
                    .OnDelete(DeleteBehavior.Cascade);

            builder.HasData(
                    new Rating { Id = 1, SubjectId = 1, StudentId = 1, Score = 8.23m},
                    new Rating { Id = 2, SubjectId = 1, StudentId = 2, Score = 3.09m},
                    new Rating { Id = 3, SubjectId = 1, StudentId = 3, Score = 4.16m},
                    new Rating { Id = 4, SubjectId = 1, StudentId = 4, Score = 0.17m},
                    new Rating { Id = 5, SubjectId = 1, StudentId = 5, Score = 5.60m},
                    new Rating { Id = 6, SubjectId = 2, StudentId = 1, Score = 0.75m},
                    new Rating { Id = 7, SubjectId = 2, StudentId = 2, Score = 9.50m},
                    new Rating { Id = 8, SubjectId = 2, StudentId = 3, Score = 6.88m},
                    new Rating { Id = 9, SubjectId = 2, StudentId = 4, Score = 7.61m},
                    new Rating { Id = 10, SubjectId = 2, StudentId = 5, Score = 9.78m},
                    new Rating { Id = 11, SubjectId = 3, StudentId = 1, Score = 9.63m},
                    new Rating { Id = 12, SubjectId = 3, StudentId = 2, Score = 9.01m},
                    new Rating { Id = 13, SubjectId = 3, StudentId = 3, Score = 1.13m},
                    new Rating { Id = 14, SubjectId = 3, StudentId = 4, Score = 0.82m},
                    new Rating { Id = 15, SubjectId = 3, StudentId = 5, Score = 9.83m},
                    new Rating { Id = 16, SubjectId = 1, StudentId = 6, Score = 2.24m},
                    new Rating { Id = 17, SubjectId = 1, StudentId = 7, Score = 0.90m},
                    new Rating { Id = 18, SubjectId = 1, StudentId = 8, Score = 1.23m},
                    new Rating { Id = 19, SubjectId = 1, StudentId = 9, Score = 6.37m},
                    new Rating { Id = 20, SubjectId = 1, StudentId = 10, Score = 8.32m},
                    new Rating { Id = 21, SubjectId = 2, StudentId = 6, Score = 1.24m},
                    new Rating { Id = 22, SubjectId = 2, StudentId = 7, Score = 3.70m},
                    new Rating { Id = 23, SubjectId = 2, StudentId = 8, Score = 0.05m},
                    new Rating { Id = 24, SubjectId = 2, StudentId = 9, Score = 5.86m},
                    new Rating { Id = 25, SubjectId = 2, StudentId = 10, Score = 8.70m},
                    new Rating { Id = 26, SubjectId = 3, StudentId = 6, Score = 5.38m},
                    new Rating { Id = 27, SubjectId = 3, StudentId = 7, Score = 6.88m},
                    new Rating { Id = 28, SubjectId = 3, StudentId = 8, Score = 2.54m},
                    new Rating { Id = 29, SubjectId = 3, StudentId = 9, Score = 4.89m},
                    new Rating { Id = 30, SubjectId = 3, StudentId = 10, Score = 4.68m},
                    new Rating { Id = 31, SubjectId = 1, StudentId = 11, Score = 2.30m},
                    new Rating { Id = 32, SubjectId = 1, StudentId = 12, Score = 5.77m},
                    new Rating { Id = 33, SubjectId = 1, StudentId = 13, Score = 8.58m},
                    new Rating { Id = 34, SubjectId = 1, StudentId = 14, Score = 1.52m},
                    new Rating { Id = 35, SubjectId = 1, StudentId = 15, Score = 2.40m},
                    new Rating { Id = 36, SubjectId = 2, StudentId = 11, Score = 3.80m},
                    new Rating { Id = 37, SubjectId = 2, StudentId = 12, Score = 9.28m},
                    new Rating { Id = 38, SubjectId = 2, StudentId = 13, Score = 8.38m},
                    new Rating { Id = 39, SubjectId = 2, StudentId = 14, Score = 4.49m},
                    new Rating { Id = 40, SubjectId = 2, StudentId = 15, Score = 8.31m},
                    new Rating { Id = 41, SubjectId = 3, StudentId = 11, Score = 4.89m},
                    new Rating { Id = 42, SubjectId = 3, StudentId = 12, Score = 7.10m},
                    new Rating { Id = 43, SubjectId = 3, StudentId = 13, Score = 6.40m},
                    new Rating { Id = 44, SubjectId = 3, StudentId = 14, Score = 2.02m},
                    new Rating { Id = 45, SubjectId = 3, StudentId = 15, Score = 9.03m},
                    new Rating { Id = 46, SubjectId = 4, StudentId = 16, Score = 3.99m},
                    new Rating { Id = 47, SubjectId = 4, StudentId = 17, Score = 2.26m},
                    new Rating { Id = 48, SubjectId = 4, StudentId = 18, Score = 1.13m},
                    new Rating { Id = 49, SubjectId = 4, StudentId = 19, Score = 4.98m},
                    new Rating { Id = 50, SubjectId = 4, StudentId = 20, Score = 4.95m},
                    new Rating { Id = 51, SubjectId = 5, StudentId = 16, Score = 3.09m},
                    new Rating { Id = 52, SubjectId = 5, StudentId = 17, Score = 1.56m},
                    new Rating { Id = 53, SubjectId = 5, StudentId = 18, Score = 0.42m},
                    new Rating { Id = 54, SubjectId = 5, StudentId = 19, Score = 4.66m},
                    new Rating { Id = 55, SubjectId = 5, StudentId = 20, Score = 2.13m},
                    new Rating { Id = 56, SubjectId = 6, StudentId = 16, Score = 4.47m},
                    new Rating { Id = 57, SubjectId = 6, StudentId = 17, Score = 8.03m},
                    new Rating { Id = 58, SubjectId = 6, StudentId = 18, Score = 6.37m},
                    new Rating { Id = 59, SubjectId = 6, StudentId = 19, Score = 3.95m},
                    new Rating { Id = 60, SubjectId = 6, StudentId = 20, Score = 5.79m},
                    new Rating { Id = 61, SubjectId = 4, StudentId = 21, Score = 3.03m},
                    new Rating { Id = 62, SubjectId = 4, StudentId = 22, Score = 9.75m},
                    new Rating { Id = 63, SubjectId = 4, StudentId = 23, Score = 6.06m},
                    new Rating { Id = 64, SubjectId = 4, StudentId = 24, Score = 7.68m},
                    new Rating { Id = 65, SubjectId = 4, StudentId = 25, Score = 1.99m},
                    new Rating { Id = 66, SubjectId = 5, StudentId = 21, Score = 3.30m},
                    new Rating { Id = 67, SubjectId = 5, StudentId = 22, Score = 5.74m},
                    new Rating { Id = 68, SubjectId = 5, StudentId = 23, Score = 8.58m},
                    new Rating { Id = 69, SubjectId = 5, StudentId = 24, Score = 7.86m},
                    new Rating { Id = 70, SubjectId = 5, StudentId = 25, Score = 0.71m},
                    new Rating { Id = 71, SubjectId = 6, StudentId = 21, Score = 6.20m},
                    new Rating { Id = 72, SubjectId = 6, StudentId = 22, Score = 8.29m},
                    new Rating { Id = 73, SubjectId = 6, StudentId = 23, Score = 7.08m},
                    new Rating { Id = 74, SubjectId = 6, StudentId = 24, Score = 9.46m},
                    new Rating { Id = 75, SubjectId = 6, StudentId = 25, Score = 7.60m},
                    new Rating { Id = 76, SubjectId = 4, StudentId = 26, Score = 7.97m},
                    new Rating { Id = 77, SubjectId = 4, StudentId = 27, Score = 7.54m},
                    new Rating { Id = 78, SubjectId = 4, StudentId = 28, Score = 3.89m},
                    new Rating { Id = 79, SubjectId = 4, StudentId = 29, Score = 8.74m},
                    new Rating { Id = 80, SubjectId = 4, StudentId = 30, Score = 9.53m},
                    new Rating { Id = 81, SubjectId = 5, StudentId = 26, Score = 9.92m},
                    new Rating { Id = 82, SubjectId = 5, StudentId = 27, Score = 0.23m},
                    new Rating { Id = 83, SubjectId = 5, StudentId = 28, Score = 2.19m},
                    new Rating { Id = 84, SubjectId = 5, StudentId = 29, Score = 8.50m},
                    new Rating { Id = 85, SubjectId = 5, StudentId = 30, Score = 8.63m},
                    new Rating { Id = 86, SubjectId = 6, StudentId = 26, Score = 8.05m},
                    new Rating { Id = 87, SubjectId = 6, StudentId = 27, Score = 5.07m},
                    new Rating { Id = 88, SubjectId = 6, StudentId = 28, Score = 6.73m},
                    new Rating { Id = 89, SubjectId = 6, StudentId = 29, Score = 5.00m},
                    new Rating { Id = 90, SubjectId = 6, StudentId = 30, Score = 7.53m}
            );
        }
    }
}