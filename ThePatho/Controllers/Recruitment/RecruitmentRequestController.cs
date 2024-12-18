using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using ThePatho.Features.ConfigurationExtensions;
using ThePatho.Features.Recruitment.RecruitmentRequest.DTO;
using ThePatho.Features.Recruitment.RecruitmentRequest.Service;
using ThePatho.Features.Recruitment.RecruitmentRequest.Commands;

namespace ThePatho.Controllers
{
    [ApiController]
    [Route("api/recruitment/recruitment-request")]
    public class RecruitmentRequestController : ControllerBase
    {
        private readonly IMediator mediator;

        public RecruitmentRequestController(IMediator _mediator)
        {
            mediator = _mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        [HttpPost("recruitment-request-list")]
        public async Task<IActionResult> GetRecruitmentRequestList([FromBody] GetRecruitmentRequestCommand command,
            CancellationToken cancellationToken)
        {
            try
            {
                var result = await mediator.Send(command, cancellationToken);

                var response = new ApiResponse<List<RecruitmentRequestDto>>(HttpStatusCode.OK, result.RecruitmentRequestList, "Process Successed");

                return Ok(response);
            }
            catch (Exception ex)
            {
                var errorResponse = new ApiResponse<List<RecruitmentRequestDto>>(HttpStatusCode.InternalServerError, null, "Internal Server Error", ex.Message);

                return StatusCode(StatusCodes.Status500InternalServerError, errorResponse);
            }
        }

        [HttpPost("recruitment-request-by-code")]
        public async Task<IActionResult> GetRecruitmentRequestByCode([FromBody] GetRecruitmentRequestByCodeCommand command,
            CancellationToken cancellationToken)
        {
            try
            {
                var result = await mediator.Send(command, cancellationToken);

                var response = new ApiResponse<RecruitmentRequestDto>(HttpStatusCode.OK, result, "Process Successed");

                return Ok(response);
            }
            catch (Exception ex)
            {
                var errorResponse = new ApiResponse<RecruitmentRequestDto>(HttpStatusCode.InternalServerError, null, "Internal Server Error", ex.Message);

                return StatusCode(StatusCodes.Status500InternalServerError, errorResponse);
            }
        }
    }
}
