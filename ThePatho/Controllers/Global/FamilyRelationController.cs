using MediatR;
using Microsoft.AspNetCore.Mvc;
using ThePatho.Provider.ApiResponse;
using Microsoft.AspNetCore.Authorization;
using ThePatho.Features.Global.FamilyRelation.Commands;

namespace ThePatho.Controllers.Global
{
    [ApiController]
    [Route(ApiRoutes.GlobalMenu.FamilyRelation)]
    [ApiExplorerSettings(GroupName = "Global")]
    [Authorize]
    public class FamilyRelationController : ControllerBase
    {
        private readonly IMediator mediator;

        public FamilyRelationController(IMediator _mediator)
        {
            mediator = _mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        private static IActionResult ApiResult<TResponse>(TResponse response) where TResponse : ApiResponse
        {
            return new ApiResult<TResponse>(response);
        }

        [HttpPost(ApiRoutes.Methods.GetList)]
        public async Task<IActionResult> GetFamilyRelationList([FromBody] GetFamilyRelationCommand command,
            CancellationToken cancellationToken)
        {
            var result = await mediator.Send(command, cancellationToken);
            return ApiResult(result);
        }

        [HttpGet(ApiRoutes.Methods.GetByCriteria)]
        public async Task<IActionResult> GetFamilyRelationByCriteria([FromQuery] GetFamilyRelationByCriteriaCommand command,
            CancellationToken cancellationToken)
        {
            var result = await mediator.Send(command, cancellationToken);
            return ApiResult(result);
        }

        [HttpGet(ApiRoutes.Methods.GetSingle)]
        public async Task<IActionResult> GetSingleFamilyRelation([FromQuery] GetSingleFamilyRelationCommand command,
            CancellationToken cancellationToken)
        {
            var result = await mediator.Send(command, cancellationToken);
            return ApiResult(result);
        }

        [HttpPost(ApiRoutes.Methods.Submit)]
        public async Task<IActionResult> SubmitFamilyRelation([FromBody] SubmitFamilyRelationCommand command,
            CancellationToken cancellationToken)
        {
            var result = await mediator.Send(command, cancellationToken);
            return ApiResult(result);
        }

        [HttpDelete(ApiRoutes.Methods.Delete)]
        public async Task<IActionResult> DeleteFamilyRelation([FromBody] DeleteFamilyRelationCommand command,
            CancellationToken cancellationToken)
        {
            var result = await mediator.Send(command, cancellationToken);
            return ApiResult(result);
        }
    }
}
