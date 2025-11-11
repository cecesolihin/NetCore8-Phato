using MediatR;
using Microsoft.AspNetCore.Mvc;
using ThePatho.Provider.ApiResponse;
using ThePatho.Features.PersonalInformation.EmployeeIdentity.Commands;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.StaticFiles;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace ThePatho.Controllers
{
    [ApiController]
    [Route(ApiRoutes.PersonalInfoMenu.EmployeeIdentity)]
    [ApiExplorerSettings(GroupName = "PersonalInformation")]
    //[Authorize]
    public class EmployeeIdentityController : ControllerBase
    {
        private readonly IMediator mediator;
        private readonly IConfiguration configuration;

        public EmployeeIdentityController(IMediator _mediator, IConfiguration _configuration)
        {
            mediator = _mediator ?? throw new ArgumentNullException(nameof(mediator));
            configuration = _configuration ?? throw new ArgumentNullException(nameof(configuration));
        }

        private static IActionResult ApiResult<TResponse>(TResponse response) where TResponse : ApiResponse
        {
            return new ApiResult<TResponse>(response);
        }

        [HttpPost(ApiRoutes.Methods.GetList)]
        public async Task<IActionResult> GetEmployeeIdentityList([FromBody] GetEmployeeIdentityCommand command,
            CancellationToken cancellationToken)
        {
            var result = await mediator.Send(command, cancellationToken);
            return ApiResult(result);
        }

        [HttpGet(ApiRoutes.Methods.GetByCriteria)]
        public async Task<IActionResult> GetEmployeeIdentityByCriteria([FromQuery] GetEmployeeIdentityByCriteriaCommand command,
            CancellationToken cancellationToken)
        {
            var result = await mediator.Send(command, cancellationToken);
            return ApiResult(result);
        }

        [HttpGet(ApiRoutes.Methods.GetSingle)]
        public async Task<IActionResult> GetSingleEmployeeIdentity([FromQuery] GetSingleEmployeeIdentityCommand command,
            CancellationToken cancellationToken)
        {
            var result = await mediator.Send(command, cancellationToken);
            return ApiResult(result);
        }

        [HttpPost(ApiRoutes.Methods.Submit)]
        public async Task<IActionResult> SubmitEmployeeIdentity([FromBody] SubmitEmployeeIdentityCommand command,
            CancellationToken cancellationToken)
        {
            var result = await mediator.Send(command, cancellationToken);
            return ApiResult(result);
        }

        [HttpDelete(ApiRoutes.Methods.Delete)]
        public async Task<IActionResult> DeleteEmployeeIdentity([FromBody] DeleteEmployeeIdentityCommand command,
            CancellationToken cancellationToken)
        {
            var result = await mediator.Send(command, cancellationToken);
            return ApiResult(result);
        }

        [HttpGet(ApiRoutes.Methods.Download)]
        public async Task<IActionResult> DownloadEmployeeIdentity([FromQuery] GetSingleEmployeeIdentityCommand command,
            CancellationToken cancellationToken)
        {
            var single = await mediator.Send(command, cancellationToken);
            if (single.Code != 200 || single.Data == null || string.IsNullOrWhiteSpace(single.Data.FileFullPath))
            {
                return NotFound("File path not available for the requested identity.");
            }

            var configuredRoot = configuration["DocumentRootPath"];
            var baseRoot = string.IsNullOrWhiteSpace(configuredRoot) ? Directory.GetCurrentDirectory() : configuredRoot;

            var relativePath = single.Data.FileFullPath.Replace("~/", string.Empty).Replace("~\\", string.Empty);
            var physicalPath = Path.Combine(baseRoot, relativePath.Replace('/', Path.DirectorySeparatorChar));

            if (!System.IO.File.Exists(physicalPath))
            {
                return NotFound("File not found.");
            }

            var provider = new FileExtensionContentTypeProvider();
            if (!provider.TryGetContentType(single.Data.FileName, out var contentType))
            {
                contentType = "application/octet-stream";
            }

            return PhysicalFile(physicalPath, contentType, single.Data.FileName);
        }
    }
}
