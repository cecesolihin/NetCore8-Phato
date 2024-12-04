using Microsoft.AspNetCore.Mvc;
using ThePatho.Domain.Models;
using ThePatho.Features.Category.DTO;
using ThePatho.Features.Category.Service;

namespace ThePatho.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var categories = await _categoryService.GetAllCategoriesAsync();
            return Ok(categories);
        }

        [HttpGet("{code}")]
        public async Task<IActionResult> GetByCode(string code)
        {
            var category = await _categoryService.GetCategoryByCodeAsync(code);
            if (category == null) return NotFound();
            return Ok(category);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CategoryDto category)
        {
            var createdCategory = await _categoryService.AddCategoryAsync(category);
            return CreatedAtAction(nameof(GetByCode), new { code = createdCategory.TrainingCategoryCode }, createdCategory);
        }

        [HttpPut("{code}")]
        public async Task<IActionResult> Update(string code, CategoryDto category)
        {
            if (code != category.TrainingCategoryCode) return BadRequest();

            var updatedCategory = await _categoryService.UpdateCategoryAsync(category);
            if (updatedCategory == null) return NotFound();

            return Ok(updatedCategory);
        }

        [HttpDelete("{code}")]
        public async Task<IActionResult> Delete(string code)
        {
            var success = await _categoryService.DeleteCategoryAsync(code);
            if (!success) return NotFound();

            return NoContent();
        }
    }
}
