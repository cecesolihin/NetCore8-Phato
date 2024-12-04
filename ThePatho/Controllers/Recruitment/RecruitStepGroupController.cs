using Microsoft.AspNetCore.Mvc;
using ThePatho.Features.Recruitment.RecruitStepGroup.DTO;
using ThePatho.Features.Recruitment.RecruitStepGroup.Service;

namespace ThePatho.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RecruitStepGroupController : ControllerBase
    {
        private readonly IRecruitStepGroupService _RecruitStepGroupService;

        public RecruitStepGroupController(IRecruitStepGroupService RecruitStepGroupService)
        {
            _RecruitStepGroupService = RecruitStepGroupService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var categories = await _RecruitStepGroupService.GetAllRecruitStepGroupAsync();
            return Ok(categories);
        }

        [HttpGet("{code}")]
        public async Task<IActionResult> GetByCode(string code)
        {
            var RecruitStepGroup = await _RecruitStepGroupService.GetRecruitStepGroupByCodeAsync(code);
            if (RecruitStepGroup == null) return NotFound();
            return Ok(RecruitStepGroup);
        }

        [HttpPost]
        public async Task<IActionResult> Create(RecruitStepGroupDto RecruitStepGroup)
        {
            var createdRecruitStepGroup = await _RecruitStepGroupService.AddRecruitStepGroupAsync(RecruitStepGroup);
            return CreatedAtAction(nameof(GetByCode), new { code = createdRecruitStepGroup.RecStepGroupCode }, createdRecruitStepGroup);
        }

        [HttpPut("{code}")]
        public async Task<IActionResult> Update(string code, RecruitStepGroupDto RecruitStepGroup)
        {
            if (code != RecruitStepGroup.RecStepGroupCode) return BadRequest();

            var updatedRecruitStepGroup = await _RecruitStepGroupService.UpdateRecruitStepGroupAsync(RecruitStepGroup);
            if (updatedRecruitStepGroup == null) return NotFound();

            return Ok(updatedRecruitStepGroup);
        }

        [HttpDelete("{code}")]
        public async Task<IActionResult> Delete(string code)
        {
            var success = await _RecruitStepGroupService.DeleteRecruitStepGroupAsync(code);
            if (!success) return NotFound();

            return NoContent();
        }
    }
}
