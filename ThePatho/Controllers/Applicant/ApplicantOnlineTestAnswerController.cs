using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using ThePatho.Domain.Models;
using ThePatho.Features.Applicant.ApplicantOnlineTestAnswer.Commands;
using ThePatho.Features.Applicant.ApplicantOnlineTestAnswer.Commands;
using ThePatho.Features.Applicant.ApplicantOnlineTestAnswer.DTO;
using ThePatho.Features.ConfigurationExtensions;

namespace ThePatho.Controllers
{
    [ApiController]
    [Route(ApiRoutes.ApplicantMenu.ApplicantOnlineTestAnswer)]
    [ApiExplorerSettings(GroupName = "Applicant")]
    public class ApplicantOnlineTestAnswerController : ControllerBase
    {
        private readonly IMediator mediator;

        public ApplicantOnlineTestAnswerController(IMediator _mediator)
        {
            mediator = _mediator ?? throw new ArgumentNullException(nameof(mediator)); 
        }

        [HttpPost(ApiRoutes.Methods.GetList)]
        public async Task<IActionResult> GetApplicantOnlineTestAnswerList([FromBody] GetApplicantOnlineTestAnswerCommand command,
            CancellationToken cancellationToken)
        {
            try
            {
                var result = await mediator.Send(command, cancellationToken);

                var response = new ApiResponse<List<ApplicantOnlineTestAnswerDto>>(HttpStatusCode.OK, result.ApplicantOnlineTestAnswerList, "Process Successed");

                return Ok(response);
            }
            catch (Exception ex)
            {
                var errorResponse = new ApiResponse<List<ApplicantOnlineTestAnswerDto>>(HttpStatusCode.InternalServerError, null, "Internal Server Error", ex.Message);

                return StatusCode(StatusCodes.Status500InternalServerError, errorResponse);
            }
        }

        [HttpGet(ApiRoutes.Methods.GetByCriteria)]
        public async Task<IActionResult> GetApplicantOnlineTestAnswerByCriteria([FromQuery] GetApplicantOnlineTestAnswerByCriteriaCommand command,
            CancellationToken cancellationToken)
        {
            try
            {
                var result = await mediator.Send(command, cancellationToken);

                var response = new ApiResponse<ApplicantOnlineTestAnswerDto>(HttpStatusCode.OK, result, "Process Successed");

                return Ok(response);
            }
            catch (Exception ex)
            {
                var errorResponse = new ApiResponse<ApplicantOnlineTestAnswerDto>(HttpStatusCode.InternalServerError, null, "Internal Server Error", ex.Message);

                return StatusCode(StatusCodes.Status500InternalServerError, errorResponse);
            }
        }
        [HttpPost(ApiRoutes.Methods.Submit)]
        public async Task<IActionResult> SubmitApplicantOnlineTestAnswer([FromBody] SubmitApplicantOnlineTestAnswerCommand command, CancellationToken cancellationToken)
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
        public async Task<IActionResult> DeleteApplicantOnlineTestAnswer([FromBody] DeleteApplicantOnlineTestAnswerCommand command, CancellationToken cancellationToken)
        {
            try
            {
                var result = await mediator.Send(command, cancellationToken);

                if (result)
                {
                    var response = new ApiResponse<string>(HttpStatusCode.OK, command.AppAnswerId.ToString(), "Applicant Address deleted successfully");
                    return Ok(response);
                }
                else
                {
                    var errorResponse = new ApiResponse<string>(HttpStatusCode.InternalServerError, null, "Failed to delete Applicant Address");
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
