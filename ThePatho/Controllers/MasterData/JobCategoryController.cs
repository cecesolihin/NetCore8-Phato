using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Threading;
using ThePatho.Provider.ApiResponse;
using ThePatho.Features.MasterData.JobCategory.Commands;
using ThePatho.Features.MasterData.JobCategory.DTO;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;


namespace ThePatho.Controllers
{
    [ApiController]
    [Route(ApiRoutes.MasterDataMenu.JobCategory)]
    [ApiExplorerSettings(GroupName = "MasterData")]
    public class JobCategoryController : ControllerBase
    {
        private readonly IMediator mediator;

        public JobCategoryController(IMediator _mediator)
        {
            mediator = _mediator ?? throw new ArgumentNullException(nameof(mediator)); 
        }
        private static IActionResult ApiResult<TResponse>(TResponse response) where TResponse : ApiResponse
        {
            return new ApiResult<TResponse>(response);
        }

        [HttpPost(ApiRoutes.Methods.GetList)]
        public async Task<IActionResult> GetJobCategoryList([FromBody] GetJobCategoryCommand command,
            CancellationToken cancellationToken)
        {
            var result = await mediator.Send(command, cancellationToken);

            return ApiResult(result);
        }

        [HttpGet(ApiRoutes.Methods.GetByCriteria)]
        public async Task<IActionResult> GetJobCategoryByCriteria([FromQuery] GetJobCategoryByCriteriaCommand command,
            CancellationToken cancellationToken)
        {
            var result = await mediator.Send(command, cancellationToken);

            return ApiResult(result);
        }

        [HttpGet(ApiRoutes.Methods.GetDdl)]
        public async Task<IActionResult> GetJobCategoryDdl([FromQuery] GetJobCategoryDdlCommand command,
            CancellationToken cancellationToken)
        {
            var result = await mediator.Send(command, cancellationToken);

            return ApiResult(result);
        }

        [HttpPost(ApiRoutes.Methods.Submit)]
        public async Task<IActionResult> SubmitJobCategory([FromBody] SubmitJobCategoryCommand command, CancellationToken cancellationToken)
        {
            var result = await mediator.Send(command, cancellationToken);

            return ApiResult(result);
        }

        [HttpDelete(ApiRoutes.Methods.Delete)]
        public async Task<IActionResult> DeleteJobCategory([FromBody] DeleteJobCategoryCommand command, CancellationToken cancellationToken)
        {
            var result = await mediator.Send(command, cancellationToken);

            return ApiResult(result);
        }
    }
}
