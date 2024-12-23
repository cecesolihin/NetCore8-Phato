using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using ThePatho.Domain.Models;
using ThePatho.Features.Applicant.ApplicantOnlineTestAnswer.Commands;
using ThePatho.Features.Applicant.ApplicantOnlineTestAnswer.DTO;
using ThePatho.Features.ConfigurationExtensions;

namespace ThePatho.Controllers
{
    [ApiController]
    [Route("api/applicant/applicant-online-test-answer")]
    [ApiExplorerSettings(GroupName = "Applicant")]
    public class ApplicantOnlineTestAnswerController : ControllerBase
    {
        private readonly IMediator mediator;

        public ApplicantOnlineTestAnswerController(IMediator _mediator)
        {
            mediator = _mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        [HttpPost("applicant-online-test-answer-list")]
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

        [HttpPost("applicant-online-test-answer-by-criteria")]
        public async Task<IActionResult> GetApplicantOnlineTestAnswerByCriteria([FromBody] GetApplicantOnlineTestAnswerByCriteriaCommand command,
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
    }
}
