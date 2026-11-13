using Microsoft.EntityFrameworkCore;
using EFCore03.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCore03.Configurations
{
    public class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Category> builder)
        {
            builder.HasKey(c => c.CategoryId);

            builder.Property(c => c.Name)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(c => c.Description)
                .HasMaxLength(500);

            builder.HasOne(c => c.ParentCategory)
                .WithMany(c => c.SubCategories)
                .HasForeignKey(c => c.ParentCategoryId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasMany(c => c.Courses)
                .WithOne(c => c.Category)
                .HasForeignKey(c => c.CategoryId)
                .OnDelete(DeleteBehavior.Restrict);
            builder.HasData(
                new Category
                {
                    CategoryId = 1,
                    Name = "Programming",
                    Description = "Programming courses"
                },
                new Category
                {
                    CategoryId = 2,
                    Name = "Backend",
                    Description = "Backend development",
                    ParentCategoryId = 1
                },
                new Category
                {
                    CategoryId = 3,
                    Name = "ASP.NET",
                    Description = "ASP.NET Core courses",
                    ParentCategoryId = 2
                },
                new Category
                {
                    CategoryId = 4,
                    Name = "Frontend",
                    Description = "Frontend development",
                    ParentCategoryId = 1
                },
                new Category
                {
                    CategoryId = 5,
                    Name = "Databases",
                    Description = "Database courses",
                    ParentCategoryId = 1
                }
            );
        }
    }
}
