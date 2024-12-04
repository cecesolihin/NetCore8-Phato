using Microsoft.AspNetCore.Mvc;
using ThePatho.Domain.Models;
using ThePatho.Features.MasterSetting.OnlineTestSetting.DTO;
using ThePatho.Features.MasterSetting.OnlineTestSetting.Service;

namespace ThePatho.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OnlineTestSettingController : ControllerBase
    {
        private readonly IOnlineTestSettingService _OnlineTestSettingService;

        public OnlineTestSettingController(IOnlineTestSettingService OnlineTestSettingService)
        {
            _OnlineTestSettingService = OnlineTestSettingService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var categories = await _OnlineTestSettingService.GetAllOnlineTestSettingAsync();
            return Ok(categories);
        }

        [HttpGet("{code}")]
        public async Task<IActionResult> GetByCode(string code)
        {
            var OnlineTestSetting = await _OnlineTestSettingService.GetOnlineTestSettingByCodeAsync(code);
            if (OnlineTestSetting == null) return NotFound();
            return Ok(OnlineTestSetting);
        }

        [HttpPost]
        public async Task<IActionResult> Create(OnlineTestSettingDto OnlineTestSetting)
        {
            var createdOnlineTestSetting = await _OnlineTestSettingService.AddOnlineTestSettingAsync(OnlineTestSetting);
            return CreatedAtAction(nameof(GetByCode), new { code = createdOnlineTestSetting.OnlineTestCode }, createdOnlineTestSetting);
        }

        [HttpPut("{code}")]
        public async Task<IActionResult> Update(string code, OnlineTestSettingDto OnlineTestSetting)
        {
            if (code != OnlineTestSetting.OnlineTestCode) return BadRequest();

            var updatedOnlineTestSetting = await _OnlineTestSettingService.UpdateOnlineTestSettingAsync(OnlineTestSetting);
            if (updatedOnlineTestSetting == null) return NotFound();

            return Ok(updatedOnlineTestSetting);
        }

        [HttpDelete("{code}")]
        public async Task<IActionResult> Delete(string code)
        {
            var success = await _OnlineTestSettingService.DeleteOnlineTestSettingAsync(code);
            if (!success) return NotFound();

            return NoContent();
        }
    }
}
