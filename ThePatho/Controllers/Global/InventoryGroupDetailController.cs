using MediatR;
using Microsoft.AspNetCore.Mvc;
using ThePatho.Provider.ApiResponse;
using Microsoft.AspNetCore.Authorization;
using ThePatho.Features.Global.InventoryGroupDetail.Commands;

namespace ThePatho.Controllers.Global
{
    [ApiController]
    [Route(ApiRoutes.GlobalMenu.InventoryGroupDetail)]
    [ApiExplorerSettings(GroupName = "Global")]
    [Authorize]
    public class InventoryGroupDetailController : ControllerBase
    {
        private readonly IMediator mediator;

        public InventoryGroupDetailController(IMediator _mediator)
        {
            mediator = _mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        private static IActionResult ApiResult<TResponse>(TResponse response) where TResponse : ApiResponse
        {
            return new ApiResult<TResponse>(response);
        }

        [HttpPost(ApiRoutes.Methods.GetList)]
        public async Task<IActionResult> GetInventoryGroupDetailList([FromBody] GetInventoryGroupDetailCommand command,
            CancellationToken cancellationToken)
        {
            var result = await mediator.Send(command, cancellationToken);
            return ApiResult(result);
        }

        [HttpGet(ApiRoutes.Methods.GetByCriteria)]
        public async Task<IActionResult> GetInventoryGroupDetailByCriteria([FromQuery] GetInventoryGroupDetailByCriteriaCommand command,
            CancellationToken cancellationToken)
        {
            var result = await mediator.Send(command, cancellationToken);
            return ApiResult(result);
        }

        [HttpGet(ApiRoutes.Methods.GetSingle)]
        public async Task<IActionResult> GetSingleInventoryGroupDetail([FromQuery] GetSingleInventoryGroupDetailCommand command,
            CancellationToken cancellationToken)
        {
            var result = await mediator.Send(command, cancellationToken);
            return ApiResult(result);
        }

        [HttpPost(ApiRoutes.Methods.Submit)]
        public async Task<IActionResult> SubmitInventoryGroupDetail([FromBody] SubmitInventoryGroupDetailCommand command,
            CancellationToken cancellationToken)
        {
            var result = await mediator.Send(command, cancellationToken);
            return ApiResult(result);
        }

        [HttpDelete(ApiRoutes.Methods.Delete)]
        public async Task<IActionResult> DeleteInventoryGroupDetail([FromBody] DeleteInventoryGroupDetailCommand command,
            CancellationToken cancellationToken)
        {
            var result = await mediator.Send(command, cancellationToken);
            return ApiResult(result);
        }
    }
}
