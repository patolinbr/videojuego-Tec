using Microsoft.AspNetCore.Identity;

namespace server.Models;

public class QuestionScore
{
    public int QuestionScoreID { get; set; }

    public DateTime AnswerTime { get; set; }

    public int IdentityUserID { get; set; }
    public virtual IdentityUser IdentityUser { get; set; }

    public int QuestionID { get; set; }
    public virtual Question Question { get; set; }

    public int CourseSectionID { get; set; }
    public virtual CourseSection CourseSection { get; set; }

    public int CourseID { get; set; }
    public virtual Course Course { get; set; }

    public int Score { get; set; }
}