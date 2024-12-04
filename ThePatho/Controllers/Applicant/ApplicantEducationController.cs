using Microsoft.AspNetCore.Mvc;
using ThePatho.Domain.Models;
using ThePatho.Features.Applicant.ApplicantEducation.DTO;
using ThePatho.Features.Applicant.ApplicantEducation.Service;

namespace ThePatho.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ApplicantEducationController : ControllerBase
    {
        private readonly IApplicantEducationService _applicantEducationService;

        public ApplicantEducationController(IApplicantEducationService applicantEducationService)
        {
            _applicantEducationService = applicantEducationService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var categories = await _applicantEducationService.GetAllApplicantEducationsAsync();
            return Ok(categories);
        }

        [HttpGet("{code}")]
        public async Task<IActionResult> GetByCode(string code)
        {
            var ApplicantEducation = await _applicantEducationService.GetApplicantEducationByCodeAsync(code);
            if (ApplicantEducation == null) return NotFound();
            return Ok(ApplicantEducation);
        }

        [HttpPost]
        public async Task<IActionResult> Create(ApplicantEducationDto ApplicantEducation)
        {
            var createdApplicantEducation = await _applicantEducationService.AddApplicantEducationAsync(ApplicantEducation);
            return CreatedAtAction(nameof(GetByCode), new { code = createdApplicantEducation.ApplicantNo }, createdApplicantEducation);
        }

        [HttpPut("{code}")]
        public async Task<IActionResult> Update(string code, ApplicantEducationDto applicantEducation)
        {
            if (code != applicantEducation.ApplicantNo) return BadRequest();

            var updatedApplicantEducation = await _applicantEducationService.UpdateApplicantEducationAsync(applicantEducation);
            if (updatedApplicantEducation == null) return NotFound();

            return Ok(updatedApplicantEducation);
        }

        [HttpDelete("{code}")]
        public async Task<IActionResult> Delete(string code)
        {
            var success = await _applicantEducationService.DeleteApplicantEducationAsync(code);
            if (!success) return NotFound();

            return NoContent();
        }
    }
}
