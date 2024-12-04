using Microsoft.AspNetCore.Mvc;
using ThePatho.Features.Recruitment.RecruitmentReqStep.DTO;
using ThePatho.Features.Recruitment.RecruitmentReqStep.Service;

namespace ThePatho.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RecruitmentReqStepController : ControllerBase
    {
        private readonly IRecruitmentReqStepService _RecruitmentReqStepService;

        public RecruitmentReqStepController(IRecruitmentReqStepService RecruitmentReqStepService)
        {
            _RecruitmentReqStepService = RecruitmentReqStepService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var categories = await _RecruitmentReqStepService.GetAllRecruitmentReqStepAsync();
            return Ok(categories);
        }

        [HttpGet("{code}")]
        public async Task<IActionResult> GetByCode(string code)
        {
            var RecruitmentReqStep = await _RecruitmentReqStepService.GetRecruitmentReqStepByCodeAsync(code);
            if (RecruitmentReqStep == null) return NotFound();
            return Ok(RecruitmentReqStep);
        }

        [HttpPost]
        public async Task<IActionResult> Create(RecruitmentReqStepDto RecruitmentReqStep)
        {
            var createdRecruitmentReqStep = await _RecruitmentReqStepService.AddRecruitmentReqStepAsync(RecruitmentReqStep);
            return CreatedAtAction(nameof(GetByCode), new { code = createdRecruitmentReqStep.RecruitStepCode }, createdRecruitmentReqStep);
        }

        [HttpPut("{code}")]
        public async Task<IActionResult> Update(string code, RecruitmentReqStepDto RecruitmentReqStep)
        {
            if (code != RecruitmentReqStep.RecruitStepCode) return BadRequest();

            var updatedRecruitmentReqStep = await _RecruitmentReqStepService.UpdateRecruitmentReqStepAsync(RecruitmentReqStep);
            if (updatedRecruitmentReqStep == null) return NotFound();

            return Ok(updatedRecruitmentReqStep);
        }

        [HttpDelete("{code}")]
        public async Task<IActionResult> Delete(string code)
        {
            var success = await _RecruitmentReqStepService.DeleteRecruitmentReqStepAsync(code);
            if (!success) return NotFound();

            return NoContent();
        }
    }
}
