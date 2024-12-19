using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using ThePatho.Features.ConfigurationExtensions;
using ThePatho.Features.Recruitment.RecruitmentReqStep.DTO;
using ThePatho.Features.Recruitment.RecruitmentReqStep.Service;
using ThePatho.Features.Recruitment.RecruitmentReqStep.Commands;

namespace ThePatho.Controllers
{
    [ApiController]
    [Route("api/recruitment/recruitment-req-step")]
    public class RecruitmentReqStepController : ControllerBase
    {
        private readonly IMediator mediator;

        public RecruitmentReqStepController(IMediator _mediator)
        {
            mediator = _mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        [HttpPost("recruitment-req-step-list")]
        public async Task<IActionResult> GetRecruitmentReqStepList([FromBody] GetRecruitmentReqStepCommand command,
            CancellationToken cancellationToken)
        {
            try
            {
                var result = await mediator.Send(command, cancellationToken);

                var response = new ApiResponse<List<RecruitmentReqStepDto>>(HttpStatusCode.OK, result.RecruitmentReqStepList, "Process Successed");

                return Ok(response);
            }
            catch (Exception ex)
            {
                var errorResponse = new ApiResponse<List<RecruitmentReqStepDto>>(HttpStatusCode.InternalServerError, null, "Internal Server Error", ex.Message);

                return StatusCode(StatusCodes.Status500InternalServerError, errorResponse);
            }
        }

        [HttpPost("recruitment-req-step-by-criteria")]
        public async Task<IActionResult> GetRecruitmentReqStepByCode([FromBody] GetRecruitmentReqStepByCriteriaCommand command,
            CancellationToken cancellationToken)
        {
            try
            {
                var result = await mediator.Send(command, cancellationToken);

                var response = new ApiResponse<List<RecruitmentReqStepDto>>(HttpStatusCode.OK, result.RecruitmentReqStepList, "Process Successed");

                return Ok(response);
            }
            catch (Exception ex)
            {
                var errorResponse = new ApiResponse<RecruitmentReqStepDto>(HttpStatusCode.InternalServerError, null, "Internal Server Error", ex.Message);

                return StatusCode(StatusCodes.Status500InternalServerError, errorResponse);
            }
        }
    }
}
