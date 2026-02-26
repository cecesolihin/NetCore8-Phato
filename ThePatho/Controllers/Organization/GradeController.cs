using MediatR;
using Microsoft.AspNetCore.Mvc;
using ThePatho.Provider.ApiResponse;
using ThePatho.Features.Organization.Grade.Commands;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.StaticFiles;
using ThePatho.Domain.Constants;
using ThePatho.Features.Organization.Grade.DTO;

namespace ThePatho.Controllers
{
    [ApiController]
    [Route(ApiRoutes.OrganizationMenu.Grade)]
    [ApiExplorerSettings(GroupName = "Organization")]
    [Authorize]
    public class GradeController : ControllerBase
    {
        private readonly IMediator mediator;

        public GradeController(IMediator _mediator)
        {
            mediator = _mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        private static IActionResult ApiResult<TResponse>(TResponse response) where TResponse : ApiResponse
        {
            return new ApiResult<TResponse>(response);
        }

        [HttpPost(ApiRoutes.Methods.GetList)]
        public async Task<IActionResult> GetGradeList([FromBody] GetGradeCommand command,
            CancellationToken cancellationToken)
        {
            var result = await mediator.Send(command, cancellationToken);
            return ApiResult(result);
        }

        [HttpGet(ApiRoutes.Methods.GetByCriteria)]
        public async Task<IActionResult> GetGradeByCriteria([FromQuery] GetGradeByCriteriaCommand command,
            CancellationToken cancellationToken)
        {
            var result = await mediator.Send(command, cancellationToken);
            return ApiResult(result);
        }

        [HttpGet(ApiRoutes.Methods.GetSingle)]
        public async Task<IActionResult> GetSingleGrade([FromQuery] GetSingleGradeCommand command,
            CancellationToken cancellationToken)
        {
            var result = await mediator.Send(command, cancellationToken);
            return ApiResult(result);
        }

        [HttpPost(ApiRoutes.Methods.Submit)]
        public async Task<IActionResult> SubmitGrade([FromBody] SubmitGradeCommand command,
            CancellationToken cancellationToken)
        {
            var result = await mediator.Send(command, cancellationToken);
            return ApiResult(result);
        }

        [HttpDelete(ApiRoutes.Methods.Delete)]
        public async Task<IActionResult> DeleteGrade([FromBody] DeleteGradeCommand command,
            CancellationToken cancellationToken)
        {
            var result = await mediator.Send(command, cancellationToken);
            return ApiResult(result);
        }

        [HttpGet(ApiRoutes.Methods.Download_template)]
        public async Task<IActionResult> DownloadGradeTemplate(CancellationToken cancellationToken)
        {
            var templateResponse = await mediator.Send(new DownloadGradeTemplateCommand(), cancellationToken);

            if (templateResponse.Code != 200 || templateResponse.Data == null || templateResponse.Data.FileBytes.Length == 0)
            {
                return ApiResult(templateResponse);
            }

            var contentType = templateResponse.Data.ContentType;
            if (string.IsNullOrWhiteSpace(contentType))
            {
                var provider = new FileExtensionContentTypeProvider();
                if (!provider.TryGetContentType(templateResponse.Data.FileName, out contentType))
                {
                    contentType = MimeTypesConstants.APPLICATION_OCTET_STREAM;
                }
            }

            return File(templateResponse.Data.FileBytes, contentType, templateResponse.Data.FileName);
        }

        [HttpGet(ApiRoutes.Methods.Export)]
        public async Task<IActionResult> ExportGrade([FromQuery] string type, CancellationToken cancellationToken)
        {
            var exportResponse = await mediator.Send(new ExportGradeCommand { Type = type }, cancellationToken);

            if (exportResponse.Code != 200 || exportResponse.Data == null || exportResponse.Data.FileBytes.Length == 0)
            {
                return ApiResult(exportResponse);
            }

            var contentType = exportResponse.Data.ContentType;
            if (string.IsNullOrWhiteSpace(contentType))
            {
                var provider = new FileExtensionContentTypeProvider();
                if (!provider.TryGetContentType(exportResponse.Data.FileName, out contentType))
                {
                    contentType = MimeTypesConstants.APPLICATION_OCTET_STREAM;
                }
            }

            return File(exportResponse.Data.FileBytes, contentType, exportResponse.Data.FileName);
        }

        [HttpPost(ApiRoutes.Methods.upload)]
        public async Task<IActionResult> UploadGradeTemplate([FromForm] IFormFile file, CancellationToken cancellationToken)
        {
            if (file == null || file.Length == 0)
            {
                return ApiResult(new ApiResponse<string>(System.Net.HttpStatusCode.BadRequest, "File not found"));
            }

            using var ms = new MemoryStream();
            await file.CopyToAsync(ms, cancellationToken);
            var command = new UploadGradeTemplateCommand
            {
                FileBytes = ms.ToArray(),
                FileName = file.FileName
            };

            var result = await mediator.Send(command, cancellationToken);
            return ApiResult(result);
        }
    }
}
