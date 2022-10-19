using Microsoft.AspNetCore.Identity;

namespace server.Models;

public class CourseSectionScore
{
    public int CourseSectionScoreID { get; set; }

    public DateTime AnswerTime { get; set; }

    public string? IdentityUserID { get; set; }
    public virtual IdentityUser? User { get; set; }

    public int? CourseSectionID { get; set; }
    public virtual CourseSection? CourseSection { get; set; }

    public int? CourseID { get; set; }
    public virtual Course? Course { get; set; }

    public virtual ICollection<QuestionScore>? QuestionScores { get; set; } = new List<QuestionScore>();

    public int Score { get; set; }
}