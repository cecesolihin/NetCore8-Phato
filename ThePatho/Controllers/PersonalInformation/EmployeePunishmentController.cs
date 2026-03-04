using MediatR;
using Microsoft.AspNetCore.Mvc;
using ThePatho.Provider.ApiResponse;
using ThePatho.Features.PersonalInformation.EmployeePunishment.Commands;
using Microsoft.AspNetCore.Authorization;

namespace ThePatho.Controllers
{
    [ApiController]
    [Route(ApiRoutes.PersonalInfoMenu.EmployeePunishment)]
    [ApiExplorerSettings(GroupName = "PersonalInformation")]
    //[Authorize]
    public class EmployeePunishmentController : ControllerBase
    {
        private readonly IMediator mediator;

        public EmployeePunishmentController(IMediator _mediator)
        {
            mediator = _mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        private static IActionResult ApiResult<TResponse>(TResponse response) where TResponse : ApiResponse
        {
            return new ApiResult<TResponse>(response);
        }

        [HttpPost(ApiRoutes.Methods.GetList)]
        public async Task<IActionResult> GetEmployeePunishmentList([FromBody] GetEmployeePunishmentCommand command,
            CancellationToken cancellationToken)
        {
            var result = await mediator.Send(command, cancellationToken);
            return ApiResult(result);
        }

        [HttpGet(ApiRoutes.Methods.GetByCriteria)]
        public async Task<IActionResult> GetEmployeePunishmentByCriteria([FromQuery] GetEmployeePunishmentByCriteriaCommand command,
            CancellationToken cancellationToken)
        {
            var result = await mediator.Send(command, cancellationToken);
            return ApiResult(result);
        }

        [HttpGet(ApiRoutes.Methods.GetSingle)]
        public async Task<IActionResult> GetSingleEmployeePunishment([FromQuery] GetSingleEmployeePunishmentCommand command,
            CancellationToken cancellationToken)
        {
            var result = await mediator.Send(command, cancellationToken);
            return ApiResult(result);
        }

        [HttpPost(ApiRoutes.Methods.Submit)]
        public async Task<IActionResult> SubmitEmployeePunishment([FromBody] SubmitEmployeePunishmentCommand command,
            CancellationToken cancellationToken)
        {
            var result = await mediator.Send(command, cancellationToken);
            return ApiResult(result);
        }

        [HttpDelete(ApiRoutes.Methods.Delete)]
        public async Task<IActionResult> DeleteEmployeePunishment([FromBody] DeleteEmployeePunishmentCommand command,
            CancellationToken cancellationToken)
        {
            var result = await mediator.Send(command, cancellationToken);
            return ApiResult(result);
        }

        [HttpGet(ApiRoutes.Methods.Export)]
        public async Task<IActionResult> ExportEmployeePunishment([FromQuery] string type, CancellationToken cancellationToken)
        {
            var exportResponse = await mediator.Send(new ExportEmployeePunishmentCommand { Type = type }, cancellationToken);

            if (exportResponse.Code != 200 || exportResponse.Data == null)
            {
                return ApiResult(exportResponse);
            }

            var contentType = exportResponse.Data.ContentType;
            return File(Convert.FromBase64String(exportResponse.Data.Base64Data), contentType, exportResponse.Data.FileName);
        }
    }
}
