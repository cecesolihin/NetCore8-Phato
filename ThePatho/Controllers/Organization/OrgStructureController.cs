using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using ThePatho.Domain.Models;
using ThePatho.Provider.ApiResponse;
using ThePatho.Features.Organization.OrgStructure.Commands;
using ThePatho.Features.Organization.OrgStructure.DTO;
using ThePatho.Features.Organization.OrgStructure.Service;

namespace ThePatho.Controllers
{
    [ApiController]
    [Route(ApiRoutes.OrganizationMenu.OrgStructure)]
    [ApiExplorerSettings(GroupName = "Organization")]
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
    }
}
