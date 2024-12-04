using Microsoft.AspNetCore.Mvc;
using ThePatho.Domain.Models;
using ThePatho.Features.Applicant.ApplicantOnlineTestResult.DTO;
using ThePatho.Features.Applicant.ApplicantOnlineTestResult.Service;

namespace ThePatho.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ApplicantOnlineTestResultController : ControllerBase
    {
        private readonly IApplicantOnlineTestResultService _applicantOnlineTestResultService;

        public ApplicantOnlineTestResultController(IApplicantOnlineTestResultService applicantOnlineTestResultService)
        {
            _applicantOnlineTestResultService = applicantOnlineTestResultService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var categories = await _applicantOnlineTestResultService.GetAllApplicantOnlineTestResultsAsync();
            return Ok(categories);
        }

        [HttpGet("{code}")]
        public async Task<IActionResult> GetByCode(string code)
        {
            var ApplicantOnlineTestResult = await _applicantOnlineTestResultService.GetApplicantOnlineTestResultByCodeAsync(code);
            if (ApplicantOnlineTestResult == null) return NotFound();
            return Ok(ApplicantOnlineTestResult);
        }

        [HttpPost]
        public async Task<IActionResult> Create(ApplicantOnlineTestResultDto ApplicantOnlineTestResult)
        {
            var createdApplicantOnlineTestResult = await _applicantOnlineTestResultService.AddApplicantOnlineTestResultAsync(ApplicantOnlineTestResult);
            return CreatedAtAction(nameof(GetByCode), new { code = createdApplicantOnlineTestResult.ApplicantNo }, createdApplicantOnlineTestResult);
        }

        [HttpPut("{code}")]
        public async Task<IActionResult> Update(string code, ApplicantOnlineTestResultDto applicantOnlineTestResult)
        {
            if (code != applicantOnlineTestResult.ApplicantNo) return BadRequest();

            var updatedApplicantOnlineTestResult = await _applicantOnlineTestResultService.UpdateApplicantOnlineTestResultAsync(applicantOnlineTestResult);
            if (updatedApplicantOnlineTestResult == null) return NotFound();

            return Ok(updatedApplicantOnlineTestResult);
        }

        [HttpDelete("{code}")]
        public async Task<IActionResult> Delete(string code)
        {
            var success = await _applicantOnlineTestResultService.DeleteApplicantOnlineTestResultAsync(code);
            if (!success) return NotFound();

            return NoContent();
        }
    }
}
