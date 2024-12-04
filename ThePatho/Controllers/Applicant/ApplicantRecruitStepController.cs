using Microsoft.AspNetCore.Mvc;
using ThePatho.Domain.Models;
using ThePatho.Features.Applicant.ApplicantRecruitStep.DTO;
using ThePatho.Features.Applicant.ApplicantRecruitStep.Service;

namespace ThePatho.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ApplicantRecruitStepController : ControllerBase
    {
        private readonly IApplicantRecruitStepService _applicantRecruitStepService;

        public ApplicantRecruitStepController(IApplicantRecruitStepService applicantRecruitStepService)
        {
            _applicantRecruitStepService = applicantRecruitStepService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var categories = await _applicantRecruitStepService.GetAllApplicantRecruitStepAsync();
            return Ok(categories);
        }

        [HttpGet("{code}")]
        public async Task<IActionResult> GetByCode(string code)
        {
            var ApplicantRecruitStep = await _applicantRecruitStepService.GetApplicantRecruitStepByCodeAsync(code);
            if (ApplicantRecruitStep == null) return NotFound();
            return Ok(ApplicantRecruitStep);
        }

        [HttpPost]
        public async Task<IActionResult> Create(ApplicantRecruitStepDto applicantRecruitStep)
        {
            var createdApplicantRecruitStep = await _applicantRecruitStepService.AddApplicantRecruitStepAsync(applicantRecruitStep);
            return CreatedAtAction(nameof(GetByCode), new { code = createdApplicantRecruitStep.AppRecStepId.ToString() }, createdApplicantRecruitStep);
        }

        [HttpPut("{code}")]
        public async Task<IActionResult> Update(string code, ApplicantRecruitStepDto applicantRecruitStep)
        {
            if (code != applicantRecruitStep.AppRecStepId.ToString()) return BadRequest();

            var updatedApplicantRecruitStep = await _applicantRecruitStepService.UpdateApplicantRecruitStepAsync(applicantRecruitStep);
            if (updatedApplicantRecruitStep == null) return NotFound();

            return Ok(updatedApplicantRecruitStep);
        }

        [HttpDelete("{code}")]
        public async Task<IActionResult> Delete(string code)
        {
            var success = await _applicantRecruitStepService.DeleteApplicantRecruitStepAsync(code);
            if (!success) return NotFound();

            return NoContent();
        }
    }
}
