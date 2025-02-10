using Microsoft.EntityFrameworkCore;

using NetInterviews.Core.Models;
using NetInterviews.Infrastructure.Data;

namespace NetInterviews.Infrastructure.Repositories;

public class CategoryRepository : ICategoryRepository
{
    private readonly MovieDbContext _db;
    public CategoryRepository(MovieDbContext db)
    {
        _db = db;
    }


    public async Task<Category?> GetById(int id)
    {
        var category = await _db.Categories.FirstOrDefaultAsync(c => c.Id == id);
        return category;
    }

    public async Task<IEnumerable<Category>> GetAll()
    {
        var categories = await _db.Categories.ToListAsync();
        return categories;
    }

    public async Task<Category> Create(string name)
    {
        var category = new Category()
        {
            Name = name
        };

        _db.Categories.Add(category);
        await _db.SaveChangesAsync();

        return category;
    }

    public async Task<Category?> Update(int id, string name)
    {
        var category = await _db.Categories.FindAsync(id);
        if (category is not null)
        {
            category.Name = name;
            await _db.SaveChangesAsync();
            return category;
        }

        return null;
    }

    public async Task Delete(int id)
    {
        var category = await _db.Categories.FindAsync(id);
        if (category is not null)
        {
            _db.Categories.Remove(category);
            await _db.SaveChangesAsync();
        }
    }
}
