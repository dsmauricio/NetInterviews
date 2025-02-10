using NetInterviews.Core.Enums;
using NetInterviews.Core.Models;

namespace NetInterviews.Core.DTO;
public class MovieRequest
{
    public required string Title { get; set; }
    public Ratings Rating { get; set; }
    public bool Seen { get; set; }
    public required int CategoryId { get; set; }
}
