using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using ThePatho.Domain.Models;
using ThePatho.Features.ConfigurationExtensions;
using ThePatho.Features.MasterSetting.QuestionSetting.Commands;
using ThePatho.Features.MasterSetting.QuestionSettingDetail.Commands;
using ThePatho.Features.MasterSetting.QuestionSettingDetail.DTO;
using ThePatho.Features.MasterSetting.QuestionSettingDetail.Service;

namespace ThePatho.Controllers
{
    [ApiController]
    [Route(ApiRoutes.MasterSettingMenu.QuestionSettingDetail)]
    [ApiExplorerSettings(GroupName = "MasterSetting")]
    public class QuestionSettingDetailController : ControllerBase
    {
        private readonly IMediator mediator;

        public QuestionSettingDetailController(IMediator _mediator)
        {
            mediator = _mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        [HttpPost(ApiRoutes.Methods.GetList)]
        public async Task<IActionResult> GetQuestionSettingDetailList([FromBody] GetQuestionSettingDetailCommand command,
            CancellationToken cancellationToken)
        {
            try
            {
                var result = await mediator.Send(command, cancellationToken);

                var response = new ApiResponse<List<QuestionSettingDetailDto>>(HttpStatusCode.OK, result.QuestionSettingDetailList, "Process Successed");

                return Ok(response);
            }
            catch (Exception ex)
            {
                var errorResponse = new ApiResponse<List<QuestionSettingDetailDto>>(HttpStatusCode.InternalServerError, null, "Internal Server Error", ex.Message);

                return StatusCode(StatusCodes.Status500InternalServerError, errorResponse);
            }
        }

        [HttpPost(ApiRoutes.Methods.GetByCriteria)]
        public async Task<IActionResult> GetQuestionSettingDetailByCode([FromBody] GetQuestionSettingDetailByCriteriaCommand command,
            CancellationToken cancellationToken)
        {
            try
            {
                var result = await mediator.Send(command, cancellationToken);

                var response = new ApiResponse<List<QuestionSettingDetailDto>>(HttpStatusCode.OK, result.QuestionSettingDetailList, "Process Successed");

                return Ok(response);
            }
            catch (Exception ex)
            {
                var errorResponse = new ApiResponse<QuestionSettingDetailDto>(HttpStatusCode.InternalServerError, null, "Internal Server Error", ex.Message);

                return StatusCode(StatusCodes.Status500InternalServerError, errorResponse);
            }
        }

        [HttpPost(ApiRoutes.Methods.GetDdl)]
        public async Task<IActionResult> GetQuestionSettingDetailDdl([FromBody] GetQuestionSettingDetailDdlCommand command,
            CancellationToken cancellationToken)
        {
            try
            {
                var result = await mediator.Send(command, cancellationToken);

                var response = new ApiResponse<List<QuestionSettingDetailDto>>(HttpStatusCode.OK, result.QuestionSettingDetailList, "Process Successed");

                return Ok(response);
            }
            catch (Exception ex)
            {
                var errorResponse = new ApiResponse<List<QuestionSettingDetailDto>>(HttpStatusCode.InternalServerError, null, "Internal Server Error", ex.Message);

                return StatusCode(StatusCodes.Status500InternalServerError, errorResponse);
            }
        }
    }
}
