using Microsoft.AspNetCore.Mvc;
using ThePatho.Features.Recruitment.RequirementRecRequest.DTO;
using ThePatho.Features.Recruitment.RequirementRecRequest.Service;

namespace ThePatho.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RequirementRecRequestController : ControllerBase
    {
        private readonly IRequirementRecRequestService _RequirementRecRequestService;

        public RequirementRecRequestController(IRequirementRecRequestService RequirementRecRequestService)
        {
            _RequirementRecRequestService = RequirementRecRequestService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var categories = await _RequirementRecRequestService.GetAllRequirementRecRequestAsync();
            return Ok(categories);
        }

        [HttpGet("{code}")]
        public async Task<IActionResult> GetByCode(string code)
        {
            var RequirementRecRequest = await _RequirementRecRequestService.GetRequirementRecRequestByCodeAsync(code);
            if (RequirementRecRequest == null) return NotFound();
            return Ok(RequirementRecRequest);
        }

        [HttpPost]
        public async Task<IActionResult> Create(RequirementRecRequestDto RequirementRecRequest)
        {
            var createdRequirementRecRequest = await _RequirementRecRequestService.AddRequirementRecRequestAsync(RequirementRecRequest);
            return CreatedAtAction(nameof(GetByCode), new { code = createdRequirementRecRequest.RequestNo }, createdRequirementRecRequest);
        }

        [HttpPut("{code}")]
        public async Task<IActionResult> Update(string code, RequirementRecRequestDto RequirementRecRequest)
        {
            if (code != RequirementRecRequest.RequestNo) return BadRequest();

            var updatedRequirementRecRequest = await _RequirementRecRequestService.UpdateRequirementRecRequestAsync(RequirementRecRequest);
            if (updatedRequirementRecRequest == null) return NotFound();

            return Ok(updatedRequirementRecRequest);
        }

        [HttpDelete("{code}")]
        public async Task<IActionResult> Delete(string code)
        {
            var success = await _RequirementRecRequestService.DeleteRequirementRecRequestAsync(code);
            if (!success) return NotFound();

            return NoContent();
        }
    }
}
