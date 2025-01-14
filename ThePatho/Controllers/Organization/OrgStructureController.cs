using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using ThePatho.Domain.Models;
using ThePatho.Features.ConfigurationExtensions;
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

        [HttpPost(ApiRoutes.Methods.GetList)]
        public async Task<IActionResult> GetOrgStructureList([FromBody] GetOrgStructureCommand command,
            CancellationToken cancellationToken)
        {
            try
            {
                var result = await mediator.Send(command, cancellationToken);

                var response = new ApiResponse<List<OrgStructureDto>>(HttpStatusCode.OK, result.OrgStructureList, "Process Successed");

                return Ok(response);
            }
            catch (Exception ex)
            {
                var errorResponse = new ApiResponse<List<OrgStructureDto>>(HttpStatusCode.InternalServerError, null, "Internal Server Error", ex.Message);

                return StatusCode(StatusCodes.Status500InternalServerError, errorResponse);
            }
        }

        [HttpGet(ApiRoutes.Methods.GetByCriteria)]
        public async Task<IActionResult> GetOrgStructureByCriteria([FromQuery] GetOrgStructureByCriteriaCommand command,
            CancellationToken cancellationToken)
        {
            try
            {
                var result = await mediator.Send(command, cancellationToken);

                var response = new ApiResponse<OrgStructureDto>(HttpStatusCode.OK, result, "Process Successed");

                return Ok(response);
            }
            catch (Exception ex)
            {
                var errorResponse = new ApiResponse<OrgStructureDto>(HttpStatusCode.InternalServerError, null, "Internal Server Error", ex.Message);

                return StatusCode(StatusCodes.Status500InternalServerError, errorResponse);
            }
        }

        [HttpPost(ApiRoutes.Methods.Submit)]
        public async Task<IActionResult> SubmitOrgStructure([FromBody] SubmitOrgStructureCommand command, CancellationToken cancellationToken)
        {
            try
            {
                var result = await mediator.Send(command, cancellationToken);

                var response = new ApiResponse<string>(
                    HttpStatusCode.OK,
                    result,
                    "Process succeeded"
                );

                return Ok(response);
            }
            catch (Exception ex)
            {
                var errorResponse = new ApiResponse<string>(
                    HttpStatusCode.InternalServerError,
                    null,
                    "Internal Server Error",
                    ex.Message
                );

                return StatusCode(StatusCodes.Status500InternalServerError, errorResponse);
            }
        }

        [HttpDelete(ApiRoutes.Methods.Delete)]
        public async Task<IActionResult> DeleteOrgStructure([FromBody] DeleteOrgStructureCommand command, CancellationToken cancellationToken)
        {
            try
            {
                var result = await mediator.Send(command, cancellationToken);

                if (result)
                {
                    var response = new ApiResponse<string>(HttpStatusCode.OK, command.OrgStructureCode, "Organization Structure deleted successfully");
                    return Ok(response);
                }
                else
                {
                    var errorResponse = new ApiResponse<string>(HttpStatusCode.InternalServerError, null, "Failed to delete Organization Structure");
                    return StatusCode(StatusCodes.Status500InternalServerError, errorResponse);
                }
            }
            catch (Exception ex)
            {
                var errorResponse = new ApiResponse<string>(HttpStatusCode.InternalServerError, null, "Internal Server Error", ex.Message);
                return StatusCode(StatusCodes.Status500InternalServerError, errorResponse);
            }
        }
    }
}
