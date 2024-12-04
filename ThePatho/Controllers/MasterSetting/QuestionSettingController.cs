using Microsoft.AspNetCore.Mvc;
using ThePatho.Domain.Models;
using ThePatho.Features.MasterSetting.QuestionSetting.DTO;
using ThePatho.Features.MasterSetting.QuestionSetting.Service;

namespace ThePatho.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class QuestionSettingController : ControllerBase
    {
        private readonly IQuestionSettingService _QuestionSettingService;

        public QuestionSettingController(IQuestionSettingService QuestionSettingService)
        {
            _QuestionSettingService = QuestionSettingService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var categories = await _QuestionSettingService.GetAllQuestionSettingAsync();
            return Ok(categories);
        }

        [HttpGet("{code}")]
        public async Task<IActionResult> GetByCode(string code)
        {
            var QuestionSetting = await _QuestionSettingService.GetQuestionSettingByCodeAsync(code);
            if (QuestionSetting == null) return NotFound();
            return Ok(QuestionSetting);
        }

        [HttpPost]
        public async Task<IActionResult> Create(QuestionSettingDto QuestionSetting)
        {
            var createdQuestionSetting = await _QuestionSettingService.AddQuestionSettingAsync(QuestionSetting);
            return CreatedAtAction(nameof(GetByCode), new { code = createdQuestionSetting.QuestionnaireCode }, createdQuestionSetting);
        }

        [HttpPut("{code}")]
        public async Task<IActionResult> Update(string code, QuestionSettingDto QuestionSetting)
        {
            if (code != QuestionSetting.QuestionnaireCode) return BadRequest();

            var updatedQuestionSetting = await _QuestionSettingService.UpdateQuestionSettingAsync(QuestionSetting);
            if (updatedQuestionSetting == null) return NotFound();

            return Ok(updatedQuestionSetting);
        }

        [HttpDelete("{code}")]
        public async Task<IActionResult> Delete(string code)
        {
            var success = await _QuestionSettingService.DeleteQuestionSettingAsync(code);
            if (!success) return NotFound();

            return NoContent();
        }
    }
}
