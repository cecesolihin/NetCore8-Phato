using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ThePatho.Provider.ApiResponse;
using ThePatho.Features.Organization.OrgStructure.Commands;
using Microsoft.AspNetCore.StaticFiles;
using ThePatho.Domain.Constants;

namespace ThePatho.Controllers
{
    [ApiController]
    [Route(ApiRoutes.OrganizationMenu.OrgStructure)]
    [ApiExplorerSettings(GroupName = "Organization")]
    //[Authorize]
    public class OrgStructureController : ControllerBase
    {
        private readonly IMediator mediator;

        public OrgStructureController(IMediator _mediator)
        {
            mediator = _mediator ?? throw new ArgumentNullException(nameof(mediator)); 
        }
        private static IActionResult ApiResult<TResponse>(TResponse response) where TResponse : ApiResponse
        {
            return new ApiResult<TResponse>(response);
        }

        [HttpPost(ApiRoutes.Methods.GetList)]
        public async Task<IActionResult> GetOrgStructureList([FromBody] GetOrgStructureCommand command,
            CancellationToken cancellationToken)
        {
            var result = await mediator.Send(command, cancellationToken);

            return ApiResult(result);
        }

        [HttpGet(ApiRoutes.Methods.GetByCriteria)]
        public async Task<IActionResult> GetOrgStructureByCriteria([FromQuery] GetOrgStructureByCriteriaCommand command,
            CancellationToken cancellationToken)
        {
            var result = await mediator.Send(command, cancellationToken);

            return ApiResult(result);
        }

        [HttpGet(ApiRoutes.Methods.GetSingle)]
        public async Task<IActionResult> GetSingleOrgStructure([FromQuery] GetSingleOrgStructureCommand command,
            CancellationToken cancellationToken)
        {
            var result = await mediator.Send(command, cancellationToken);

            return ApiResult(result);
        }

        [HttpPost(ApiRoutes.Methods.Submit)]
        public async Task<IActionResult> SubmitOrgStructure([FromBody] SubmitOrgStructureCommand command, CancellationToken cancellationToken)
        {
            var result = await mediator.Send(command, cancellationToken);

            return ApiResult(result);
        }

        [HttpDelete(ApiRoutes.Methods.Delete)]
        public async Task<IActionResult> DeleteOrgStructure([FromBody] DeleteOrgStructureCommand command, CancellationToken cancellationToken)
        {
            var result = await mediator.Send(command, cancellationToken);

            return ApiResult(result);
        }

        [HttpGet(ApiRoutes.Methods.Export)]
        public async Task<IActionResult> ExportOrgStructure([FromQuery] string type, CancellationToken cancellationToken)
        {
            var exportResponse = await mediator.Send(new ExportOrgStructureCommand { Type = type }, cancellationToken);

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
    }
}
