using MediatR;
using Microsoft.AspNetCore.Mvc;
using ThePatho.Provider.ApiResponse;
using ThePatho.Features.PersonalInformation.EmployeeFamily.Commands;
using Microsoft.AspNetCore.Authorization;

namespace ThePatho.Controllers
{
    [ApiController]
    [Route(ApiRoutes.PersonalInfoMenu.EmployeeFamily)]
    [ApiExplorerSettings(GroupName = "PersonalInformation")]
    //[Authorize]
    public class EmployeeFamilyController : ControllerBase
    {
        private readonly IMediator mediator;

        public EmployeeFamilyController(IMediator _mediator)
        {
            mediator = _mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        private static IActionResult ApiResult<TResponse>(TResponse response) where TResponse : ApiResponse
        {
            return new ApiResult<TResponse>(response);
        }

        [HttpPost(ApiRoutes.Methods.GetList)]
        public async Task<IActionResult> GetEmployeeFamilyList([FromBody] GetEmployeeFamilyCommand command,
            CancellationToken cancellationToken)
        {
            var result = await mediator.Send(command, cancellationToken);
            return ApiResult(result);
        }

        [HttpGet(ApiRoutes.Methods.GetByCriteria)]
        public async Task<IActionResult> GetEmployeeFamilyByCriteria([FromQuery] GetEmployeeFamilyByCriteriaCommand command,
            CancellationToken cancellationToken)
        {
            var result = await mediator.Send(command, cancellationToken);
            return ApiResult(result);
        }

        [HttpGet(ApiRoutes.Methods.GetSingle)]
        public async Task<IActionResult> GetSingleEmployeeFamily([FromQuery] GetSingleEmployeeFamilyCommand command,
            CancellationToken cancellationToken)
        {
            var result = await mediator.Send(command, cancellationToken);
            return ApiResult(result);
        }

        [HttpPost(ApiRoutes.Methods.Submit)]
        public async Task<IActionResult> SubmitEmployeeFamily([FromBody] SubmitEmployeeFamilyCommand command,
            CancellationToken cancellationToken)
        {
            var result = await mediator.Send(command, cancellationToken);
            return ApiResult(result);
        }

        [HttpDelete(ApiRoutes.Methods.Delete)]
        public async Task<IActionResult> DeleteEmployeeFamily([FromBody] DeleteEmployeeFamilyCommand command,
            CancellationToken cancellationToken)
        {
            var result = await mediator.Send(command, cancellationToken);
            return ApiResult(result);
        }

        [HttpGet(ApiRoutes.Methods.Export)]
        public async Task<IActionResult> ExportEmployeeFamily([FromQuery] string type, CancellationToken cancellationToken)
        {
            var exportResponse = await mediator.Send(new ExportEmployeeFamilyCommand { Type = type }, cancellationToken);

            if (exportResponse.Code != 200 || exportResponse.Data == null)
            {
                return ApiResult(exportResponse);
            }

            var contentType = exportResponse.Data.ContentType;
            return File(Convert.FromBase64String(exportResponse.Data.Base64Data), contentType, exportResponse.Data.FileName);
        }
    }
}
