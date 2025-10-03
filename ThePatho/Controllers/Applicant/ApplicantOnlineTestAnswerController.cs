using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using ThePatho.Domain.Models;
using ThePatho.Features.Applicant.ApplicantOnlineTestAnswer.Commands;
using ThePatho.Features.Applicant.ApplicantOnlineTestAnswer.DTO;
using ThePatho.Provider.ApiResponse;

namespace ThePatho.Controllers
{
    [ApiController]
    [Route(ApiRoutes.ApplicantMenu.ApplicantOnlineTestAnswer)]
    [ApiExplorerSettings(GroupName = "Applicant")]
    [Authorize]
    public class ApplicantOnlineTestAnswerController : ControllerBase
    {
        private readonly IMediator mediator;

        public ApplicantOnlineTestAnswerController(IMediator _mediator)
        {
            mediator = _mediator ?? throw new ArgumentNullException(nameof(mediator)); 
        }
        private static IActionResult ApiResult<TResponse>(TResponse response) where TResponse : ApiResponse
        {
            return new ApiResult<TResponse>(response);
        }

        [HttpPost(ApiRoutes.Methods.GetList)]
        public async Task<IActionResult> GetApplicantOnlineTestAnswerList([FromBody] GetApplicantOnlineTestAnswerCommand command,
            CancellationToken cancellationToken)
        {
            var result = await mediator.Send(command, cancellationToken);

            return ApiResult(result);
        }

        [HttpGet(ApiRoutes.Methods.GetByCriteria)]
        public async Task<IActionResult> GetApplicantOnlineTestAnswerByCriteria([FromQuery] GetApplicantOnlineTestAnswerByCriteriaCommand command,
            CancellationToken cancellationToken)
        {
            var result = await mediator.Send(command, cancellationToken);

            return ApiResult(result);
        }
        [HttpPost(ApiRoutes.Methods.Submit)]
        public async Task<IActionResult> SubmitApplicantOnlineTestAnswer([FromBody] SubmitApplicantOnlineTestAnswerCommand command, CancellationToken cancellationToken)
        {
            var result = await mediator.Send(command, cancellationToken);

            return ApiResult(result);
        }

        [HttpDelete(ApiRoutes.Methods.Delete)]
        public async Task<IActionResult> DeleteApplicantOnlineTestAnswer([FromBody] DeleteApplicantOnlineTestAnswerCommand command, CancellationToken cancellationToken)
        {
            var result = await mediator.Send(command, cancellationToken);

            return ApiResult(result);
        }
    }
}
