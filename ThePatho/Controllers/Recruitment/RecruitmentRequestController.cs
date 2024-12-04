using Microsoft.AspNetCore.Mvc;
using ThePatho.Features.Recruitment.RecruitmentRequest.DTO;
using ThePatho.Features.Recruitment.RecruitmentRequest.Service;

namespace ThePatho.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RecruitmentRequestController : ControllerBase
    {
        private readonly IRecruitmentRequestService _RecruitmentRequestService;

        public RecruitmentRequestController(IRecruitmentRequestService RecruitmentRequestService)
        {
            _RecruitmentRequestService = RecruitmentRequestService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var categories = await _RecruitmentRequestService.GetAllRecruitmentRequestAsync();
            return Ok(categories);
        }

        [HttpGet("{code}")]
        public async Task<IActionResult> GetByCode(string code)
        {
            var RecruitmentRequest = await _RecruitmentRequestService.GetRecruitmentRequestByCodeAsync(code);
            if (RecruitmentRequest == null) return NotFound();
            return Ok(RecruitmentRequest);
        }

        [HttpPost]
        public async Task<IActionResult> Create(RecruitmentRequestDto RecruitmentRequest)
        {
            var createdRecruitmentRequest = await _RecruitmentRequestService.AddRecruitmentRequestAsync(RecruitmentRequest);
            return CreatedAtAction(nameof(GetByCode), new { code = createdRecruitmentRequest.RecStepGroupCode }, createdRecruitmentRequest);
        }

        [HttpPut("{code}")]
        public async Task<IActionResult> Update(string code, RecruitmentRequestDto RecruitmentRequest)
        {
            if (code != RecruitmentRequest.RecStepGroupCode) return BadRequest();

            var updatedRecruitmentRequest = await _RecruitmentRequestService.UpdateRecruitmentRequestAsync(RecruitmentRequest);
            if (updatedRecruitmentRequest == null) return NotFound();

            return Ok(updatedRecruitmentRequest);
        }

        [HttpDelete("{code}")]
        public async Task<IActionResult> Delete(string code)
        {
            var success = await _RecruitmentRequestService.DeleteRecruitmentRequestAsync(code);
            if (!success) return NotFound();

            return NoContent();
        }
    }
}
