using MediatR;
using Microsoft.AspNetCore.Mvc;
using ThePatho.Provider.ApiResponse;
using ThePatho.Features.PersonalInformation.EmployeeCareerHistory.Commands;
using Microsoft.AspNetCore.Authorization;

namespace ThePatho.Controllers
{
    [ApiController]
    [Route(ApiRoutes.PersonalInfoMenu.EmployeeCareerHistory)]
    [ApiExplorerSettings(GroupName = "PersonalInformation")]
    //[Authorize]
    public class EmployeeCareerHistoryController : ControllerBase
    {
        private readonly IMediator mediator;

        public EmployeeCareerHistoryController(IMediator _mediator)
        {
            mediator = _mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        private static IActionResult ApiResult<TResponse>(TResponse response) where TResponse : ApiResponse
        {
            return new ApiResult<TResponse>(response);
        }

        [HttpPost(ApiRoutes.Methods.GetList)]
        public async Task<IActionResult> GetEmployeeCareerHistoryList([FromBody] GetEmployeeCareerHistoryCommand command,
            CancellationToken cancellationToken)
        {
            var result = await mediator.Send(command, cancellationToken);
            return ApiResult(result);
        }

        [HttpGet(ApiRoutes.Methods.GetByCriteria)]
        public async Task<IActionResult> GetEmployeeCareerHistoryByCriteria([FromQuery] GetEmployeeCareerHistoryByCriteriaCommand command,
            CancellationToken cancellationToken)
        {
            var result = await mediator.Send(command, cancellationToken);
            return ApiResult(result);
        }

        [HttpGet(ApiRoutes.Methods.GetSingle)]
        public async Task<IActionResult> GetSingleEmployeeCareerHistory([FromQuery] GetSingleEmployeeCareerHistoryCommand command,
            CancellationToken cancellationToken)
        {
            var result = await mediator.Send(command, cancellationToken);
            return ApiResult(result);
        }

        [HttpPost(ApiRoutes.Methods.Submit)]
        public async Task<IActionResult> SubmitEmployeeCareerHistory([FromBody] SubmitEmployeeCareerHistoryCommand command,
            CancellationToken cancellationToken)
        {
            var result = await mediator.Send(command, cancellationToken);
            return ApiResult(result);
        }

        [HttpDelete(ApiRoutes.Methods.Delete)]
        public async Task<IActionResult> DeleteEmployeeCareerHistory([FromBody] DeleteEmployeeCareerHistoryCommand command,
            CancellationToken cancellationToken)
        {
            var result = await mediator.Send(command, cancellationToken);
            return ApiResult(result);
        }

        [HttpGet(ApiRoutes.Methods.Export)]
        public async Task<IActionResult> ExportEmployeeCareerHistory([FromQuery] string type, CancellationToken cancellationToken)
        {
            var exportResponse = await mediator.Send(new ExportEmployeeCareerHistoryCommand { Type = type }, cancellationToken);

            if (exportResponse.Code != 200 || exportResponse.Data == null)
            {
                return ApiResult(exportResponse);
            }

            var contentType = exportResponse.Data.ContentType;
            return File(Convert.FromBase64String(exportResponse.Data.Base64Data), contentType, exportResponse.Data.FileName);
        }
    }
}
