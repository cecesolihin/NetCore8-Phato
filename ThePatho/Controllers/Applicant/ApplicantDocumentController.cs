using Microsoft.AspNetCore.Mvc;
using ThePatho.Domain.Models;
using ThePatho.Features.Applicant.ApplicantDocument.DTO;
using ThePatho.Features.Applicant.ApplicantDocument.Service;

namespace ThePatho.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ApplicantDocumentController : ControllerBase
    {
        private readonly IApplicantDocumentService _applicantDocumentService;

        public ApplicantDocumentController(IApplicantDocumentService applicantDocumentService)
        {
            _applicantDocumentService = applicantDocumentService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var categories = await _applicantDocumentService.GetAllApplicantDocumentAsync();
            return Ok(categories);
        }

        [HttpGet("{code}")]
        public async Task<IActionResult> GetByCode(string code)
        {
            var ApplicantDocument = await _applicantDocumentService.GetApplicantDocumentByCodeAsync(code);
            if (ApplicantDocument == null) return NotFound();
            return Ok(ApplicantDocument);
        }

        [HttpPost]
        public async Task<IActionResult> Create(ApplicantDocumentDto ApplicantDocument)
        {
            var createdApplicantDocument = await _applicantDocumentService.AddApplicantDocumentAsync(ApplicantDocument);
            return CreatedAtAction(nameof(GetByCode), new { code = createdApplicantDocument.ApplicantNo }, createdApplicantDocument);
        }

        [HttpPut("{code}")]
        public async Task<IActionResult> Update(string code, ApplicantDocumentDto applicantDocument)
        {
            if (code != applicantDocument.ApplicantNo) return BadRequest();

            var updatedApplicantDocument = await _applicantDocumentService.UpdateApplicantDocumentAsync(applicantDocument);
            if (updatedApplicantDocument == null) return NotFound();

            return Ok(updatedApplicantDocument);
        }

        [HttpDelete("{code}")]
        public async Task<IActionResult> Delete(string code)
        {
            var success = await _applicantDocumentService.DeleteApplicantDocumentAsync(code);
            if (!success) return NotFound();

            return NoContent();
        }
    }
}
