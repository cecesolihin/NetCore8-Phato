using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using ThePatho.Domain.Models;
using ThePatho.Features.ConfigurationExtensions;
using ThePatho.Features.MasterSetting.ScoringSetting.Commands;
using ThePatho.Features.MasterSetting.ScoringSetting.DTO;
using ThePatho.Features.MasterSetting.ScoringSetting.Service;

namespace ThePatho.Controllers
{
    [ApiController]
    [Route(ApiRoutes.MasterSettingMenu.ScoringSetting)]
    [ApiExplorerSettings(GroupName = "MasterSetting")]
    public class ScoringSettingController : ControllerBase
    {
        private readonly IMediator mediator;

        public ScoringSettingController(IMediator _mediator)
        {
            mediator = _mediator ?? throw new ArgumentNullException(nameof(mediator)); 
        }

        [HttpPost(ApiRoutes.Methods.GetList)]
        public async Task<IActionResult> GetScoringSettingList([FromBody] GetScoringSettingCommand command,
            CancellationToken cancellationToken)
        {
            try
            {
                var result = await mediator.Send(command, cancellationToken);

                var response = new ApiResponse<List<ScoringSettingDto>>(HttpStatusCode.OK, result.ScoringSettingList, "Process Successed");

                return Ok(response);
            }
            catch (Exception ex)
            {
                var errorResponse = new ApiResponse<List<ScoringSettingDto>>(HttpStatusCode.InternalServerError, null, "Internal Server Error", ex.Message);

                return StatusCode(StatusCodes.Status500InternalServerError, errorResponse);
            }
        }

        [HttpPost(ApiRoutes.Methods.GetByCriteria)]
        public async Task<IActionResult> GetScoringSettingByCriteria([FromBody] GetScoringSettingByCriteriaCommand command,
            CancellationToken cancellationToken)
        {
            try
            {
                var result = await mediator.Send(command, cancellationToken);

                var response = new ApiResponse<ScoringSettingDto>(HttpStatusCode.OK, result, "Process Successed");

                return Ok(response);
            }
            catch (Exception ex)
            {
                var errorResponse = new ApiResponse<ScoringSettingDto>(HttpStatusCode.InternalServerError, null, "Internal Server Error", ex.Message);

                return StatusCode(StatusCodes.Status500InternalServerError, errorResponse);
            }
        }

        [HttpPost(ApiRoutes.Methods.GetDdl)]
        public async Task<IActionResult> GetScoringSettingDdl([FromBody] GetScoringSettingDdlCommand command,
            CancellationToken cancellationToken)
        {
            try
            {
                var result = await mediator.Send(command, cancellationToken);

                var response = new ApiResponse<List<ScoringSettingDto>>(HttpStatusCode.OK, result.ScoringSettingList, "Process Successed");

                return Ok(response);
            }
            catch (Exception ex)
            {
                var errorResponse = new ApiResponse<List<ScoringSettingDto>>(HttpStatusCode.InternalServerError, null, "Internal Server Error", ex.Message);

                return StatusCode(StatusCodes.Status500InternalServerError, errorResponse);
            }
        }
    }
}
