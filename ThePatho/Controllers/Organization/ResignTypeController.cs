using MediatR;
using Microsoft.AspNetCore.Mvc;
using ThePatho.Provider.ApiResponse;
using ThePatho.Features.Organization.ResignType.Commands;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.StaticFiles;
using ThePatho.Domain.Constants;

namespace ThePatho.Controllers
{
    [ApiController]
    [Route(ApiRoutes.OrganizationMenu.ResignType)]
    [ApiExplorerSettings(GroupName = "Organization")]
    [Authorize]
    public class ResignTypeController : ControllerBase
    {
        private readonly IMediator mediator;

        public ResignTypeController(IMediator _mediator)
        {
            mediator = _mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        private static IActionResult ApiResult<TResponse>(TResponse response) where TResponse : ApiResponse
        {
            return new ApiResult<TResponse>(response);
        }

        [HttpPost(ApiRoutes.Methods.GetList)]
        public async Task<IActionResult> GetResignTypeList([FromBody] GetResignTypeCommand command,
            CancellationToken cancellationToken)
        {
            var result = await mediator.Send(command, cancellationToken);
            return ApiResult(result);
        }

        [HttpGet(ApiRoutes.Methods.GetByCriteria)]
        public async Task<IActionResult> GetResignTypeByCriteria([FromQuery] GetResignTypeByCriteriaCommand command,
            CancellationToken cancellationToken)
        {
            var result = await mediator.Send(command, cancellationToken);
            return ApiResult(result);
        }

        [HttpGet(ApiRoutes.Methods.GetSingle)]
        public async Task<IActionResult> GetSingleResignType([FromQuery] GetSingleResignTypeCommand command,
            CancellationToken cancellationToken)
        {
            var result = await mediator.Send(command, cancellationToken);
            return ApiResult(result);
        }

        [HttpPost(ApiRoutes.Methods.Submit)]
        public async Task<IActionResult> SubmitResignType([FromBody] SubmitResignTypeCommand command,
            CancellationToken cancellationToken)
        {
            var result = await mediator.Send(command, cancellationToken);
            return ApiResult(result);
        }

        [HttpDelete(ApiRoutes.Methods.Delete)]
        public async Task<IActionResult> DeleteResignType([FromBody] DeleteResignTypeCommand command,
            CancellationToken cancellationToken)
        {
            var result = await mediator.Send(command, cancellationToken);
            return ApiResult(result);
        }

        [HttpGet(ApiRoutes.Methods.Export)]
        public async Task<IActionResult> ExportResignType([FromQuery] string type, CancellationToken cancellationToken)
        {
            var exportResponse = await mediator.Send(new ExportResignTypeCommand { Type = type }, cancellationToken);

            if (exportResponse.Code != 200 || exportResponse.Data == null || exportResponse.Data.Base64Data != null)
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

            return File(exportResponse.Data.Base64Data, contentType, exportResponse.Data.FileName);
        }
    }
}
