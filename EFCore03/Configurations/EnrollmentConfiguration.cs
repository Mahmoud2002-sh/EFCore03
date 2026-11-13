using EFCore03.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCore03.Configurations
{
    public class EnrollmentConfiguration : IEntityTypeConfiguration<Enrollment>
    {
        public void Configure(EntityTypeBuilder<Enrollment> builder)
        {
            builder.HasKey(e => new
            {
                e.StudentId,
                e.CourseId
            });

            builder.Property(e => e.EnrollmentDate)
                .IsRequired();

            builder.Property(e => e.ProgressPercentage)
                .IsRequired()
                .HasPrecision(5, 2);

            builder.Property(e => e.Status)
                .IsRequired()
                .HasConversion<string>()
                .HasMaxLength(20);

            builder.Property(e => e.FinalGrade)
                .HasPrecision(5, 2)
                .IsRequired(false);

            builder.HasOne(e => e.Student)
                .WithMany(s => s.Enrollments)
                .HasForeignKey(e => e.StudentId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(e => e.Course)
                .WithMany(c => c.Enrollments)
                .HasForeignKey(e => e.CourseId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.ToTable(t =>
                t.HasCheckConstraint(
                    "CK_Enrollment_Progress",
                    "[ProgressPercentage] BETWEEN 0 AND 100"
                ));
        }
    }
}
