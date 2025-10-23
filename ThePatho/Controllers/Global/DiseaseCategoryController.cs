using MediatR;
using Microsoft.AspNetCore.Mvc;
using ThePatho.Provider.ApiResponse;
using Microsoft.AspNetCore.Authorization;
using ThePatho.Features.Global.DiseaseCategory.Commands;

namespace ThePatho.Controllers.Global
{
    [ApiController]
    [Route(ApiRoutes.GlobalMenu.DiseaseCategory)]
    [ApiExplorerSettings(GroupName = "Global")]
    [Authorize]
    public class DiseaseCategoryController : ControllerBase
    {
        private readonly IMediator mediator;

        public DiseaseCategoryController(IMediator _mediator)
        {
            mediator = _mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        private static IActionResult ApiResult<TResponse>(TResponse response) where TResponse : ApiResponse
        {
            return new ApiResult<TResponse>(response);
        }

        [HttpPost(ApiRoutes.Methods.GetList)]
        public async Task<IActionResult> GetDiseaseCategoryList([FromBody] GetDiseaseCategoryCommand command,
            CancellationToken cancellationToken)
        {
            var result = await mediator.Send(command, cancellationToken);
            return ApiResult(result);
        }

        [HttpGet(ApiRoutes.Methods.GetByCriteria)]
        public async Task<IActionResult> GetDiseaseCategoryByCriteria([FromQuery] GetDiseaseCategoryByCriteriaCommand command,
            CancellationToken cancellationToken)
        {
            var result = await mediator.Send(command, cancellationToken);
            return ApiResult(result);
        }

        [HttpGet(ApiRoutes.Methods.GetSingle)]
        public async Task<IActionResult> GetSingleDiseaseCategory([FromQuery] GetSingleDiseaseCategoryCommand command,
            CancellationToken cancellationToken)
        {
            var result = await mediator.Send(command, cancellationToken);
            return ApiResult(result);
        }

        [HttpPost(ApiRoutes.Methods.Submit)]
        public async Task<IActionResult> SubmitDiseaseCategory([FromBody] SubmitDiseaseCategoryCommand command,
            CancellationToken cancellationToken)
        {
            var result = await mediator.Send(command, cancellationToken);
            return ApiResult(result);
        }

        [HttpDelete(ApiRoutes.Methods.Delete)]
        public async Task<IActionResult> DeleteDiseaseCategory([FromBody] DeleteDiseaseCategoryCommand command,
            CancellationToken cancellationToken)
        {
            var result = await mediator.Send(command, cancellationToken);
            return ApiResult(result);
        }
    }
}
