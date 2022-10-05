using Microsoft.EntityFrameworkCore;

namespace server.Models;

public class Question
{
    public int QuestionId { get; set; }
    public string QuestionText { get; set; }
    public int Position { get; set; }
    public List<Answer> Answers { get; set; }
}