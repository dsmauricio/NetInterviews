using NetInterviews.Core.Enums;
using NetInterviews.Core.Models;

namespace NetInterviews.Core.DTO;
public class MovieResponse
{
    public required int Id { get; set; }
    public required string Title { get; set; }
    public required Ratings Rating { get; set; }
    public required bool Seen { get; set; }
    public required int CategoryId { get; set; }
    public CategoryResponse? Category { get; set; }
}
