using NetInterviews.Core.DTO;

namespace NetInterviews.Business.Services;

public interface ICategoryService
{
    Task<CategoryResponse> Add(CategoryRequest categoryRequest);
    Task<CategoryResponse?> Update(int id, CategoryRequest categoryRequest);
    Task Delete(int id);
    Task<CategoryResponse?> GetById(int id);
    Task<IEnumerable<CategoryResponse>> GetAll();
}