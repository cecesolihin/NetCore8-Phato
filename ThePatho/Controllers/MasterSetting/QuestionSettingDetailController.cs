using Microsoft.AspNetCore.Mvc;
using ThePatho.Domain.Models;
using ThePatho.Features.MasterSetting.QuestionSettingDetail.DTO;
using ThePatho.Features.MasterSetting.QuestionSettingDetail.Service;

namespace ThePatho.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class QuestionSettingDetailController : ControllerBase
    {
        private readonly IQuestionSettingDetailService _QuestionSettingDetailService;

        public QuestionSettingDetailController(IQuestionSettingDetailService QuestionSettingDetailService)
        {
            _QuestionSettingDetailService = QuestionSettingDetailService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var categories = await _QuestionSettingDetailService.GetAllQuestionSettingDetailAsync();
            return Ok(categories);
        }

        [HttpGet("{code}")]
        public async Task<IActionResult> GetByCode(string code)
        {
            var QuestionSettingDetail = await _QuestionSettingDetailService.GetQuestionSettingDetailByCodeAsync(code);
            if (QuestionSettingDetail == null) return NotFound();
            return Ok(QuestionSettingDetail);
        }

        [HttpPost]
        public async Task<IActionResult> Create(QuestionSettingDetailDto QuestionSettingDetail)
        {
            var createdQuestionSettingDetail = await _QuestionSettingDetailService.AddQuestionSettingDetailAsync(QuestionSettingDetail);
            return CreatedAtAction(nameof(GetByCode), new { code = createdQuestionSettingDetail.QuestionnaireCode }, createdQuestionSettingDetail);
        }

        [HttpPut("{code}")]
        public async Task<IActionResult> Update(string code, QuestionSettingDetailDto QuestionSettingDetail)
        {
            if (code != QuestionSettingDetail.QuestionnaireCode) return BadRequest();

            var updatedQuestionSettingDetail = await _QuestionSettingDetailService.UpdateQuestionSettingDetailAsync(QuestionSettingDetail);
            if (updatedQuestionSettingDetail == null) return NotFound();

            return Ok(updatedQuestionSettingDetail);
        }

        [HttpDelete("{code}")]
        public async Task<IActionResult> Delete(string code)
        {
            var success = await _QuestionSettingDetailService.DeleteQuestionSettingDetailAsync(code);
            if (!success) return NotFound();

            return NoContent();
        }
    }
}
