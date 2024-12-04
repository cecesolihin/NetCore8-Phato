using Microsoft.AspNetCore.Mvc;
using ThePatho.Domain.Models;
using ThePatho.Features.Applicant.ApplicantPersonalData.DTO;
using ThePatho.Features.Applicant.ApplicantPersonalData.Service;

namespace ThePatho.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ApplicantPersonalDataController : ControllerBase
    {
        private readonly IApplicantPersonalDataService _applicantPersonalDataService;

        public ApplicantPersonalDataController(IApplicantPersonalDataService applicantPersonalDataService)
        {
            _applicantPersonalDataService = applicantPersonalDataService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var categories = await _applicantPersonalDataService.GetAllApplicantPersonalDataAsync();
            return Ok(categories);
        }

        [HttpGet("{code}")]
        public async Task<IActionResult> GetByCode(string code)
        {
            var ApplicantPersonalData = await _applicantPersonalDataService.GetApplicantPersonalDataByCodeAsync(code);
            if (ApplicantPersonalData == null) return NotFound();
            return Ok(ApplicantPersonalData);
        }

        [HttpPost]
        public async Task<IActionResult> Create(ApplicantPersonalDataDto ApplicantPersonalData)
        {
            var createdApplicantPersonalData = await _applicantPersonalDataService.AddApplicantPersonalDataAsync(ApplicantPersonalData);
            return CreatedAtAction(nameof(GetByCode), new { code = createdApplicantPersonalData.ApplicantNo }, createdApplicantPersonalData);
        }

        [HttpPut("{code}")]
        public async Task<IActionResult> Update(string code, ApplicantPersonalDataDto applicantPersonalData)
        {
            if (code != applicantPersonalData.ApplicantNo) return BadRequest();

            var updatedApplicantPersonalData = await _applicantPersonalDataService.UpdateApplicantPersonalDataAsync(applicantPersonalData);
            if (updatedApplicantPersonalData == null) return NotFound();

            return Ok(updatedApplicantPersonalData);
        }

        [HttpDelete("{code}")]
        public async Task<IActionResult> Delete(string code)
        {
            var success = await _applicantPersonalDataService.DeleteApplicantPersonalDataAsync(code);
            if (!success) return NotFound();

            return NoContent();
        }
    }
}
