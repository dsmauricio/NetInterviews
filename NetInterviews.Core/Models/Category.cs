namespace NetInterviews.Core.Models;

public class Category
{
    public int Id { get; set; }
    public required string Name { get; set; }
    public virtual IList<Movie> Movies { get; set; }

    public Category()
    {
        Movies = new List<Movie>();
    }
}
