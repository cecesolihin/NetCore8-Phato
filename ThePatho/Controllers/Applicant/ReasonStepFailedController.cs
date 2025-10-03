using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using ThePatho.Domain.Models;
using ThePatho.Features.Applicant.ReasonStepFailed.DTO;
using ThePatho.Features.Applicant.ReasonStepFailed.Service;

namespace ThePatho.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [ApiExplorerSettings(GroupName = "Applicant")]
    [Authorize]
    public class ReasonStepFailedController : ControllerBase
    {
        private readonly IReasonStepFailedService _ReasonStepFailedService; 

        public ReasonStepFailedController(IReasonStepFailedService ReasonStepFailedService)
        {
            _ReasonStepFailedService = ReasonStepFailedService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var categories = await _ReasonStepFailedService.GetAllReasonStepFailedAsync();
            return Ok(categories);
        }

        [HttpGet("{code}")]
        public async Task<IActionResult> GetByCriteria(string code)
        {
            var ReasonStepFailed = await _ReasonStepFailedService.GetReasonStepFailedByCriteriaAsync(code);
            if (ReasonStepFailed == null) return NotFound();
            return Ok(ReasonStepFailed);
        }

        [HttpPost]
        public async Task<IActionResult> Create(ReasonStepFailedDto ReasonStepFailed)
        {
            var createdReasonStepFailed = await _ReasonStepFailedService.AddReasonStepFailedAsync(ReasonStepFailed);
            return CreatedAtAction(nameof(GetByCriteria), new { code = createdReasonStepFailed.RecruitStepCode }, createdReasonStepFailed);
        }

        [HttpPut("{code}")]
        public async Task<IActionResult> Update(string code, ReasonStepFailedDto ReasonStepFailed)
        {
            if (code != ReasonStepFailed.RecruitStepCode) return BadRequest();

            var updatedReasonStepFailed = await _ReasonStepFailedService.UpdateReasonStepFailedAsync(ReasonStepFailed);
            if (updatedReasonStepFailed == null) return NotFound();

            return Ok(updatedReasonStepFailed);
        }

        [HttpDelete("{code}")]
        public async Task<IActionResult> Delete(string code)
        {
            var success = await _ReasonStepFailedService.DeleteReasonStepFailedAsync(code);
            if (!success) return NotFound();

            return NoContent();
        }
    }
}
