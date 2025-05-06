using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using ThePatho.Provider.ApiResponse;
using ThePatho.Features.MasterData.AdsMedia.Commands;
using ThePatho.Features.MasterData.AdsMedia.DTO;


namespace ThePatho.Controllers
{
    [ApiController]
    [Route(ApiRoutes.MasterDataMenu.AdsMedia)]
    [ApiExplorerSettings(GroupName = "MasterData")]
    public class AdsMediaController : ControllerBase
    {
        private readonly IMediator mediator;

        public AdsMediaController(IMediator _mediator)
        {
            mediator = _mediator ?? throw new ArgumentNullException(nameof(mediator)); 
        }

        private static IActionResult ApiResult<TResponse>(TResponse response) where TResponse : ApiResponse
        {
            return new ApiResult<TResponse>(response);
        }

        [HttpPost(ApiRoutes.Methods.GetList)]
        public async Task<IActionResult> GetAdsMediaList([FromBody] GetAdsMediaCommand command,
            CancellationToken cancellationToken)
        {
            var result = await mediator.Send(command, cancellationToken);

            return ApiResult(result);
        }

        [HttpGet(ApiRoutes.Methods.GetByCriteria)]
        public async Task<IActionResult> GetAdsMediaByCriteria([FromQuery] GetAdsMediaByCriteriaCommand command,
            CancellationToken cancellationToken)
        {
            var result = await mediator.Send(command, cancellationToken);

            return ApiResult(result);
        }

        [HttpGet(ApiRoutes.Methods.GetDdl)]
        public async Task<IActionResult> GetAdsMediaDdl([FromQuery] GetAdsMediaDdlCommand command,
            CancellationToken cancellationToken)
        {
            var result = await mediator.Send(command, cancellationToken);

            return ApiResult(result);
        }
        [HttpPost(ApiRoutes.Methods.Submit)]
        public async Task<IActionResult> SubmitAdsMedia([FromBody] SubmitAdsMediaCommand command, CancellationToken cancellationToken)
        {
            var result = await mediator.Send(command, cancellationToken);

            return ApiResult(result);
        }

        [HttpDelete(ApiRoutes.Methods.Delete)]
        public async Task<IActionResult> DeleteAdsMedia([FromBody] DeleteAdsMediaCommand command, CancellationToken cancellationToken)
        {
            var result = await mediator.Send(command, cancellationToken);

            return ApiResult(result);
        }
    }
}
