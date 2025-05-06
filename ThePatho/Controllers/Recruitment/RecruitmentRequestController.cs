using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using ThePatho.Provider.ApiResponse;
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
        private static IActionResult ApiResult<TResponse>(TResponse response) where TResponse : ApiResponse
        {
            return new ApiResult<TResponse>(response);
        }

        [HttpPost(ApiRoutes.Methods.GetList)]
        public async Task<IActionResult> GetRecruitmentRequestList([FromBody] GetRecruitmentRequestCommand command,
            CancellationToken cancellationToken)
        {
            var result = await mediator.Send(command, cancellationToken);

            return ApiResult(result);
        }

        [HttpGet(ApiRoutes.Methods.GetByCriteria)]
        public async Task<IActionResult> GetRecruitmentRequestByCriteria([FromQuery] GetRecruitmentRequestByCriteriaCommand command,
            CancellationToken cancellationToken)
        {
            var result = await mediator.Send(command, cancellationToken);

            return ApiResult(result);
        }

        [HttpPost(ApiRoutes.Methods.Submit)]
        public async Task<IActionResult> SubmitRecruitmentRequest([FromBody] SubmitRecruitmentRequestCommand command, CancellationToken cancellationToken)
        {
            var result = await mediator.Send(command, cancellationToken);

            return ApiResult(result);
        }

        [HttpDelete(ApiRoutes.Methods.Delete)]
        public async Task<IActionResult> DeleteRecruitmentRequest([FromBody] DeleteRecruitmentRequestCommand command, CancellationToken cancellationToken)
        {
            var result = await mediator.Send(command, cancellationToken);

            return ApiResult(result);
        }
    }
}
