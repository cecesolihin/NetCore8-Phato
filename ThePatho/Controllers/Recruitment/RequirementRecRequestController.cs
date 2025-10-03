using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using ThePatho.Provider.ApiResponse;
using ThePatho.Features.Recruitment.RequirementRecRequest.Commands;
using ThePatho.Features.Recruitment.RequirementRecRequest.DTO;
using ThePatho.Features.Recruitment.RequirementRecRequest.Service;

namespace ThePatho.Controllers
{
    [ApiController]
    [Route(ApiRoutes.RecruitmentMenu.RequirementRecRequest)]
    [ApiExplorerSettings(GroupName = "Recruitment")]
    [Authorize]
    public class RequirementRecRequestController : ControllerBase
    {
        private readonly IMediator mediator;

        public RequirementRecRequestController(IMediator _mediator)
        {
            mediator = _mediator ?? throw new ArgumentNullException(nameof(mediator));
        }
        private static IActionResult ApiResult<TResponse>(TResponse response) where TResponse : ApiResponse
        {
            return new ApiResult<TResponse>(response);
        }

        [HttpPost(ApiRoutes.Methods.GetList)]
        public async Task<IActionResult> GetRequirementRecRequestList([FromBody] GetRequirementRecRequestCommand command,
            CancellationToken cancellationToken)
        {
            var result = await mediator.Send(command, cancellationToken);

            return ApiResult(result);
        }

        [HttpGet(ApiRoutes.Methods.GetByCriteria)]
        public async Task<IActionResult> GetRequirementRecRequestByCriteria([FromQuery] GetRequirementRecRequestByCriteriaCommand command,
            CancellationToken cancellationToken)
        {
            var result = await mediator.Send(command, cancellationToken);

            return ApiResult(result);
        }
    }
}
