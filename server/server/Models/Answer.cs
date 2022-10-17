using Microsoft.EntityFrameworkCore;

namespace server.Models;

public class Answer
{
    public int AnswerID { get; set; }
    public string Text { get; set; }
    public bool Correct { get; set; }

    public int? QuestionID { get; set; }
    public virtual Question? Question { get; set; }
}