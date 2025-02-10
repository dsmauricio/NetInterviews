using Microsoft.AspNetCore.Mvc;
using NetInterviews.Business.Services;
using NetInterviews.Core.DTO;

namespace NetInterviews.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CategoryController : ControllerBase
    {
        private readonly ILogger<CategoryController> _logger;
        private readonly ICategoryService _categoryService;

        public CategoryController(ILogger<CategoryController> logger, ICategoryService categoryService)
        {
            _logger = logger;
            _categoryService = categoryService;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var category = await _categoryService.GetById(id);
            if (category is null)
            {
                return NotFound($"Category : {id}");
            }

            return Ok(category);
        }

        [HttpGet()]
        public async Task<IActionResult> List()
        {
            var category = await _categoryService.GetAll();
            return Ok(category);
        }

        [HttpPost()]
        public async Task<IActionResult> Post(CategoryRequest category)
        {
            var categoryResponse = await _categoryService.Add(category);
            _logger.LogDebug($"Category Created {categoryResponse.Id}.");
            return Created($"/{categoryResponse.Id}", categoryResponse);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, CategoryRequest category)
        {
            var categoryResponse = await _categoryService.Update(id, category);
            if (categoryResponse is null)
            {
                return NotFound($"Category {id}");
            }
            _logger.LogDebug($"Category Updated {id}.");
            return Ok(categoryResponse);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _categoryService.Delete(id);
            _logger.LogDebug($"Category Deleted {id}.");
            return Ok();
        }

    }
}
