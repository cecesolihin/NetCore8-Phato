using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using ThePatho.Domain.Models;
using ThePatho.Features.ConfigurationExtensions;
using ThePatho.Features.MasterSetting.ScoringSettingDetail.Commands;
using ThePatho.Features.MasterSetting.ScoringSettingDetail.DTO;
using ThePatho.Features.MasterSetting.ScoringSettingDetail.Service;

namespace ThePatho.Controllers
{
    [ApiController]
    [Route(ApiRoutes.MasterSettingMenu.ScoringSettingDetail)]
    [ApiExplorerSettings(GroupName = "MasterSetting")]
    public class ScoringSettingDetailController : ControllerBase
    {
        private readonly IMediator mediator;

        public ScoringSettingDetailController(IMediator _mediator)
        {
            mediator = _mediator ?? throw new ArgumentNullException(nameof(mediator)); 
        }

        [HttpPost(ApiRoutes.Methods.GetList)]
        public async Task<IActionResult> GetScoringSettingDetailList([FromBody] GetScoringSettingDetailCommand command,
            CancellationToken cancellationToken)
        {
            try
            {
                var result = await mediator.Send(command, cancellationToken);

                var response = new ApiResponse<List<ScoringSettingDetailDto>>(HttpStatusCode.OK, result.ScoringSettingDetailList, "Process Successed");

                return Ok(response);
            }
            catch (Exception ex)
            {
                var errorResponse = new ApiResponse<List<ScoringSettingDetailDto>>(HttpStatusCode.InternalServerError, null, "Internal Server Error", ex.Message);

                return StatusCode(StatusCodes.Status500InternalServerError, errorResponse);
            }
        }

        [HttpPost(ApiRoutes.Methods.GetByCriteria)]
        public async Task<IActionResult> GetScoringSettingDetailByCriteria([FromBody] GetScoringSettingDetailByCriteriaCommand command,
            CancellationToken cancellationToken)
        {
            try
            {
                var result = await mediator.Send(command, cancellationToken);

                var response = new ApiResponse<List<ScoringSettingDetailDto>>(HttpStatusCode.OK, result.ScoringSettingDetailList, "Process Successed");

                return Ok(response);
            }
            catch (Exception ex)
            {
                var errorResponse = new ApiResponse<ScoringSettingDetailDto>(HttpStatusCode.InternalServerError, null, "Internal Server Error", ex.Message);

                return StatusCode(StatusCodes.Status500InternalServerError, errorResponse);
            }
        }

        [HttpPost(ApiRoutes.Methods.GetDdl)]
        public async Task<IActionResult> GetScoringSettingDetailDdl([FromBody] GetScoringSettingDetailDdlCommand command,
            CancellationToken cancellationToken)
        {
            try
            {
                var result = await mediator.Send(command, cancellationToken);

                var response = new ApiResponse<List<ScoringSettingDetailDto>>(HttpStatusCode.OK, result.ScoringSettingDetailList, "Process Successed");

                return Ok(response);
            }
            catch (Exception ex)
            {
                var errorResponse = new ApiResponse<List<ScoringSettingDetailDto>>(HttpStatusCode.InternalServerError, null, "Internal Server Error", ex.Message);

                return StatusCode(StatusCodes.Status500InternalServerError, errorResponse);
            }
        }
    }
}
