using NetInterviews.Core.DTO;
using NetInterviews.Infrastructure.Repositories;

namespace NetInterviews.Business.Services;

public class CategoryService : ICategoryService
{
    private readonly ICategoryRepository _categoryRepository;
    public CategoryService(ICategoryRepository categoryRepository)
    {
        _categoryRepository = categoryRepository;
    }

    public async Task<CategoryResponse> Add(CategoryRequest categoryRequest)
    {
        var category = await _categoryRepository.Create(categoryRequest.Name);

        var categoryResponse = new CategoryResponse() { Id = category.Id, Name = category.Name };
        return categoryResponse;
    }

    public async Task<CategoryResponse?> Update(int id, CategoryRequest categoryRequest)
    {
        var category = await _categoryRepository.Update(id, categoryRequest.Name);
        if (category is null)
        {
            return null;
        }

        var categoryResponse = new CategoryResponse() { Id = category.Id, Name = category.Name };
        return categoryResponse;
    }

    public async Task Delete(int id)
    {
        await _categoryRepository.Delete(id);
    }

    public async Task<CategoryResponse?> GetById(int id)
    {
        var category = await _categoryRepository.GetById(id);
        if (category is null)
        {
            return null;
        }

        var categoryResponse = new CategoryResponse() { Id = category.Id, Name = category.Name };
        return categoryResponse;
    }

    public async Task<IEnumerable<CategoryResponse>> GetAll()
    {
        var categories = await _categoryRepository.GetAll();

        var categoriesResponse = categories.Select(c => new CategoryResponse
        {
            Id = c.Id,
            Name = c.Name
        });

        return categoriesResponse;
    }

}
