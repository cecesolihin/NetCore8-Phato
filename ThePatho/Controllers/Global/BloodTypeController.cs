using MediatR;
using Microsoft.AspNetCore.Mvc;
using ThePatho.Provider.ApiResponse;
using ThePatho.Features.Global.BloodType.Commands;
using Microsoft.AspNetCore.Authorization;

namespace ThePatho.Controllers
{
    [ApiController]
    [Route(ApiRoutes.GlobalMenu.BloodType)]
    [ApiExplorerSettings(GroupName = "Global")]
    [Authorize]
    public class BloodTypeController : ControllerBase
    {
        private readonly IMediator mediator;

        public BloodTypeController(IMediator _mediator)
        {
            mediator = _mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        private static IActionResult ApiResult<TResponse>(TResponse response) where TResponse : ApiResponse
        {
            return new ApiResult<TResponse>(response);
        }
        //[Authorize(Roles = "Admin,HR")]
        [HttpPost(ApiRoutes.Methods.GetList)]
        public async Task<IActionResult> GetBloodTypeList([FromBody] GetBloodTypeCommand command,
            CancellationToken cancellationToken)
        {
            var result = await mediator.Send(command, cancellationToken);
            return ApiResult(result);
        }

        [HttpGet(ApiRoutes.Methods.GetByCriteria)]
        public async Task<IActionResult> GetBloodTypeByCriteria([FromQuery] GetBloodTypeByCriteriaCommand command,
            CancellationToken cancellationToken)
        {
            var result = await mediator.Send(command, cancellationToken);
            return ApiResult(result);
        }

        [HttpGet(ApiRoutes.Methods.GetSingle)]
        public async Task<IActionResult> GetSingleBloodType([FromQuery] GetSingleBloodTypeCommand command,
            CancellationToken cancellationToken)
        {
            var result = await mediator.Send(command, cancellationToken);
            return ApiResult(result);
        }

        [HttpPost(ApiRoutes.Methods.Submit)]
        public async Task<IActionResult> SubmitBloodType([FromBody] SubmitBloodTypeCommand command,
            CancellationToken cancellationToken)
        {
            var result = await mediator.Send(command, cancellationToken);
            return ApiResult(result);
        }

        [HttpDelete(ApiRoutes.Methods.Delete)]
        public async Task<IActionResult> DeleteBloodType([FromBody] DeleteBloodTypeCommand command,
            CancellationToken cancellationToken)
        {
            var result = await mediator.Send(command, cancellationToken);
            return ApiResult(result);
        }
    }
}
