using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using ThePatho.Domain.Models;
using ThePatho.Features.Applicant.ApplicantOnlineTestResult.Commands;
using ThePatho.Features.Applicant.ApplicantOnlineTestResult.DTO;
using ThePatho.Provider.ApiResponse;

namespace ThePatho.Controllers
{
    [ApiController]
    [Route(ApiRoutes.ApplicantMenu.ApplicantOnlineTestResult)]
    [ApiExplorerSettings(GroupName = "Applicant")]
    public class ApplicantOnlineTestResultController : ControllerBase
    {
        private readonly IMediator mediator;

        public ApplicantOnlineTestResultController(IMediator _mediator)
        {
            mediator = _mediator ?? throw new ArgumentNullException(nameof(mediator)); 
        }
        private static IActionResult ApiResult<TResponse>(TResponse response) where TResponse : ApiResponse
        {
            return new ApiResult<TResponse>(response);
        }

        [HttpPost(ApiRoutes.Methods.GetList)]
        public async Task<IActionResult> GetApplicantOnlineTestResultList([FromBody] GetApplicantOnlineTestResultCommand command,
            CancellationToken cancellationToken)
        {
            var result = await mediator.Send(command, cancellationToken);

            return ApiResult(result);
        }

        [HttpGet(ApiRoutes.Methods.GetByCriteria)]
        public async Task<IActionResult> GetApplicantOnlineTestResultByCriteria([FromQuery] GetApplicantOnlineTestResultByCriteriaCommand command,
            CancellationToken cancellationToken)
        {
            var result = await mediator.Send(command, cancellationToken);

            return ApiResult(result);
        }
        [HttpPost(ApiRoutes.Methods.Submit)]
        public async Task<IActionResult> SubmitApplicantOnlineTestResult([FromBody] SubmitApplicantOnlineTestResultCommand command, CancellationToken cancellationToken)
        {
            var result = await mediator.Send(command, cancellationToken);

            return ApiResult(result);
        }

        [HttpDelete(ApiRoutes.Methods.Delete)]
        public async Task<IActionResult> DeleteApplicantOnlineTestResult([FromBody] DeleteApplicantOnlineTestResultCommand command, CancellationToken cancellationToken)
        {
            var result = await mediator.Send(command, cancellationToken);

            return ApiResult(result);
        }
    }
}
