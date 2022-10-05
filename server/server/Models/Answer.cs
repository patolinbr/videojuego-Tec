using Microsoft.EntityFrameworkCore;

namespace server.Models;

public class Answer
{
    public int AnswerId { get; set; }
    public string Text { get; set; }
    public bool Correct { get; set; }
}