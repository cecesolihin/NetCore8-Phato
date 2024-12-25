using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using ThePatho.Domain.Models;
using ThePatho.Features.ConfigurationExtensions;
using ThePatho.Features.MasterData.AdsCategory.Commands;
using ThePatho.Features.MasterData.AdsCategory.DTO;
using ThePatho.Features.MasterData.AdsCategory.Service;


namespace ThePatho.Controllers
{
    [ApiController]
    [Route(ApiRoutes.MasterDataMenu.AdsCategory)]
    [ApiExplorerSettings(GroupName = "MasterData")]
    public class AdsCategoryController : ControllerBase
    {
        private readonly IMediator mediator;

        public AdsCategoryController(IMediator _mediator)
        {
            mediator = _mediator ?? throw new ArgumentNullException(nameof(mediator)); 
        }

        [HttpPost(ApiRoutes.Methods.GetList)]
        public async Task<IActionResult> GetAdsCategoryList([FromBody] GetAdsCategoryCommand command,
            CancellationToken cancellationToken)
        {
            try
            {
                var result = await mediator.Send(command, cancellationToken);

                var response = new ApiResponse<List<AdsCategoryDto>>(HttpStatusCode.OK, result.AdsCategoryList, "Process Successed");

                return Ok(response);
            }
            catch (Exception ex)
            {
                var errorResponse = new ApiResponse<List<AdsCategoryDto>>(HttpStatusCode.InternalServerError, null, "Internal Server Error", ex.Message);

                return StatusCode(StatusCodes.Status500InternalServerError, errorResponse);
            }
        }

        [HttpPost(ApiRoutes.Methods.GetByCriteria)]
        public async Task<IActionResult> GetAdsCategoryByCriteria([FromBody] GetAdsCategoryByCriteriaCommand command,
            CancellationToken cancellationToken)
        {
            try
            {
                var result = await mediator.Send(command, cancellationToken);

                var response = new ApiResponse<AdsCategoryDto>(HttpStatusCode.OK, result, "Process Successed");

                return Ok(response);
            }
            catch (Exception ex)
            {
                var errorResponse = new ApiResponse<AdsCategoryDto>(HttpStatusCode.InternalServerError, null, "Internal Server Error", ex.Message);

                return StatusCode(StatusCodes.Status500InternalServerError, errorResponse);
            }
        }

        [HttpPost(ApiRoutes.Methods.GetDdl)]
        public async Task<IActionResult> GetAdsCategoryDdl([FromBody] GetAdsCategoryDdlCommand command,
            CancellationToken cancellationToken)
        {
            try
            {
                var result = await mediator.Send(command, cancellationToken);

                var response = new ApiResponse<List<AdsCategoryDto>>(HttpStatusCode.OK, result.AdsCategoryList, "Process Successed");

                return Ok(response);
            }
            catch (Exception ex)
            {
                var errorResponse = new ApiResponse<List<AdsCategoryDto>>(HttpStatusCode.InternalServerError, null, "Internal Server Error", ex.Message);

                return StatusCode(StatusCodes.Status500InternalServerError, errorResponse);
            }
        }

        //[HttpPut("{code}")]
        //public async Task<IActionResult> Update(string code, AdsCategoryDto AdsCategory)
        //{
        //    if (code != AdsCategory.AdsCategoryCode) return BadRequest();

        //    var updatedAdsCategory = await _AdsCategoryService.UpdateAdsCategoryAsync(AdsCategory);
        //    if (updatedAdsCategory == null) return NotFound();

        //    return Ok(updatedAdsCategory);
        //}

        //[HttpDelete("{code}")]
        //public async Task<IActionResult> Delete(string code)
        //{
        //    var success = await _AdsCategoryService.DeleteAdsCategoryAsync(code);
        //    if (!success) return NotFound();

        //    return NoContent();
        //}
    }
}
