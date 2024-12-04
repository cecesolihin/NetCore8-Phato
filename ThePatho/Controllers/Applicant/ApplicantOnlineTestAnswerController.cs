using Microsoft.AspNetCore.Mvc;
using ThePatho.Domain.Models;
using ThePatho.Features.Applicant.ApplicantOnlineTestAnswer.DTO;
using ThePatho.Features.Applicant.ApplicantOnlineTestAnswer.Service;

namespace ThePatho.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ApplicantOnlineTestAnswerController : ControllerBase
    {
        private readonly IApplicantOnlineTestAnswerService _applicantOnlineTestAnswerService;

        public ApplicantOnlineTestAnswerController(IApplicantOnlineTestAnswerService applicantOnlineTestAnswerService)
        {
            _applicantOnlineTestAnswerService = applicantOnlineTestAnswerService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var categories = await _applicantOnlineTestAnswerService.GetAllApplicantOnlineTestAnswersAsync();
            return Ok(categories);
        }

        [HttpGet("{code}")]
        public async Task<IActionResult> GetByCode(string code)
        {
            var ApplicantOnlineTestAnswer = await _applicantOnlineTestAnswerService.GetApplicantOnlineTestAnswerByCodeAsync(code);
            if (ApplicantOnlineTestAnswer == null) return NotFound();
            return Ok(ApplicantOnlineTestAnswer);
        }

        [HttpPost]
        public async Task<IActionResult> Create(ApplicantOnlineTestAnswerDto ApplicantOnlineTestAnswer)
        {
            var createdApplicantOnlineTestAnswer = await _applicantOnlineTestAnswerService.AddApplicantOnlineTestAnswerAsync(ApplicantOnlineTestAnswer);
            return CreatedAtAction(nameof(GetByCode), new { code = createdApplicantOnlineTestAnswer.AppAnswerId }, createdApplicantOnlineTestAnswer);
        }

        [HttpPut("{code}")]
        public async Task<IActionResult> Update(int code, ApplicantOnlineTestAnswerDto applicantOnlineTestAnswer)
        {
            if (code != applicantOnlineTestAnswer.AppAnswerId) return BadRequest();

            var updatedApplicantOnlineTestAnswer = await _applicantOnlineTestAnswerService.UpdateApplicantOnlineTestAnswerAsync(applicantOnlineTestAnswer);
            if (updatedApplicantOnlineTestAnswer == null) return NotFound();

            return Ok(updatedApplicantOnlineTestAnswer);
        }

        [HttpDelete("{code}")]
        public async Task<IActionResult> Delete(string code)
        {
            var success = await _applicantOnlineTestAnswerService.DeleteApplicantOnlineTestAnswerAsync(code);
            if (!success) return NotFound();

            return NoContent();
        }
    }
}
