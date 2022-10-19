using Microsoft.EntityFrameworkCore;

namespace server.Models;

public class Question
{
    public int Id { get; set; }
    public string QuestionText { get; set; }
    public int Position { get; set; }
    
    public int? CourseSectionId { get; set; }
    public virtual CourseSection? CourseSection { get; set; }
    
    public int? CourseID { get; set; }
    public virtual Course? Course { get; set; }

    public virtual ICollection<Answer>? Answers { get; set; } = new List<Answer>();
}