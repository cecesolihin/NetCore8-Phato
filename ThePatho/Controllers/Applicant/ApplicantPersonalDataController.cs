using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using ThePatho.Domain.Models;
using ThePatho.Features.Applicant.ApplicantPersonalData.Commands;
using ThePatho.Features.Applicant.ApplicantPersonalData.DTO;
using ThePatho.Provider.ApiResponse;

namespace ThePatho.Controllers
{
    [ApiController]
    [Route(ApiRoutes.ApplicantMenu.ApplicantPersonalData)]
    [ApiExplorerSettings(GroupName = "Applicant")]
    [Authorize]
    public class ApplicantPersonalDataController : ControllerBase
    {
        private readonly IMediator mediator;

        public ApplicantPersonalDataController(IMediator _mediator)
        {
            mediator = _mediator ?? throw new ArgumentNullException(nameof(mediator)); 
        }
        private static IActionResult ApiResult<TResponse>(TResponse response) where TResponse : ApiResponse
        {
            return new ApiResult<TResponse>(response);

        }
        [HttpPost(ApiRoutes.Methods.GetList)]
        public async Task<IActionResult> GetApplicantPersonalDataList([FromBody] GetApplicantPersonalDataCommand command,
            CancellationToken cancellationToken)
        {
            var result = await mediator.Send(command, cancellationToken);

            return ApiResult(result);
        }

        [HttpGet(ApiRoutes.Methods.GetByCriteria)]
        public async Task<IActionResult> GetApplicantPersonalDataByCriteria([FromQuery] GetApplicantPersonalDataByCriteriaCommand command,
            CancellationToken cancellationToken)
        {
            var result = await mediator.Send(command, cancellationToken);

            return ApiResult(result);
        }
        [HttpPost(ApiRoutes.Methods.Submit)]
        public async Task<IActionResult> SubmitApplicantPersonalData([FromBody] SubmitApplicantPersonalDataCommand command, CancellationToken cancellationToken)
        {
            var result = await mediator.Send(command, cancellationToken);

            return ApiResult(result);
        }

        [HttpDelete(ApiRoutes.Methods.Delete)]
        public async Task<IActionResult> DeleteApplicantPersonalData([FromBody] DeleteApplicantPersonalDataCommand command, CancellationToken cancellationToken)
        {
            var result = await mediator.Send(command, cancellationToken);

            return ApiResult(result);
        }
    }
}
