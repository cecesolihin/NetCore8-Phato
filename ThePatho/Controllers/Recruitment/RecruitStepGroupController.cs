using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using ThePatho.Features.ConfigurationExtensions;
using ThePatho.Features.Recruitment.RecruitStep.Commands;
using ThePatho.Features.Recruitment.RecruitStep.DTO;
using ThePatho.Features.Recruitment.RecruitStepGroup.DTO;
using ThePatho.Features.Recruitment.RecruitStepGroup.Service;

namespace ThePatho.Controllers
{
    [ApiController]
    [Route("api/recruitment/recruit-step-group")]
    public class RecruitStepGroupController : ControllerBase
    {
        private readonly IMediator mediator;

        public RecruitStepGroupController(IMediator _mediator)
        {
            mediator = _mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        [HttpPost("recruit-step-group-list")]
        public async Task<IActionResult> GetRecruitStepList([FromBody] GetRecruitStepCommand command,
            CancellationToken cancellationToken)
        {
            try
            {
                var result = await mediator.Send(command, cancellationToken);

                var response = new ApiResponse<List<RecruitStepDto>>(HttpStatusCode.OK, result.RecruitStepList, "Process Successed");

                return Ok(response);
            }
            catch (Exception ex)
            {
                var errorResponse = new ApiResponse<List<RecruitStepDto>>(HttpStatusCode.InternalServerError, null, "Internal Server Error", ex.Message);

                return StatusCode(StatusCodes.Status500InternalServerError, errorResponse);
            }
        }

        [HttpPost("recruit-step-group-by-criteria")]
        public async Task<IActionResult> GetRecruitStepByCode([FromBody] GetRecruitStepByCriteriaCommand command,
            CancellationToken cancellationToken)
        {
            try
            {
                var result = await mediator.Send(command, cancellationToken);

                var response = new ApiResponse<RecruitStepDto>(HttpStatusCode.OK, result, "Process Successed");

                return Ok(response);
            }
            catch (Exception ex)
            {
                var errorResponse = new ApiResponse<RecruitStepDto>(HttpStatusCode.InternalServerError, null, "Internal Server Error", ex.Message);

                return StatusCode(StatusCodes.Status500InternalServerError, errorResponse);
            }
        }
    }
}
