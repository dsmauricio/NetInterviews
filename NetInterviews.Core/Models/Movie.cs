using NetInterviews.Core.Enums;

namespace NetInterviews.Core.Models;

public class Movie
{
    public int Id { get; set; }
    public required string Title { get; set; }
    public Ratings Rating { get; set; }
    public bool Seen { get; set; }
    public required int CategoryId { get; set; }
    public Category Category { get; set; } = null!;
}
