using MediatR;
using Microsoft.AspNetCore.Mvc;
using ThePatho.Provider.ApiResponse;
using ThePatho.Features.PersonalInformation.SuperiorSubordinate.Commands;
using Microsoft.AspNetCore.Authorization;

namespace ThePatho.Controllers
{
    [ApiController]
    [Route(ApiRoutes.PersonalInfoMenu.SuperiorSubordinate)]
    [ApiExplorerSettings(GroupName = "PersonalInformation")]
    //[Authorize]
    public class SuperiorSubordinateController : ControllerBase
    {
        private readonly IMediator mediator;

        public SuperiorSubordinateController(IMediator _mediator)
        {
            mediator = _mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        private static IActionResult ApiResult<TResponse>(TResponse response) where TResponse : ApiResponse
        {
            return new ApiResult<TResponse>(response);
        }

        [HttpPost(ApiRoutes.Methods.GetList)]
        public async Task<IActionResult> GetSuperiorSubordinateList([FromBody] GetSuperiorSubordinateCommand command,
            CancellationToken cancellationToken)
        {
            var result = await mediator.Send(command, cancellationToken);
            return ApiResult(result);
        }

        [HttpGet(ApiRoutes.Methods.GetByCriteria)]
        public async Task<IActionResult> GetSuperiorSubordinateByCriteria([FromQuery] GetSuperiorSubordinateByCriteriaCommand command,
            CancellationToken cancellationToken)
        {
            var result = await mediator.Send(command, cancellationToken);
            return ApiResult(result);
        }

        [HttpGet(ApiRoutes.Methods.GetSingle)]
        public async Task<IActionResult> GetSingleSuperiorSubordinate([FromQuery] GetSingleSuperiorSubordinateCommand command,
            CancellationToken cancellationToken)
        {
            var result = await mediator.Send(command, cancellationToken);
            return ApiResult(result);
        }

        [HttpPost(ApiRoutes.Methods.Submit)]
        public async Task<IActionResult> SubmitSuperiorSubordinate([FromBody] SubmitSuperiorSubordinateCommand command,
            CancellationToken cancellationToken)
        {
            var result = await mediator.Send(command, cancellationToken);
            return ApiResult(result);
        }
        [HttpPost(ApiRoutes.Methods.SubmitMulti)]
        public async Task<IActionResult> SubmitMultiSuperiorSubordinate([FromBody] SubmitMultiSuperiorSubordinateCommand command,
            CancellationToken cancellationToken)
        {
            var result = await mediator.Send(command, cancellationToken);
            return ApiResult(result);
        }
        [HttpPost(ApiRoutes.Methods.generate)]
        public async Task<IActionResult> GenerateSuperiorSubordinate([FromBody] GenerateSuperiorSubordinateCommand command,
            CancellationToken cancellationToken)
        {
            var result = await mediator.Send(command, cancellationToken);
            return ApiResult(result);
        }

        [HttpDelete(ApiRoutes.Methods.Delete)]
        public async Task<IActionResult> DeleteSuperiorSubordinate([FromBody] DeleteSuperiorSubordinateCommand command,
            CancellationToken cancellationToken)
        {
            var result = await mediator.Send(command, cancellationToken);
            return ApiResult(result);
        }
    }
}
