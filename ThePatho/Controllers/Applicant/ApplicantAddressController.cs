using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using ThePatho.Domain.Models;
using ThePatho.Features.Applicant.ApplicantAddress.Commands;
using ThePatho.Features.Applicant.ApplicantAddress.DTO;
using ThePatho.Provider.ApiResponse;

namespace ThePatho.Controllers
{
    [ApiController]
    [Route(ApiRoutes.ApplicantMenu.ApplicantAddress)]
    [ApiExplorerSettings(GroupName = "Applicant")]
    public class ApplicantAddressController : ControllerBase
    {
        private readonly IMediator mediator;

        public ApplicantAddressController(IMediator _mediator)
        {
            mediator = _mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        private static IActionResult ApiResult<TResponse>(TResponse response) where TResponse : ApiResponse
        {
            return new ApiResult<TResponse>(response);
        }

        [HttpPost(ApiRoutes.Methods.GetList)]
        public async Task<IActionResult> GetApplicantAddressList([FromBody] GetApplicantAddressCommand command,
            CancellationToken cancellationToken)
        {
            var result = await mediator.Send(command, cancellationToken);

            return ApiResult(result);
        }

        [HttpGet(ApiRoutes.Methods.GetByCriteria)]
        public async Task<IActionResult> GetApplicantAddressByCriteria([FromQuery] GetApplicantAddressByCriteriaCommand command,
            CancellationToken cancellationToken)
        {
            var result = await mediator.Send(command, cancellationToken);

            return ApiResult(result);
        }

        [HttpPost(ApiRoutes.Methods.Submit)]
        public async Task<IActionResult> SubmitApplicantAddress([FromBody] SubmitApplicantAddressCommand command, CancellationToken cancellationToken)
        {
            var result = await mediator.Send(command, cancellationToken);

            return ApiResult(result);
        }

        [HttpDelete(ApiRoutes.Methods.Delete)]
        public async Task<IActionResult> DeleteApplicantAddress([FromBody] DeleteApplicantAddressCommand command, CancellationToken cancellationToken)
        {
            var result = await mediator.Send(command, cancellationToken);

            return ApiResult(result);
        }
    }
}
