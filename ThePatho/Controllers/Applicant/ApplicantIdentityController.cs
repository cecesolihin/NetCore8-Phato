using Microsoft.AspNetCore.Mvc;
using ThePatho.Domain.Models;
using ThePatho.Features.Applicant.ApplicantIdentity.DTO;
using ThePatho.Features.Applicant.ApplicantIdentity.Service;

namespace ThePatho.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ApplicantIdentityController : ControllerBase
    {
        private readonly IApplicantIdentityService _applicantIdentityService;

        public ApplicantIdentityController(IApplicantIdentityService applicantIdentityService)
        {
            _applicantIdentityService = applicantIdentityService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var categories = await _applicantIdentityService.GetAllApplicantIdentitiesAsync();
            return Ok(categories);
        }

        [HttpGet("{code}")]
        public async Task<IActionResult> GetByCode(string code)
        {
            var ApplicantIdentity = await _applicantIdentityService.GetApplicantIdentityByCodeAsync(code);
            if (ApplicantIdentity == null) return NotFound();
            return Ok(ApplicantIdentity);
        }

        [HttpPost]
        public async Task<IActionResult> Create(ApplicantIdentityDto ApplicantIdentity)
        {
            var createdApplicantIdentity = await _applicantIdentityService.AddApplicantIdentityAsync(ApplicantIdentity);
            return CreatedAtAction(nameof(GetByCode), new { code = createdApplicantIdentity.ApplicantNo }, createdApplicantIdentity);
        }

        [HttpPut("{code}")]
        public async Task<IActionResult> Update(string code, ApplicantIdentityDto applicantIdentity)
        {
            if (code != applicantIdentity.ApplicantNo) return BadRequest();

            var updatedApplicantIdentity = await _applicantIdentityService.UpdateApplicantIdentityAsync(applicantIdentity);
            if (updatedApplicantIdentity == null) return NotFound();

            return Ok(updatedApplicantIdentity);
        }

        [HttpDelete("{code}")]
        public async Task<IActionResult> Delete(string code)
        {
            var success = await _applicantIdentityService.DeleteApplicantIdentityAsync(code);
            if (!success) return NotFound();

            return NoContent();
        }
    }
}
