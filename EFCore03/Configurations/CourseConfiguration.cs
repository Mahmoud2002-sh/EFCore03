using EFCore03.Enums;
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
    public class CourseConfiguration : IEntityTypeConfiguration<Course>
    {
        public void Configure(EntityTypeBuilder<Course> builder)
        {
            builder.HasKey(c => c.CourseId);

            builder.Property(c => c.Title)
                .IsRequired()
                .HasMaxLength(200);

            builder.Property(c => c.Description)
                .HasMaxLength(1000);

            builder.Property(c => c.Price)
                .IsRequired()
                .HasPrecision(18, 2);

            builder.Property(c => c.Level)
                .IsRequired()
                .HasConversion<string>()
                .HasMaxLength(20);

            builder.Property(c => c.IsPublished)
                .IsRequired()
                .HasDefaultValue(false);

            builder.Property(c => c.PublishedDate)
                .IsRequired(false);

            builder.HasOne(c => c.Instructor)
                .WithMany(i => i.Courses)
                .HasForeignKey(c => c.InstructorId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(c => c.Category)
                .WithMany(cat => cat.Courses)
                .HasForeignKey(c => c.CategoryId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasMany(c => c.Enrollments)
                .WithOne(e => e.Course)
                .HasForeignKey(e => e.CourseId)
                .OnDelete(DeleteBehavior.Cascade);
            builder.HasData(
                new Course
                {
                    CourseId = 1,
                    Title = "C# Fundamentals",
                    Description = "Learn C# basics",
                    Price = 500m,
                    Level = CourseLevel.Beginner,
                    IsPublished = true,
                    PublishedDate = new DateTime(2025, 1, 10),
                    InstructorId = 1,
                    CategoryId = 1
                },
                new Course
                {
                    CourseId = 2,
                    Title = "ASP.NET Core",
                    Description = "Build web applications",
                    Price = 1200m,
                    Level = CourseLevel.Intermediate,
                    IsPublished = true,
                    PublishedDate = new DateTime(2025, 2, 15),
                    InstructorId = 1,
                    CategoryId = 3
                },
                new Course
                {
                    CourseId = 3,
                    Title = "Advanced ASP.NET",
                    Description = "Advanced backend development",
                    Price = 1800m,
                    Level = CourseLevel.Advanced,
                    IsPublished = false,
                    PublishedDate = null,
                    InstructorId = 1,
                    CategoryId = 3
                },
                new Course
                {
                    CourseId = 4,
                    Title = "HTML and CSS",
                    Description = "Frontend fundamentals",
                    Price = 400m,
                    Level = CourseLevel.Beginner,
                    IsPublished = true,
                    PublishedDate = new DateTime(2025, 3, 10),
                    InstructorId = 2,
                    CategoryId = 4
                },
                new Course
                {
                    CourseId = 5,
                    Title = "SQL Server",
                    Description = "Database fundamentals",
                    Price = 900m,
                    Level = CourseLevel.Intermediate,
                    IsPublished = true,
                    PublishedDate = new DateTime(2025, 4, 20),
                    InstructorId = 3,
                    CategoryId = 5
                },
                new Course
                {
                    CourseId = 6,
                    Title = "Database Optimization",
                    Description = "Advanced SQL optimization",
                    Price = 1500m,
                    Level = CourseLevel.Advanced,
                    IsPublished = false,
                    PublishedDate = null,
                    InstructorId = 3,
                    CategoryId = 5
                }
            );

        }
    }
}
