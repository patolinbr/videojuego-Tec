using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using server.Models;

namespace server.Data;

public class ApplicationDbContext : IdentityDbContext
{
    public DbSet<Answer> Answers => Set<Answer>();
    public DbSet<Course> Courses => Set<Course>();
    public DbSet<CourseSection> CourseSections => Set<CourseSection>();
    public DbSet<CourseSectionScore> CourseSectionScores => Set<CourseSectionScore>();
    public DbSet<Question> Questions => Set<Question>();
    public DbSet<QuestionScore> QuestionScore => Set<QuestionScore>();

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }
}