using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace server.Models;

public class CourseSection
{
    public int CourseSectionId { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public string Content { get; set; }
    public IdentityUser Author { get; set; }
    public List<Question> Questions { get; set; }
}