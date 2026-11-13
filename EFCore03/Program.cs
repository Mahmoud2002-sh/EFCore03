using EFCore03.Contexts;
using EFCore03.Enums;
using EFCore03.Models;
using Microsoft.EntityFrameworkCore;

namespace EFCore03
{
    internal class Program
    {
        static void SeedStudents(AppDbContext context)
        {
            if (context.Students.Any())
            {
                Console.WriteLine("Students already seeded.");
                return;
            }

            var students = new List<Student>
            {
                new Student
                {
                    FullName = "Mahmoud Ali",
                    Email = "mahmoud@example.com",
                    DateOfBirth = new DateTime(2003, 5, 10)
                },
                new Student
                {
                    FullName = "Youssef Ahmed",
                    Email = "youssef@example.com",
                    DateOfBirth = new DateTime(2002, 8, 15)
                },
                new Student
                {
                    FullName = "Mariam Hassan",
                    Email = "mariam@example.com",
                    DateOfBirth = new DateTime(2004, 2, 20)
                },
                new Student
                {
                    FullName = "Omar Khaled",
                    Email = "omark@example.com",
                    DateOfBirth = new DateTime(2003, 11, 5)
                },
                new Student
                {
                    FullName = "Nour Mohamed",
                    Email = "nour@example.com",
                    DateOfBirth = new DateTime(2002, 7, 25)
                }
            };

            context.Students.AddRange(students);
            context.SaveChanges();

            Console.WriteLine("5 students seeded successfully.");
        }
        static void SeedEnrollments(AppDbContext context)
        {
            if (context.Enrollments.Any())
            {
                Console.WriteLine("Enrollments already seeded.");
                return;
            }

            var emails = new[]
            {
        "mahmoud@example.com",
        "youssef@example.com",
        "mariam@example.com",
        "omark@example.com",
        "nour@example.com"
    };

            var studentIds = context.Students
                .Where(s => emails.Contains(s.Email))
                .ToDictionary(s => s.Email, s => s.StudentId);

            if (emails.Any(email => !studentIds.ContainsKey(email)))
            {
                Console.WriteLine("Seed students are missing.");
                return;
            }

            var publishedCourseIds = context.Courses
                .Where(c => c.IsPublished)
                .Select(c => c.CourseId)
                .ToList();

            if (!new[] { 1, 2, 4, 5 }
                .All(id => publishedCourseIds.Contains(id)))
            {
                Console.WriteLine("Required published courses are missing.");
                return;
            }

            var enrollments = new List<Enrollment>
            {
                new Enrollment
                {
                    StudentId = studentIds["mahmoud@example.com"],
                    CourseId = 1,
                    EnrollmentDate = new DateTime(2025, 9, 1),
                    ProgressPercentage = 40m,
                    Status = EnrollmentStatus.Active
                },
                new Enrollment
                {
                    StudentId = studentIds["mahmoud@example.com"],
                    CourseId = 2,
                    EnrollmentDate = new DateTime(2025, 9, 2),
                    ProgressPercentage = 100m,
                    Status = EnrollmentStatus.Completed,
                    FinalGrade = 95m
                },
                new Enrollment
                {
                    StudentId = studentIds["youssef@example.com"],
                    CourseId = 1,
                    EnrollmentDate = new DateTime(2025, 9, 3),
                    ProgressPercentage = 20m,
                    Status = EnrollmentStatus.Active
                },
                new Enrollment
                {
                    StudentId = studentIds["youssef@example.com"],
                    CourseId = 4,
                    EnrollmentDate = new DateTime(2025, 9, 4),
                    ProgressPercentage = 30m,
                    Status = EnrollmentStatus.Dropped
                },
                new Enrollment
                {
                    StudentId = studentIds["mariam@example.com"],
                    CourseId = 2,
                    EnrollmentDate = new DateTime(2025, 9, 5),
                    ProgressPercentage = 100m,
                    Status = EnrollmentStatus.Completed,
                    FinalGrade = 90m
                },
                new Enrollment
                {
                    StudentId = studentIds["omar k@example.com".Replace(" ", "")],
                    CourseId = 5,
                    EnrollmentDate = new DateTime(2025, 9, 6),
                    ProgressPercentage = 60m,
                    Status = EnrollmentStatus.Active
                },
                new Enrollment
                {
                    StudentId = studentIds["nour@example.com"],
                    CourseId = 4,
                    EnrollmentDate = new DateTime(2025, 9, 7),
                    ProgressPercentage = 100m,
                    Status = EnrollmentStatus.Completed,
                    FinalGrade = 88m
                },
                new Enrollment
                {
                    StudentId = studentIds["nour@example.com"],
                    CourseId = 5,
                    EnrollmentDate = new DateTime(2025, 9, 8),
                    ProgressPercentage = 15m,
                    Status = EnrollmentStatus.Dropped
                }
            };

            context.Enrollments.AddRange(enrollments);
            context.SaveChanges();

            Console.WriteLine("8 enrollments seeded successfully.");
        }
        static void AddInstructor(AppDbContext context)
        {
            Instructor instructor = new Instructor
            {
                FullName = "Mohamed Adel",
                Email = "mohamed.adel@example.com",
                Bio = "Software Engineer",
                JoinedDate = DateTime.Now
            };

            context.Instructors.Add(instructor);
            context.SaveChanges();

            Console.WriteLine(
                $"Instructor added with ID: {instructor.InstructorId}");
        }
        static void AddCourse(AppDbContext context,int instructorId,int categoryId)
        {
            if (!context.Instructors.Any(i => i.InstructorId == instructorId))
            {
                Console.WriteLine("Instructor not found.");
                return;
            }

            if (!context.Categories.Any(c => c.CategoryId == categoryId))
            {
                Console.WriteLine("Category not found.");
                return;
            }

            Course course = new Course
            {
                Title = "Entity Framework Core",
                Description = "Learn EF Core",
                Price = 800m,
                Level = CourseLevel.Intermediate,
                IsPublished = true,
                PublishedDate = DateTime.Now,
                InstructorId = instructorId,
                CategoryId = categoryId
            };

            context.Courses.Add(course);
            context.SaveChanges();

            Console.WriteLine($"Course added with ID: {course.CourseId}");
        }
        static void AddSeveralStudents(AppDbContext context)
        {
            var students = new List<Student>
            {
                new Student
                {
                    FullName = "Ali Hassan",
                    Email = "ali.hassan@example.com",
                    DateOfBirth = new DateTime(2003, 5, 10)
                },
                new Student
                {
                    FullName = "Mona Ahmed",
                    Email = "mona.ahmed@example.com",
                    DateOfBirth = new DateTime(2002, 8, 15)
                },
                new Student
                {
                    FullName = "Khaled Omar",
                    Email = "khaled.omar@example.com",
                    DateOfBirth = new DateTime(2004, 2, 20)
                }
            };

            context.Students.AddRange(students);
            context.SaveChanges();

            foreach (var student in students)
            {
                Console.WriteLine(
                    $"Student: {student.FullName}, ID: {student.StudentId}");
            }
        }
        static void EnrollStudent(AppDbContext context,int studentId,int courseId)
        {
            if (!context.Students.Any(s => s.StudentId == studentId))
            {
                Console.WriteLine("Student not found.");
                return;
            }

            var course = context.Courses.Find(courseId);

            if (course == null)
            {
                Console.WriteLine("Course not found.");
                return;
            }

            if (!course.IsPublished)
            {
                Console.WriteLine("Cannot enroll in an unpublished course.");
                return;
            }

            if (context.Enrollments.Any(e =>
                e.StudentId == studentId &&
                e.CourseId == courseId))
            {
                Console.WriteLine("Student is already enrolled.");
                return;
            }

            Enrollment enrollment = new Enrollment
            {
                StudentId = studentId,
                CourseId = courseId,
                EnrollmentDate = DateTime.Now,
                ProgressPercentage = 0,
                Status = EnrollmentStatus.Active
            };

            context.Enrollments.Add(enrollment);
            context.SaveChanges();

            Console.WriteLine("Student enrolled successfully.");
        }
        static void FindCourse(AppDbContext context,int courseId,string title)
        {
            var courseById = context.Courses.Find(courseId);

            if (courseById == null)
                Console.WriteLine("Course ID not found.");
            else
                Console.WriteLine($"Found by ID: {courseById.Title}");

            var courseByTitle = context.Courses.FirstOrDefault(c => c.Title == title);

            if (courseByTitle == null)
                Console.WriteLine("Course title not found.");
            else
                Console.WriteLine($"Found by Title: {courseByTitle.Title}");
        }
        static void FilterCourses(AppDbContext context,decimal minPrice,decimal maxPrice)
        {
            if (minPrice < 0 || maxPrice < minPrice)
            {
                Console.WriteLine("Invalid price range.");
                return;
            }

            var courses = context.Courses
                .Where(c => c.Price >= minPrice &&
                            c.Price <= maxPrice)
                .OrderByDescending(c => c.Price)
                .Select(c => new
                {
                    c.Title,
                    c.Level,
                    c.Price
                })
                .ToList();

            if (courses.Count == 0)
            {
                Console.WriteLine("No courses found.");
                return;
            }

            foreach (var course in courses)
            {
                Console.WriteLine(
                    $"{course.Title} | {course.Level} | {course.Price}");
            }
        }
        static void PrintCategories(AppDbContext context,int categoryId)
        {
            if (!context.Categories.Any(c => c.CategoryId == categoryId))
            {
                Console.WriteLine("Category not found.");
                return;
            }

            var subCategories = context.Categories
                .Where(c => c.ParentCategoryId == categoryId)
                .ToList();

            Console.WriteLine("Direct Sub-Categories:");

            if (subCategories.Count == 0)
                Console.WriteLine("No sub-categories found.");

            foreach (var category in subCategories)
                Console.WriteLine(category.Name);

            var topLevelCategories = context.Categories
                .Where(c => c.ParentCategoryId == null)
                .ToList();

            Console.WriteLine("Top-Level Categories:");

            foreach (var category in topLevelCategories)
                Console.WriteLine(category.Name);
        }
        static void CourseRoster(AppDbContext context,int courseId)
        {
            if (!context.Courses.Any(c => c.CourseId == courseId))
            {
                Console.WriteLine("Course not found.");
                return;
            }

            var studentIds = context.Enrollments
                .Where(e => e.CourseId == courseId)
                .Select(e => e.StudentId)
                .ToList();

            var students = context.Students
                .Where(s => studentIds.Contains(s.StudentId))
                .ToList();

            Console.WriteLine($"Enrolled Students: {students.Count}");

            foreach (var student in students)
                Console.WriteLine(student.FullName);
        }
        static void ChangeCoursePrice(AppDbContext context,int courseId,decimal newPrice)
        {
            if (newPrice < 0)
            {
                Console.WriteLine("Price cannot be negative.");
                return;
            }

            var course = context.Courses.Find(courseId);

            if (course == null)
            {
                Console.WriteLine("Course not found.");
                return;
            }

            course.Price = newPrice;
            context.SaveChanges();

            Console.WriteLine($"Price updated to {course.Price}");
        }
        static void UpdateProgress(AppDbContext context,int studentId,int courseId,decimal newProgress)
        {
            if (newProgress < 0 || newProgress > 100)
            {
                Console.WriteLine("Progress must be between 0 and 100.");
                return;
            }

            var enrollment = context.Enrollments.Find(studentId, courseId);

            if (enrollment == null)
            {
                Console.WriteLine("Enrollment not found.");
                return;
            }

            enrollment.ProgressPercentage = newProgress;

            if (newProgress == 100)
            {
                enrollment.Status = EnrollmentStatus.Completed;
            }
            else if (enrollment.Status == EnrollmentStatus.Completed)
            {
                enrollment.Status = EnrollmentStatus.Active;
                enrollment.FinalGrade = null;
            }

            context.SaveChanges();

            Console.WriteLine(
                $"Progress: {enrollment.ProgressPercentage}% | Status: {enrollment.Status}");
        }
        static void PublishCourse(AppDbContext context,int courseId)
        {
            var course = context.Courses.Find(courseId);

            if (course == null)
            {
                Console.WriteLine("Course not found.");
                return;
            }

            if (course.IsPublished)
            {
                Console.WriteLine("Course is already published.");
                return;
            }

            course.IsPublished = true;
            course.PublishedDate = DateTime.Now;

            context.SaveChanges();

            Console.WriteLine(
                $"Course published on {course.PublishedDate}");
        }
        static void UnenrollStudent(AppDbContext context,int studentId,int courseId)
        {
            var enrollment = context.Enrollments.Find(
                studentId, courseId);

            if (enrollment == null)
            {
                Console.WriteLine("Enrollment not found.");
                return;
            }

            context.Enrollments.Remove(enrollment);
            context.SaveChanges();

            Console.WriteLine("Student unenrolled successfully.");
        }
        static void DeleteCategoryUnsafe(AppDbContext context,int categoryId)
        {
            var category = context.Categories.Find(categoryId);

            if (category == null)
            {
                Console.WriteLine("Category not found.");
                return;
            }

            try
            {
                context.Categories.Remove(category);
                context.SaveChanges();

                Console.WriteLine("Category deleted successfully.");
            }
            catch (DbUpdateException ex)
            {
                Console.WriteLine("Cannot delete category.");
                Console.WriteLine(ex.InnerException?.Message ?? ex.Message);

                context.Entry(category).State = EntityState.Unchanged;
            }
        }
        static void DeleteCategorySafe(AppDbContext context,int categoryId)
        {
            var category = context.Categories.Find(categoryId);

            if (category == null)
            {
                Console.WriteLine("Category not found.");
                return;
            }

            bool hasSubCategories = context.Categories
                .Any(c => c.ParentCategoryId == categoryId);

            if (hasSubCategories)
            {
                Console.WriteLine(
                    "Cannot delete category because it has sub-categories.");
                return;
            }

            bool hasCourses = context.Courses
                .Any(c => c.CategoryId == categoryId);

            if (hasCourses)
            {
                Console.WriteLine(
                    "Cannot delete category because it contains courses.");
                return;
            }

            context.Categories.Remove(category);
            context.SaveChanges();

            Console.WriteLine("Category deleted successfully.");
        }
        static void DeleteCourse(AppDbContext context,int courseId)
        {
            var course = context.Courses.Find(courseId);

            if (course == null)
            {
                Console.WriteLine("Course not found.");
                return;
            }

            int before = context.Enrollments
                .Count(e => e.CourseId == courseId);

            Console.WriteLine($"Enrollments before deletion: {before}");

            if (before == 0)
            {
                Console.WriteLine(
                    "This course has no enrollments to demonstrate cascade deletion.");
                return;
            }

            context.Courses.Remove(course);
            context.SaveChanges();

            int after = context.Enrollments
                .Count(e => e.CourseId == courseId);

            Console.WriteLine($"Enrollments after deletion: {after}");

        }
        static void BulkPriceRaise(AppDbContext context,CourseLevel level)
        {
            int affectedRows = context.Courses
                .Where(c => c.IsPublished && c.Level == level)
                .ExecuteUpdate(setters => setters
                .SetProperty(c => c.Price,c => c.Price * 1.10m)
                );

            Console.WriteLine($"Prices increased by 10%. Affected rows: {affectedRows}");
        }
        static void BulkDeleteDropped(AppDbContext context)
        {
            int affectedRows = context.Enrollments
                .Where(e => e.Status == EnrollmentStatus.Dropped)
                .ExecuteDelete();

            Console.WriteLine($"Dropped enrollments deleted: {affectedRows}");
        }
        static void Main(string[] args)
        {
            using AppDbContext context = new AppDbContext();

            Console.WriteLine("Online Learning Platform");

            if (context.Database.CanConnect())
            {
                Console.WriteLine("Database connected successfully!");
            }
            else
            {
                Console.WriteLine("Database connection failed!");
            }
            SeedStudents(context);
            SeedEnrollments(context);

            Console.WriteLine("Seeding completed.");

            Console.WriteLine("\n===== CREATE =====");

            AddInstructor(context);
            AddCourse(context, 1, 3);
            AddSeveralStudents(context);

            // Use the students inserted during seeding
            int studentId = context.Students
                .Where(s => s.Email == "mahmoud@example.com")
                .Select(s => s.StudentId)
                .FirstOrDefault();

            if (studentId != 0)
            {
                EnrollStudent(context, studentId, 5);
            }

            // Read
            Console.WriteLine("\n===== READ =====");

            FindCourse(context, 1, "ASP.NET Core");
            FilterCourses(context, 400m, 1500m);
            PrintCategories(context, 1);
            CourseRoster(context, 2);

            // Update
            Console.WriteLine("\n===== UPDATE =====");

            ChangeCoursePrice(context, 1, 650m);

            if (studentId != 0)
            {
                UpdateProgress(context, studentId, 5, 100m);
            }

            PublishCourse(context, 3);

            // Delete
            Console.WriteLine("\n===== DELETE =====");

            if (studentId != 0)
            {
                UnenrollStudent(context, studentId, 5);
            }

            DeleteCategoryUnsafe(context, 1); 
            DeleteCategorySafe(context, 1);

            // Course 2 has seeded enrollments
            DeleteCourse(context, 2);

            // Bulk Operations
            Console.WriteLine("\n===== BULK OPERATIONS =====");

            BulkPriceRaise(context, CourseLevel.Beginner);
            BulkDeleteDropped(context);

            Console.WriteLine("\nAll operations completed.");

        }
    }
}
