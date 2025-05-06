using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using ThePatho.Provider.ApiResponse;
using ThePatho.Features.Recruitment.RecruitStep.Commands;
using ThePatho.Features.Recruitment.RecruitStep.DTO;

namespace ThePatho.Controllers
{
    [ApiController]
    [Route(ApiRoutes.RecruitmentMenu.RecruitStep)]
    [ApiExplorerSettings(GroupName = "Recruitment")]
    public class RecruitStepController : ControllerBase
    {
        private readonly IMediator mediator;

        public RecruitStepController(IMediator _mediator)
        {
            mediator = _mediator ?? throw new ArgumentNullException(nameof(mediator)); 
        }
        private static IActionResult ApiResult<TResponse>(TResponse response) where TResponse : ApiResponse
        {
            return new ApiResult<TResponse>(response);
        }
        [HttpPost(ApiRoutes.Methods.GetList)]
        public async Task<IActionResult> GetRecruitStepList([FromBody] GetRecruitStepCommand command,
            CancellationToken cancellationToken)
        {
            var result = await mediator.Send(command, cancellationToken);

            return ApiResult(result);
        }

        [HttpGet(ApiRoutes.Methods.GetByCriteria)]
        public async Task<IActionResult> GetRecruitStepByCriteria([FromQuery] GetRecruitStepByCriteriaCommand command,
            CancellationToken cancellationToken)
        {
            var result = await mediator.Send(command, cancellationToken);

            return ApiResult(result);
        }

        [HttpPost(ApiRoutes.Methods.Submit)]
        public async Task<IActionResult> SubmitRecruitStep([FromBody] SubmitRecruitStepCommand command, CancellationToken cancellationToken)
        {
            var result = await mediator.Send(command, cancellationToken);

            return ApiResult(result);
        }

        [HttpDelete(ApiRoutes.Methods.Delete)]
        public async Task<IActionResult> DeleteRecruitStep([FromBody] DeleteRecruitStepCommand command, CancellationToken cancellationToken)
        {
            var result = await mediator.Send(command, cancellationToken);

            return ApiResult(result);
        }

    }
}
