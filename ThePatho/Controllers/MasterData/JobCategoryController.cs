using Microsoft.AspNetCore.Mvc;
using ThePatho.Domain.Models;
using ThePatho.Features.MasterData.JobCategory.DTO;
using ThePatho.Features.MasterData.JobCategory.Service;


namespace ThePatho.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class JobCategoryController : ControllerBase
    {
        private readonly IJobCategoryService _JobCategoryService;

        public JobCategoryController(IJobCategoryService JobCategoryService)
        {
            _JobCategoryService = JobCategoryService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var categories = await _JobCategoryService.GetAllJobCategoriesAsync();
            return Ok(categories);
        }

        [HttpGet("{code}")]
        public async Task<IActionResult> GetByCode(string code)
        {
            var JobCategory = await _JobCategoryService.GetJobCategoryByCodeAsync(code);
            if (JobCategory == null) return NotFound();
            return Ok(JobCategory);
        }

        [HttpPost]
        public async Task<IActionResult> Create(JobCategoryDto JobCategory)
        {
            var createdJobCategory = await _JobCategoryService.AddJobCategoryAsync(JobCategory);
            return CreatedAtAction(nameof(GetByCode), new { code = createdJobCategory.JobCategoryCode }, createdJobCategory);
        }

        [HttpPut("{code}")]
        public async Task<IActionResult> Update(string code, JobCategoryDto JobCategory)
        {
            if (code != JobCategory.JobCategoryCode) return BadRequest();

            var updatedJobCategory = await _JobCategoryService.UpdateJobCategoryAsync(JobCategory);
            if (updatedJobCategory == null) return NotFound();

            return Ok(updatedJobCategory);
        }

        [HttpDelete("{code}")]
        public async Task<IActionResult> Delete(string code)
        {
            var success = await _JobCategoryService.DeleteJobCategoryAsync(code);
            if (!success) return NotFound();

            return NoContent();
        }
    }
}
