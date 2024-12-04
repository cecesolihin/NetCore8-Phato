using Microsoft.AspNetCore.Mvc;
using ThePatho.Domain.Models;
using ThePatho.Features.Applicant.ApplicantSkill.DTO;
using ThePatho.Features.Applicant.ApplicantSkill.Service;

namespace ThePatho.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ApplicantSkillController : ControllerBase
    {
        private readonly IApplicantSkillService _applicantSkillService;

        public ApplicantSkillController(IApplicantSkillService applicantSkillService)
        {
            _applicantSkillService = applicantSkillService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var categories = await _applicantSkillService.GetAllApplicantSkillAsync();
            return Ok(categories);
        }

        [HttpGet("{code}")]
        public async Task<IActionResult> GetByCode(string code)
        {
            var ApplicantSkill = await _applicantSkillService.GetApplicantSkillByCodeAsync(code);
            if (ApplicantSkill == null) return NotFound();
            return Ok(ApplicantSkill);
        }

        [HttpPost]
        public async Task<IActionResult> Create(ApplicantSkillDto ApplicantSkill)
        {
            var createdApplicantSkill = await _applicantSkillService.AddApplicantSkillAsync(ApplicantSkill);
            return CreatedAtAction(nameof(GetByCode), new { code = createdApplicantSkill.ApplicantNo }, createdApplicantSkill);
        }

        [HttpPut("{code}")]
        public async Task<IActionResult> Update(string code, ApplicantSkillDto applicantSkill)
        {
            if (code != applicantSkill.ApplicantNo) return BadRequest();

            var updatedApplicantSkill = await _applicantSkillService.UpdateApplicantSkillAsync(applicantSkill);
            if (updatedApplicantSkill == null) return NotFound();

            return Ok(updatedApplicantSkill);
        }

        [HttpDelete("{code}")]
        public async Task<IActionResult> Delete(string code)
        {
            var success = await _applicantSkillService.DeleteApplicantSkillAsync(code);
            if (!success) return NotFound();

            return NoContent();
        }
    }
}
