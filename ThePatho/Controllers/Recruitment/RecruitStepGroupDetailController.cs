using Microsoft.AspNetCore.Mvc;
using ThePatho.Domain.Models;
using ThePatho.Features.Recruitment.RecruitStepGroupDetail.DTO;
using ThePatho.Features.Recruitment.RecruitStepGroupDetail.Service;

namespace ThePatho.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RecruitStepGroupDetailController : ControllerBase
    {
        private readonly IRecruitStepGroupDetailService _RecruitStepGroupDetailService;

        public RecruitStepGroupDetailController(IRecruitStepGroupDetailService RecruitStepGroupDetailService)
        {
            _RecruitStepGroupDetailService = RecruitStepGroupDetailService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var categories = await _RecruitStepGroupDetailService.GetAllRecruitStepGroupDetailAsync();
            return Ok(categories);
        }

        [HttpGet("{code}")]
        public async Task<IActionResult> GetByCode(string code)
        {
            var RecruitStepGroupDetail = await _RecruitStepGroupDetailService.GetRecruitStepGroupDetailByCodeAsync(code);
            if (RecruitStepGroupDetail == null) return NotFound();
            return Ok(RecruitStepGroupDetail);
        }

        [HttpPost]
        public async Task<IActionResult> Create(RecruitStepGroupDetailDto RecruitStepGroupDetail)
        {
            var createdRecruitStepGroupDetail = await _RecruitStepGroupDetailService.AddRecruitStepGroupDetailAsync(RecruitStepGroupDetail);
            return CreatedAtAction(nameof(GetByCode), new { code = createdRecruitStepGroupDetail.RecStepGroupCode }, createdRecruitStepGroupDetail);
        }

        [HttpPut("{code}")]
        public async Task<IActionResult> Update(string code, RecruitStepGroupDetailDto RecruitStepGroupDetail)
        {
            if (code != RecruitStepGroupDetail.RecStepGroupCode) return BadRequest();

            var updatedRecruitStepGroupDetail = await _RecruitStepGroupDetailService.UpdateRecruitStepGroupDetailAsync(RecruitStepGroupDetail);
            if (updatedRecruitStepGroupDetail == null) return NotFound();

            return Ok(updatedRecruitStepGroupDetail);
        }

        [HttpDelete("{code}")]
        public async Task<IActionResult> Delete(string code)
        {
            var success = await _RecruitStepGroupDetailService.DeleteRecruitStepGroupDetailAsync(code);
            if (!success) return NotFound();

            return NoContent();
        }
    }
}
