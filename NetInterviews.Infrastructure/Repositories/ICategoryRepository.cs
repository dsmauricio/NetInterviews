using NetInterviews.Core.Models;

namespace NetInterviews.Infrastructure.Repositories;

public interface ICategoryRepository
{
    Task<Category?> GetById(int id);
    Task<IEnumerable<Category>> GetAll();
    Task<Category> Create(string name);
    Task<Category?> Update(int id, string name);
    Task Delete(int id);
}