using Microsoft.AspNetCore.Mvc;
using ThePatho.Domain.Models;
using ThePatho.Features.Applicant.ApplicantAddress.DTO;
using ThePatho.Features.Applicant.ApplicantAddress.Service;

namespace ThePatho.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ApplicantAddressController : ControllerBase
    {
        private readonly IApplicantAddressService _applicantAddressService;

        public ApplicantAddressController(IApplicantAddressService applicantAddressService)
        {
            _applicantAddressService = applicantAddressService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var categories = await _applicantAddressService.GetAllApplicantAddressesAsync();
            return Ok(categories);
        }

        [HttpGet("{code}")]
        public async Task<IActionResult> GetByCode(string code)
        {
            var ApplicantAddress = await _applicantAddressService.GetApplicantAddressByCodeAsync(code);
            if (ApplicantAddress == null) return NotFound();
            return Ok(ApplicantAddress);
        }

        [HttpPost]
        public async Task<IActionResult> Create(ApplicantAddressDto ApplicantAddress)
        {
            var createdApplicantAddress = await _applicantAddressService.AddApplicantAddressAsync(ApplicantAddress);
            return CreatedAtAction(nameof(GetByCode), new { code = createdApplicantAddress.ApplicantNo }, createdApplicantAddress);
        }

        [HttpPut("{code}")]
        public async Task<IActionResult> Update(string code, ApplicantAddressDto applicantAddress)
        {
            if (code != applicantAddress.ApplicantNo) return BadRequest();

            var updatedApplicantAddress = await _applicantAddressService.UpdateApplicantAddressAsync(applicantAddress);
            if (updatedApplicantAddress == null) return NotFound();

            return Ok(updatedApplicantAddress);
        }

        [HttpDelete("{code}")]
        public async Task<IActionResult> Delete(string code)
        {
            var success = await _applicantAddressService.DeleteApplicantAddressAsync(code);
            if (!success) return NotFound();

            return NoContent();
        }
    }
}
