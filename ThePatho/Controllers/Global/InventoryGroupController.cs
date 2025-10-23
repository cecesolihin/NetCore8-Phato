using MediatR;
using Microsoft.AspNetCore.Mvc;
using ThePatho.Provider.ApiResponse;
using Microsoft.AspNetCore.Authorization;
using ThePatho.Features.Global.InventoryGroup.Commands;

namespace ThePatho.Controllers.Global
{
    [ApiController]
    [Route(ApiRoutes.GlobalMenu.InventoryGroup)]
    [ApiExplorerSettings(GroupName = "Global")]
    [Authorize]
    public class InventoryGroupController : ControllerBase
    {
        private readonly IMediator mediator;

        public InventoryGroupController(IMediator _mediator)
        {
            mediator = _mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        private static IActionResult ApiResult<TResponse>(TResponse response) where TResponse : ApiResponse
        {
            return new ApiResult<TResponse>(response);
        }

        [HttpPost(ApiRoutes.Methods.GetList)]
        public async Task<IActionResult> GetInventoryGroupList([FromBody] GetInventoryGroupCommand command,
            CancellationToken cancellationToken)
        {
            var result = await mediator.Send(command, cancellationToken);
            return ApiResult(result);
        }

        [HttpGet(ApiRoutes.Methods.GetByCriteria)]
        public async Task<IActionResult> GetInventoryGroupByCriteria([FromQuery] GetInventoryGroupByCriteriaCommand command,
            CancellationToken cancellationToken)
        {
            var result = await mediator.Send(command, cancellationToken);
            return ApiResult(result);
        }

        [HttpGet(ApiRoutes.Methods.GetSingle)]
        public async Task<IActionResult> GetSingleInventoryGroup([FromQuery] GetSingleInventoryGroupCommand command,
            CancellationToken cancellationToken)
        {
            var result = await mediator.Send(command, cancellationToken);
            return ApiResult(result);
        }

        [HttpPost(ApiRoutes.Methods.Submit)]
        public async Task<IActionResult> SubmitInventoryGroup([FromBody] SubmitInventoryGroupCommand command,
            CancellationToken cancellationToken)
        {
            var result = await mediator.Send(command, cancellationToken);
            return ApiResult(result);
        }

        [HttpDelete(ApiRoutes.Methods.Delete)]
        public async Task<IActionResult> DeleteInventoryGroup([FromBody] DeleteInventoryGroupCommand command,
            CancellationToken cancellationToken)
        {
            var result = await mediator.Send(command, cancellationToken);
            return ApiResult(result);
        }
    }
}
