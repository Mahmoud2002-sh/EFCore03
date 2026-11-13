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
    public class InstructorConfiguration : IEntityTypeConfiguration<Instructor>
    {
        public void Configure(EntityTypeBuilder<Instructor> builder)
        {
            builder.HasKey(i => i.InstructorId);

            builder.Property(i => i.FullName)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(i => i.Email)
                .IsRequired()
                .HasMaxLength(150);

            builder.Property(i => i.Bio)
                .HasMaxLength(500);

            builder.Property(i => i.JoinedDate)
                .IsRequired();

            builder.HasMany(i => i.Courses)
                .WithOne(c => c.Instructor)
                .HasForeignKey(c => c.InstructorId)
                .OnDelete(DeleteBehavior.Restrict);
            builder.HasData(
                new Instructor
                {
                    InstructorId = 1,
                    FullName = "Ahmed Ali",
                    Email = "ahmed@example.com",
                    Bio = "Backend Developer",
                    JoinedDate = new DateTime(2024, 1, 10)
                },
                new Instructor
                {
                    InstructorId = 2,
                    FullName = "Sara Mohamed",
                    Email = "sara@example.com",
                    Bio = "Frontend Developer",
                    JoinedDate = new DateTime(2024, 3, 15)
                },
                new Instructor
                {
                    InstructorId = 3,
                    FullName = "Omar Hassan",
                    Email = "omar@example.com",
                    Bio = "Database Specialist",
                    JoinedDate = new DateTime(2024, 6, 20)
                }
            );
        }
    }
}
