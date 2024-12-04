using Microsoft.AspNetCore.Mvc;
using ThePatho.Domain.Models;
using ThePatho.Features.MasterData.AdsMedia.DTO;
using ThePatho.Features.MasterData.AdsMedia.Service;


namespace ThePatho.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AdsMediaController : ControllerBase
    {
        private readonly IAdsMediaService _AdsMediaService;

        public AdsMediaController(IAdsMediaService AdsMediaService)
        {
            _AdsMediaService = AdsMediaService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var categories = await _AdsMediaService.GetAllAdsMediaAsync();
            return Ok(categories);
        }

        [HttpGet("{code}")]
        public async Task<IActionResult> GetByCode(string code)
        {
            var AdsMedia = await _AdsMediaService.GetAdsMediaByCodeAsync(code);
            if (AdsMedia == null) return NotFound();
            return Ok(AdsMedia);
        }

        [HttpPost]
        public async Task<IActionResult> Create(AdsMediaDto AdsMedia)
        {
            var createdAdsMedia = await _AdsMediaService.AddAdsMediaAsync(AdsMedia);
            return CreatedAtAction(nameof(GetByCode), new { code = createdAdsMedia.AdsCode }, createdAdsMedia);
        }

        [HttpPut("{code}")]
        public async Task<IActionResult> Update(string code, AdsMediaDto AdsMedia)
        {
            if (code != AdsMedia.AdsCode) return BadRequest();

            var updatedAdsMedia = await _AdsMediaService.UpdateAdsMediaAsync(AdsMedia);
            if (updatedAdsMedia == null) return NotFound();

            return Ok(updatedAdsMedia);
        }

        [HttpDelete("{code}")]
        public async Task<IActionResult> Delete(string code)
        {
            var success = await _AdsMediaService.DeleteAdsMediaAsync(code);
            if (!success) return NotFound();

            return NoContent();
        }
    }
}
