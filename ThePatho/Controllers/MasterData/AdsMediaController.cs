using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using ThePatho.Features.ConfigurationExtensions;
using ThePatho.Features.MasterData.AdsCategory.Commands;
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

        [HttpPost(ApiRoutes.Methods.GetList)]
        public async Task<IActionResult> GetAdsMediaList([FromBody] GetAdsMediaCommand command,
            CancellationToken cancellationToken)
        {
            try
            {
                var result = await mediator.Send(command, cancellationToken);

                var response = new ApiResponse<List<AdsMediaDto>>(HttpStatusCode.OK, result.AdsMediaList, "Process Successed");

                return Ok(response);
            }
            catch (Exception ex)
            {
                var errorResponse = new ApiResponse<List<AdsMediaDto>>(HttpStatusCode.InternalServerError, null, "Internal Server Error", ex.Message);

                return StatusCode(StatusCodes.Status500InternalServerError, errorResponse);
            }
        }

        [HttpPost(ApiRoutes.Methods.GetByCriteria)]
        public async Task<IActionResult> GetAdsMediaByCriteria([FromBody] GetAdsMediaByCriteriaCommand command,
            CancellationToken cancellationToken)
        {
            try
            {
                var result = await mediator.Send(command, cancellationToken);

                var response = new ApiResponse<AdsMediaDto>(HttpStatusCode.OK, result, "Process Successed");

                return Ok(response);
            }
            catch (Exception ex)
            {
                var errorResponse = new ApiResponse<AdsMediaDto>(HttpStatusCode.InternalServerError, null, "Internal Server Error", ex.Message);

                return StatusCode(StatusCodes.Status500InternalServerError, errorResponse);
            }
        }

        [HttpPost(ApiRoutes.Methods.GetDdl)]
        public async Task<IActionResult> GetAdsMediaDdl([FromBody] GetAdsMediaDdlCommand command,
            CancellationToken cancellationToken)
        {
            try
            {
                var result = await mediator.Send(command, cancellationToken);

                var response = new ApiResponse<List<AdsMediaDto>>(HttpStatusCode.OK, result.AdsMediaList, "Process Successed");

                return Ok(response);
            }
            catch (Exception ex)
            {
                var errorResponse = new ApiResponse<List<AdsMediaDto>>(HttpStatusCode.InternalServerError, null, "Internal Server Error", ex.Message);

                return StatusCode(StatusCodes.Status500InternalServerError, errorResponse);
            }
        }
    }
}
