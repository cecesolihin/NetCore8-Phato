using Microsoft.AspNetCore.Mvc;
using ThePatho.Domain.Models;
using ThePatho.Features.Applicant.ApplicantWorkExperience.DTO;
using ThePatho.Features.Applicant.ApplicantWorkExperience.Service;

namespace ThePatho.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ApplicantWorkExperienceController : ControllerBase
    {
        private readonly IApplicantWorkExperienceService _applicantWorkExperienceService;

        public ApplicantWorkExperienceController(IApplicantWorkExperienceService applicantWorkExperienceService)
        {
            _applicantWorkExperienceService = applicantWorkExperienceService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var categories = await _applicantWorkExperienceService.GetAllApplicantWorkExperienceAsync();
            return Ok(categories);
        }

        [HttpGet("{code}")]
        public async Task<IActionResult> GetByCode(string code)
        {
            var ApplicantWorkExperience = await _applicantWorkExperienceService.GetApplicantWorkExperienceByCodeAsync(code);
            if (ApplicantWorkExperience == null) return NotFound();
            return Ok(ApplicantWorkExperience);
        }

        [HttpPost]
        public async Task<IActionResult> Create(ApplicantWorkExperienceDto ApplicantWorkExperience)
        {
            var createdApplicantWorkExperience = await _applicantWorkExperienceService.AddApplicantWorkExperienceAsync(ApplicantWorkExperience);
            return CreatedAtAction(nameof(GetByCode), new { code = createdApplicantWorkExperience.ApplicantNo }, createdApplicantWorkExperience);
        }

        [HttpPut("{code}")]
        public async Task<IActionResult> Update(string code, ApplicantWorkExperienceDto applicantWorkExperience)
        {
            if (code != applicantWorkExperience.ApplicantNo) return BadRequest();

            var updatedApplicantWorkExperience = await _applicantWorkExperienceService.UpdateApplicantWorkExperienceAsync(applicantWorkExperience);
            if (updatedApplicantWorkExperience == null) return NotFound();

            return Ok(updatedApplicantWorkExperience);
        }

        [HttpDelete("{code}")]
        public async Task<IActionResult> Delete(string code)
        {
            var success = await _applicantWorkExperienceService.DeleteApplicantWorkExperienceAsync(code);
            if (!success) return NotFound();

            return NoContent();
        }
    }
}
