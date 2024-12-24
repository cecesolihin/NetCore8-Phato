using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using ThePatho.Domain.Models;
using ThePatho.Features.ConfigurationExtensions;
using ThePatho.Features.MasterSetting.QuestionSetting.Commands;
using ThePatho.Features.MasterSetting.QuestionSetting.DTO;
using ThePatho.Features.MasterSetting.QuestionSetting.Service;
using ThePatho.Features.MasterSetting.QuestionSettingDetail.Commands;

namespace ThePatho.Controllers
{
    [ApiController]
    [Route(ApiRoutes.MasterSettingMenu.QuestionSetting)]
    [ApiExplorerSettings(GroupName = "MasterSetting")]
    public class QuestionSettingController : ControllerBase
    {
        private readonly IMediator mediator;

        public QuestionSettingController(IMediator _mediator)
        {
            mediator = _mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        [HttpPost(ApiRoutes.Methods.GetList)]
        public async Task<IActionResult> GetQuestionSettingList([FromBody] GetQuestionSettingCommand command,
            CancellationToken cancellationToken)
        {
            try
            {
                var result = await mediator.Send(command, cancellationToken);

                var response = new ApiResponse<List<QuestionSettingDto>>(HttpStatusCode.OK, result.QuestionSettingList, "Process Successed");

                return Ok(response);
            }
            catch (Exception ex)
            {
                var errorResponse = new ApiResponse<List<QuestionSettingDto>>(HttpStatusCode.InternalServerError, null, "Internal Server Error", ex.Message);

                return StatusCode(StatusCodes.Status500InternalServerError, errorResponse);
            }
        }

        [HttpPost(ApiRoutes.Methods.GetByCriteria)]
        public async Task<IActionResult> GetQuestionSettingByCode([FromBody] GetQuestionSettingByCriteriaCommand command,
            CancellationToken cancellationToken)
        {
            try
            {
                var result = await mediator.Send(command, cancellationToken);

                var response = new ApiResponse<QuestionSettingDto>(HttpStatusCode.OK, result, "Process Successed");

                return Ok(response);
            }
            catch (Exception ex)
            {
                var errorResponse = new ApiResponse<QuestionSettingDto>(HttpStatusCode.InternalServerError, null, "Internal Server Error", ex.Message);

                return StatusCode(StatusCodes.Status500InternalServerError, errorResponse);
            }
        }

        [HttpPost(ApiRoutes.Methods.GetDdl)]
        public async Task<IActionResult> GetQuestionSettingDdl([FromBody] GetQuestionSettingDdlCommand command,
            CancellationToken cancellationToken)
        {
            try
            {
                var result = await mediator.Send(command, cancellationToken);

                var response = new ApiResponse<List<QuestionSettingDto>>(HttpStatusCode.OK, result.QuestionSettingList, "Process Successed");

                return Ok(response);
            }
            catch (Exception ex)
            {
                var errorResponse = new ApiResponse<List<QuestionSettingDto>>(HttpStatusCode.InternalServerError, null, "Internal Server Error", ex.Message);

                return StatusCode(StatusCodes.Status500InternalServerError, errorResponse);
            }
        }
    }
}
