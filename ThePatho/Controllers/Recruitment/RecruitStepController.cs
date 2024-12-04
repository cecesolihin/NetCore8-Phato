using Microsoft.AspNetCore.Mvc;
using ThePatho.Features.Recruitment.RecruitStep.DTO;
using ThePatho.Features.Recruitment.RecruitStep.Service;

namespace ThePatho.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RecruitStepController : ControllerBase
    {
        private readonly IRecruitStepService _RecruitStepService;

        public RecruitStepController(IRecruitStepService RecruitStepService)
        {
            _RecruitStepService = RecruitStepService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var categories = await _RecruitStepService.GetAllRecruitStepAsync();
            return Ok(categories);
        }

        [HttpGet("{code}")]
        public async Task<IActionResult> GetByCode(string code)
        {
            var RecruitStep = await _RecruitStepService.GetRecruitStepByCodeAsync(code);
            if (RecruitStep == null) return NotFound();
            return Ok(RecruitStep);
        }

        [HttpPost]
        public async Task<IActionResult> Create(RecruitStepDto RecruitStep)
        {
            var createdRecruitStep = await _RecruitStepService.AddRecruitStepAsync(RecruitStep);
            return CreatedAtAction(nameof(GetByCode), new { code = createdRecruitStep.RecruitStepCode }, createdRecruitStep);
        }

        [HttpPut("{code}")]
        public async Task<IActionResult> Update(string code, RecruitStepDto RecruitStep)
        {
            if (code != RecruitStep.RecruitStepCode) return BadRequest();

            var updatedRecruitStep = await _RecruitStepService.UpdateRecruitStepAsync(RecruitStep);
            if (updatedRecruitStep == null) return NotFound();

            return Ok(updatedRecruitStep);
        }

        [HttpDelete("{code}")]
        public async Task<IActionResult> Delete(string code)
        {
            var success = await _RecruitStepService.DeleteRecruitStepAsync(code);
            if (!success) return NotFound();

            return NoContent();
        }
    }
}
