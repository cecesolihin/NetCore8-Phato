using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using ThePatho.Features.ConfigurationExtensions;
using ThePatho.Features.Recruitment.RecruitmentRequest.DTO;
using ThePatho.Features.Recruitment.RecruitmentRequest.Service;
using ThePatho.Features.Recruitment.RecruitmentRequest.Commands;
using ThePatho.Features.Recruitment.RecruitmentRequest.Commands;

namespace ThePatho.Controllers
{
    [ApiController]
    [Route(ApiRoutes.RecruitmentMenu.RecruitmentRequest)]
    [ApiExplorerSettings(GroupName = "Recruitment")]
    public class RecruitmentRequestController : ControllerBase
    {
        private readonly IMediator mediator;

        public RecruitmentRequestController(IMediator _mediator)
        {
            mediator = _mediator ?? throw new ArgumentNullException(nameof(mediator)); 
        }

        [HttpPost(ApiRoutes.Methods.GetList)]
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

        [HttpGet(ApiRoutes.Methods.GetByCriteria)]
        public async Task<IActionResult> GetRecruitmentRequestByCriteria([FromQuery] GetRecruitmentRequestByCriteriaCommand command,
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

        [HttpPost(ApiRoutes.Methods.Submit)]
        public async Task<IActionResult> SubmitRecruitmentRequest([FromBody] SubmitRecruitmentRequestCommand command, CancellationToken cancellationToken)
        {
            try
            {
                var result = await mediator.Send(command, cancellationToken);

                var response = new ApiResponse<string>(
                    HttpStatusCode.OK,
                    result,
                    "Process succeeded"
                );

                return Ok(response);
            }
            catch (Exception ex)
            {
                var errorResponse = new ApiResponse<string>(
                    HttpStatusCode.InternalServerError,
                    null,
                    "Internal Server Error",
                    ex.Message
                );

                return StatusCode(StatusCodes.Status500InternalServerError, errorResponse);
            }
        }

        [HttpDelete(ApiRoutes.Methods.Delete)]
        public async Task<IActionResult> DeleteRecruitmentRequest([FromBody] DeleteRecruitmentRequestCommand command, CancellationToken cancellationToken)
        {
            try
            {
                var result = await mediator.Send(command, cancellationToken);

                if (result)
                {
                    var response = new ApiResponse<string>(HttpStatusCode.OK, command.RequestNo, "Requirement Request deleted successfully");
                    return Ok(response);
                }
                else
                {
                    var errorResponse = new ApiResponse<string>(HttpStatusCode.InternalServerError, null, "Failed to delete Requirement Request");
                    return StatusCode(StatusCodes.Status500InternalServerError, errorResponse);
                }
            }
            catch (Exception ex)
            {
                var errorResponse = new ApiResponse<string>(HttpStatusCode.InternalServerError, null, "Internal Server Error", ex.Message);
                return StatusCode(StatusCodes.Status500InternalServerError, errorResponse);
            }
        }
    }
}
