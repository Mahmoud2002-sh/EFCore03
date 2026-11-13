using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace EFCore03.Migrations
{
    /// <inheritdoc />
    public partial class SeedInitialData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "CategoryId", "Description", "Name", "ParentCategoryId" },
                values: new object[] { 1, "Programming courses", "Programming", null });

            migrationBuilder.InsertData(
                table: "Instructors",
                columns: new[] { "InstructorId", "Bio", "Email", "FullName", "JoinedDate" },
                values: new object[,]
                {
                    { 1, "Backend Developer", "ahmed@example.com", "Ahmed Ali", new DateTime(2024, 1, 10, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2, "Frontend Developer", "sara@example.com", "Sara Mohamed", new DateTime(2024, 3, 15, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 3, "Database Specialist", "omar@example.com", "Omar Hassan", new DateTime(2024, 6, 20, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "CategoryId", "Description", "Name", "ParentCategoryId" },
                values: new object[,]
                {
                    { 2, "Backend development", "Backend", 1 },
                    { 4, "Frontend development", "Frontend", 1 },
                    { 5, "Database courses", "Databases", 1 }
                });

            migrationBuilder.InsertData(
                table: "Courses",
                columns: new[] { "CourseId", "CategoryId", "Description", "InstructorId", "IsPublished", "Level", "Price", "PublishedDate", "Title" },
                values: new object[] { 1, 1, "Learn C# basics", 1, true, "Beginner", 500m, new DateTime(2025, 1, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "C# Fundamentals" });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "CategoryId", "Description", "Name", "ParentCategoryId" },
                values: new object[] { 3, "ASP.NET Core courses", "ASP.NET", 2 });

            migrationBuilder.InsertData(
                table: "Courses",
                columns: new[] { "CourseId", "CategoryId", "Description", "InstructorId", "IsPublished", "Level", "Price", "PublishedDate", "Title" },
                values: new object[,]
                {
                    { 4, 4, "Frontend fundamentals", 2, true, "Beginner", 400m, new DateTime(2025, 3, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "HTML and CSS" },
                    { 5, 5, "Database fundamentals", 3, true, "Intermediate", 900m, new DateTime(2025, 4, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "SQL Server" }
                });

            migrationBuilder.InsertData(
                table: "Courses",
                columns: new[] { "CourseId", "CategoryId", "Description", "InstructorId", "Level", "Price", "PublishedDate", "Title" },
                values: new object[] { 6, 5, "Advanced SQL optimization", 3, "Advanced", 1500m, null, "Database Optimization" });

            migrationBuilder.InsertData(
                table: "Courses",
                columns: new[] { "CourseId", "CategoryId", "Description", "InstructorId", "IsPublished", "Level", "Price", "PublishedDate", "Title" },
                values: new object[] { 2, 3, "Build web applications", 1, true, "Intermediate", 1200m, new DateTime(2025, 2, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "ASP.NET Core" });

            migrationBuilder.InsertData(
                table: "Courses",
                columns: new[] { "CourseId", "CategoryId", "Description", "InstructorId", "Level", "Price", "PublishedDate", "Title" },
                values: new object[] { 3, 3, "Advanced backend development", 1, "Advanced", 1800m, null, "Advanced ASP.NET" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "CourseId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "CourseId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "CourseId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "CourseId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "CourseId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "CourseId",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Instructors",
                keyColumn: "InstructorId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Instructors",
                keyColumn: "InstructorId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Instructors",
                keyColumn: "InstructorId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 1);
        }
    }
}
