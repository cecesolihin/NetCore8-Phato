using Microsoft.AspNetCore.Mvc;
using ThePatho.Domain.Models;
using ThePatho.Features.MasterSetting.ScoringSettingDetail.DTO;
using ThePatho.Features.MasterSetting.ScoringSettingDetail.Service;

namespace ThePatho.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ScoringSettingDetailController : ControllerBase
    {
        private readonly IScoringSettingDetailService _ScoringSettingDetailService;

        public ScoringSettingDetailController(IScoringSettingDetailService ScoringSettingDetailService)
        {
            _ScoringSettingDetailService = ScoringSettingDetailService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var categories = await _ScoringSettingDetailService.GetAllScoringSettingDetailAsync();
            return Ok(categories);
        }

        [HttpGet("{code}")]
        public async Task<IActionResult> GetByCode(string code)
        {
            var ScoringSettingDetail = await _ScoringSettingDetailService.GetScoringSettingDetailByCodeAsync(code);
            if (ScoringSettingDetail == null) return NotFound();
            return Ok(ScoringSettingDetail);
        }

        [HttpPost]
        public async Task<IActionResult> Create(ScoringSettingDetailDto ScoringSettingDetail)
        {
            var createdScoringSettingDetail = await _ScoringSettingDetailService.AddScoringSettingDetailAsync(ScoringSettingDetail);
            return CreatedAtAction(nameof(GetByCode), new { code = createdScoringSettingDetail.ScoringCode }, createdScoringSettingDetail);
        }

        [HttpPut("{code}")]
        public async Task<IActionResult> Update(string code, ScoringSettingDetailDto ScoringSettingDetail)
        {
            if (code != ScoringSettingDetail.ScoringCode) return BadRequest();

            var updatedScoringSettingDetail = await _ScoringSettingDetailService.UpdateScoringSettingDetailAsync(ScoringSettingDetail);
            if (updatedScoringSettingDetail == null) return NotFound();

            return Ok(updatedScoringSettingDetail);
        }

        [HttpDelete("{code}")]
        public async Task<IActionResult> Delete(string code)
        {
            var success = await _ScoringSettingDetailService.DeleteScoringSettingDetailAsync(code);
            if (!success) return NotFound();

            return NoContent();
        }
    }
}
