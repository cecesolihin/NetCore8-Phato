using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.StaticFiles;
using ThePatho.Provider.ApiResponse;
using ThePatho.Features.Organization.Grade.Commands;
using ThePatho.Domain.Constants;

namespace ThePatho.Controllers
{
    [ApiController]
    [Route(ApiRoutes.BaseApiPathOrganization + "export")]
    [ApiExplorerSettings(GroupName = "Organization")]
    public class OrganizationExportController : ControllerBase
    {
        private readonly IMediator mediator;

        public OrganizationExportController(IMediator _mediator)
        {
            mediator = _mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        private static IActionResult ApiResult<TResponse>(TResponse response) where TResponse : ApiResponse
        {
            return new ApiResult<TResponse>(response);
        }

        // GET: api/organization/export/{menu}/download?type=excel|pdf
        [HttpGet("{menu}/" + ApiRoutes.Methods.Export)]
        public async Task<IActionResult> ExportOrganizationMenu([FromRoute] string menu, [FromQuery] string type, CancellationToken cancellationToken)
        {
            if (string.IsNullOrWhiteSpace(menu))
            {
                return ApiResult(new ApiResponse<string>(System.Net.HttpStatusCode.BadRequest, "Menu tidak boleh kosong"));
            }

            // Saat ini mendukung 'grade' terlebih dahulu. Menu lain dapat ditambahkan kemudian.
            switch (menu.Trim().ToLowerInvariant())
            {
                case "grade":
                {
                    var exportResponse = await mediator.Send(new ExportGradeCommand { Type = type }, cancellationToken);

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
                default:
                    return ApiResult(new ApiResponse<string>(System.Net.HttpStatusCode.BadRequest, $"Menu '{menu}' belum didukung untuk export."));
            }
        }
    }
}