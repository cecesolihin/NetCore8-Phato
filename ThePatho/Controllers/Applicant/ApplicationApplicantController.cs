using Microsoft.AspNetCore.Mvc;
using ThePatho.Domain.Models;
using ThePatho.Features.Applicant.ApplicationApplicant.DTO;
using ThePatho.Features.Applicant.ApplicationApplicant.Service;

namespace ThePatho.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ApplicationApplicantController : ControllerBase
    {
        private readonly IApplicationApplicantService _ApplicationApplicantService;

        public ApplicationApplicantController(IApplicationApplicantService ApplicationApplicantService)
        {
            _ApplicationApplicantService = ApplicationApplicantService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var categories = await _ApplicationApplicantService.GetAllApplicationApplicantAsync();
            return Ok(categories);
        }

        [HttpGet("{code}")]
        public async Task<IActionResult> GetByCode(string code)
        {
            var ApplicationApplicant = await _ApplicationApplicantService.GetApplicationApplicantByCodeAsync(code);
            if (ApplicationApplicant == null) return NotFound();
            return Ok(ApplicationApplicant);
        }

        [HttpPost]
        public async Task<IActionResult> Create(ApplicationApplicantDto ApplicationApplicant)
        {
            var createdApplicationApplicant = await _ApplicationApplicantService.AddApplicationApplicantAsync(ApplicationApplicant);
            return CreatedAtAction(nameof(GetByCode), new { code = createdApplicationApplicant.ApplicantNo }, createdApplicationApplicant);
        }

        [HttpPut("{code}")]
        public async Task<IActionResult> Update(string code, ApplicationApplicantDto ApplicationApplicant)
        {
            if (code != ApplicationApplicant.ApplicantNo) return BadRequest();

            var updatedApplicationApplicant = await _ApplicationApplicantService.UpdateApplicationApplicantAsync(ApplicationApplicant);
            if (updatedApplicationApplicant == null) return NotFound();

            return Ok(updatedApplicationApplicant);
        }

        [HttpDelete("{code}")]
        public async Task<IActionResult> Delete(string code)
        {
            var success = await _ApplicationApplicantService.DeleteApplicationApplicantAsync(code);
            if (!success) return NotFound();

            return NoContent();
        }
    }
}
