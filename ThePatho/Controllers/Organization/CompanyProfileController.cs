using MediatR;
using Microsoft.AspNetCore.Mvc;
using ThePatho.Provider.ApiResponse;
using ThePatho.Features.Organization.CompanyProfile.Commands;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.StaticFiles;
using ThePatho.Domain.Constants;

namespace ThePatho.Controllers
{
    [ApiController]
    [Route(ApiRoutes.OrganizationMenu.CompanyProfile)]
    [ApiExplorerSettings(GroupName = "Organization")]
    //[Authorize]
    public class CompanyProfileController : ControllerBase
    {
        private readonly IMediator mediator;

        public CompanyProfileController(IMediator _mediator)
        {
            mediator = _mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        private static IActionResult ApiResult<TResponse>(TResponse response) where TResponse : ApiResponse
        {
            return new ApiResult<TResponse>(response);
        }

        [HttpPost(ApiRoutes.Methods.GetList)]
        public async Task<IActionResult> GetCompanyProfileList([FromBody] GetCompanyProfileCommand command,
            CancellationToken cancellationToken)
        {
            var result = await mediator.Send(command, cancellationToken);
            return ApiResult(result);
        }

        [HttpGet(ApiRoutes.Methods.GetByCriteria)]
        public async Task<IActionResult> GetCompanyProfileByCriteria([FromQuery] GetCompanyProfileByCriteriaCommand command,
            CancellationToken cancellationToken)
        {
            var result = await mediator.Send(command, cancellationToken);
            return ApiResult(result);
        }

        [HttpGet(ApiRoutes.Methods.GetSingle)]
        public async Task<IActionResult> GetSingleCompanyProfile([FromQuery] GetSingleCompanyProfileCommand command,
            CancellationToken cancellationToken)
        {
            var result = await mediator.Send(command, cancellationToken);
            return ApiResult(result);
        }

        [HttpPost(ApiRoutes.Methods.Submit)]
        public async Task<IActionResult> SubmitCompanyProfile([FromBody] SubmitCompanyProfileCommand command,
            CancellationToken cancellationToken)
        {
            var result = await mediator.Send(command, cancellationToken);
            return ApiResult(result);
        }

        [HttpDelete(ApiRoutes.Methods.Delete)]
        public async Task<IActionResult> DeleteCompanyProfile([FromBody] DeleteCompanyProfileCommand command,
            CancellationToken cancellationToken)
        {
            var result = await mediator.Send(command, cancellationToken);
            return ApiResult(result);
        }

        [HttpGet(ApiRoutes.Methods.Export)]
        public async Task<IActionResult> ExportCompanyProfile([FromQuery] string type, CancellationToken cancellationToken)
        {
            var exportResponse = await mediator.Send(new ExportCompanyProfileCommand { Type = type }, cancellationToken);

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
