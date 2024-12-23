using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using ThePatho.Features.ConfigurationExtensions;
using ThePatho.Features.Recruitment.RequirementRecRequest.Commands;
using ThePatho.Features.Recruitment.RequirementRecRequest.DTO;
using ThePatho.Features.Recruitment.RequirementRecRequest.Service;

namespace ThePatho.Controllers
{
    [ApiController]
    [Route("api/recruitment/recruitment-rec-request")]
    [ApiExplorerSettings(GroupName = "Recruitment")]
    public class RequirementRecRequestController : ControllerBase
    {
        private readonly IMediator mediator;

        public RequirementRecRequestController(IMediator _mediator)
        {
            mediator = _mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        [HttpPost("recruitment-rec-list")]
        public async Task<IActionResult> GetRequirementRecRequestList([FromBody] GetRequirementRecRequestCommand command,
            CancellationToken cancellationToken)
        {
            try
            {
                var result = await mediator.Send(command, cancellationToken);

                var response = new ApiResponse<List<RequirementRecRequestDto>>(HttpStatusCode.OK, result.RequirementRecRequestList, "Process Successed");

                return Ok(response);
            }
            catch (Exception ex)
            {
                var errorResponse = new ApiResponse<List<RequirementRecRequestDto>>(HttpStatusCode.InternalServerError, null, "Internal Server Error", ex.Message);

                return StatusCode(StatusCodes.Status500InternalServerError, errorResponse);
            }
        }

        [HttpPost("recruitment-rec-by-criteria")]
        public async Task<IActionResult> GetRequirementRecRequestByCode([FromBody] GetRequirementRecRequestByCodeCommand command,
            CancellationToken cancellationToken)
        {
            try
            {
                var result = await mediator.Send(command, cancellationToken);

                var response = new ApiResponse<List<RequirementRecRequestDto>>(HttpStatusCode.OK, result.RequirementRecRequestList, "Process Successed");

                return Ok(response);
            }
            catch (Exception ex)
            {
                var errorResponse = new ApiResponse<RequirementRecRequestDto>(HttpStatusCode.InternalServerError, null, "Internal Server Error", ex.Message);

                return StatusCode(StatusCodes.Status500InternalServerError, errorResponse);
            }
        }
    }
}
