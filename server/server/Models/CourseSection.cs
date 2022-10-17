using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace server.Models;

public class CourseSection
{
    public int CourseSectionID { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public string Content { get; set; }

    public int CourseID { get; set; }
    public virtual Course Course { get; set; }

    public int UserID { get; set; }
    public virtual IdentityUser IdentityUser { get; set; }
    
    public virtual ICollection<Question> Questions { get; set; }
}