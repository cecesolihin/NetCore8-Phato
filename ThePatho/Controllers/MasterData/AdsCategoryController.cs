using Microsoft.AspNetCore.Mvc;
using ThePatho.Domain.Models;
using ThePatho.Features.MasterData.AdsCategory.DTO;
using ThePatho.Features.MasterData.AdsCategory.Service;


namespace ThePatho.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AdsCategoryController : ControllerBase
    {
        private readonly IAdsCategoryService _AdsCategoryService;

        public AdsCategoryController(IAdsCategoryService AdsCategoryService)
        {
            _AdsCategoryService = AdsCategoryService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var categories = await _AdsCategoryService.GetAllAdsCategoriesAsync();
            return Ok(categories);
        }

        [HttpGet("{code}")]
        public async Task<IActionResult> GetByCode(string code)
        {
            var AdsCategory = await _AdsCategoryService.GetAdsCategoryByCodeAsync(code);
            if (AdsCategory == null) return NotFound();
            return Ok(AdsCategory);
        }

        [HttpPost]
        public async Task<IActionResult> Create(AdsCategoryDto AdsCategory)
        {
            var createdAdsCategory = await _AdsCategoryService.AddAdsCategoryAsync(AdsCategory);
            return CreatedAtAction(nameof(GetByCode), new { code = createdAdsCategory.AdsCategoryCode }, createdAdsCategory);
        }

        [HttpPut("{code}")]
        public async Task<IActionResult> Update(string code, AdsCategoryDto AdsCategory)
        {
            if (code != AdsCategory.AdsCategoryCode) return BadRequest();

            var updatedAdsCategory = await _AdsCategoryService.UpdateAdsCategoryAsync(AdsCategory);
            if (updatedAdsCategory == null) return NotFound();

            return Ok(updatedAdsCategory);
        }

        [HttpDelete("{code}")]
        public async Task<IActionResult> Delete(string code)
        {
            var success = await _AdsCategoryService.DeleteAdsCategoryAsync(code);
            if (!success) return NotFound();

            return NoContent();
        }
    }
}
