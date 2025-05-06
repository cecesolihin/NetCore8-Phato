using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using ThePatho.Domain.Models;
using ThePatho.Provider.ApiResponse;
using ThePatho.Features.Organization.OrgLevel.Commands;
using ThePatho.Features.Organization.OrgLevel.DTO;
using ThePatho.Features.Organization.OrgLevel.Service;

namespace ThePatho.Controllers
{
    [ApiController]
    [Route(ApiRoutes.OrganizationMenu.OrgLevel)]
    [ApiExplorerSettings(GroupName = "Organization")]
    public class OrgLevelController : ControllerBase
    {
        private readonly IMediator mediator;

        public OrgLevelController(IMediator _mediator)
        {
            mediator = _mediator ?? throw new ArgumentNullException(nameof(mediator)); 
        }
        private static IActionResult ApiResult<TResponse>(TResponse response) where TResponse : ApiResponse
        {
            return new ApiResult<TResponse>(response);
        }

        [HttpPost(ApiRoutes.Methods.GetList)]
        public async Task<IActionResult> GetOrganizationLevelList([FromBody] GetOrgLevelCommand command,
            CancellationToken cancellationToken)
        {
            var result = await mediator.Send(command, cancellationToken);

            return ApiResult(result);
        }

        [HttpGet(ApiRoutes.Methods.GetByCriteria)]
        public async Task<IActionResult> GetOrganizationLevelByCriteria([FromQuery] GetOrgLevelByCriteriaCommand command,
            CancellationToken cancellationToken)
        {
            var result = await mediator.Send(command, cancellationToken);

            return ApiResult(result);
        }

        [HttpPost(ApiRoutes.Methods.Submit)]
        public async Task<IActionResult> SubmitOrganizationLevel([FromBody] SubmitOrgLevelCommand command, CancellationToken cancellationToken)
        {
            var result = await mediator.Send(command, cancellationToken);

            return ApiResult(result);
        }

        [HttpDelete(ApiRoutes.Methods.Delete)]
        public async Task<IActionResult> DeleteOrganizationLevel([FromBody] DeleteOrgLevelCommand command, CancellationToken cancellationToken)
        {
            var result = await mediator.Send(command, cancellationToken);

            return ApiResult(result);
        }
    }
}
