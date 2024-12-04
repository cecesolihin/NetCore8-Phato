using Microsoft.AspNetCore.Mvc;
using ThePatho.Domain.Models;
using ThePatho.Features.MasterSetting.ScoringSetting.DTO;
using ThePatho.Features.MasterSetting.ScoringSetting.Service;

namespace ThePatho.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ScoringSettingController : ControllerBase
    {
        private readonly IScoringSettingService _ScoringSettingService;

        public ScoringSettingController(IScoringSettingService ScoringSettingService)
        {
            _ScoringSettingService = ScoringSettingService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var categories = await _ScoringSettingService.GetAllScoringSettingAsync();
            return Ok(categories);
        }

        [HttpGet("{code}")]
        public async Task<IActionResult> GetByCode(string code)
        {
            var ScoringSetting = await _ScoringSettingService.GetScoringSettingByCodeAsync(code);
            if (ScoringSetting == null) return NotFound();
            return Ok(ScoringSetting);
        }

        [HttpPost]
        public async Task<IActionResult> Create(ScoringSettingDto ScoringSetting)
        {
            var createdScoringSetting = await _ScoringSettingService.AddScoringSettingAsync(ScoringSetting);
            return CreatedAtAction(nameof(GetByCode), new { code = createdScoringSetting.ScoringCode }, createdScoringSetting);
        }

        [HttpPut("{code}")]
        public async Task<IActionResult> Update(string code, ScoringSettingDto ScoringSetting)
        {
            if (code != ScoringSetting.ScoringCode) return BadRequest();

            var updatedScoringSetting = await _ScoringSettingService.UpdateScoringSettingAsync(ScoringSetting);
            if (updatedScoringSetting == null) return NotFound();

            return Ok(updatedScoringSetting);
        }

        [HttpDelete("{code}")]
        public async Task<IActionResult> Delete(string code)
        {
            var success = await _ScoringSettingService.DeleteScoringSettingAsync(code);
            if (!success) return NotFound();

            return NoContent();
        }
    }
}
