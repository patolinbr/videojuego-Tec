using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace server.Models;

public class Course
{
    public int CourseID { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }

    public string? IdentityUserID { get; set; }
    public virtual IdentityUser? IdentityUser { get; set; }

    public virtual ICollection<CourseSection>? Sections { get; set; } = new List<CourseSection>();
    public virtual ICollection<Question>? Questions { get; set; } = new List<Question>();
}