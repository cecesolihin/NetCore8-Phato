using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using ThePatho.Features.ConfigurationExtensions;
using ThePatho.Features.Recruitment.MPP.Commands;
using ThePatho.Features.Recruitment.MPP.DTO;

namespace ThePatho.Controllers
{
    [ApiController]
    [Route(ApiRoutes.RecruitmentMenu.MPP)]
    [ApiExplorerSettings(GroupName = "Recruitment")]
    public class MPPController : ControllerBase
    {
        private readonly IMediator mediator;

        public MPPController(IMediator _mediator)
        {
            mediator = _mediator ?? throw new ArgumentNullException(nameof(mediator)); 
        }

        [HttpPost(ApiRoutes.Methods.GetList)]
        public async Task<IActionResult> GetMPPList([FromBody] GetMPPCommand command,
            CancellationToken cancellationToken)
        {
            try
            {
                var result = await mediator.Send(command, cancellationToken);

                var response = new ApiResponse<List<MPPDto>>(HttpStatusCode.OK, result.MPPList, "Process Successed");

                return Ok(response);
            }
            catch (Exception ex)
            {
                var errorResponse = new ApiResponse<List<MPPDto>>(HttpStatusCode.InternalServerError, null, "Internal Server Error", ex.Message);

                return StatusCode(StatusCodes.Status500InternalServerError, errorResponse);
            }
        }

        [HttpGet(ApiRoutes.Methods.GetByCriteria)]
        public async Task<IActionResult> GetMPPByCriteria([FromQuery] GetMPPByCriteriaCommand command,
            CancellationToken cancellationToken)
        {
            try
            {
                var result = await mediator.Send(command, cancellationToken);

                var response = new ApiResponse<MPPDto>(HttpStatusCode.OK, result, "Process Successed");

                return Ok(response);
            }
            catch (Exception ex)
            {
                var errorResponse = new ApiResponse<MPPDto>(HttpStatusCode.InternalServerError, null, "Internal Server Error", ex.Message);

                return StatusCode(StatusCodes.Status500InternalServerError, errorResponse);
            }
        }

        [HttpPost(ApiRoutes.Methods.Submit)]
        public async Task<IActionResult> SubmitMPP([FromBody] SubmitMPPCommand command, CancellationToken cancellationToken)
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
        public async Task<IActionResult> DeleteMPP([FromBody] DeleteMPPCommand command, CancellationToken cancellationToken)
        {
            try
            {
                var result = await mediator.Send(command, cancellationToken);

                if (result)
                {
                    var response = new ApiResponse<string>(HttpStatusCode.OK, command.MPPNo, "MPP deleted successfully");
                    return Ok(response);
                }
                else
                {
                    var errorResponse = new ApiResponse<string>(HttpStatusCode.InternalServerError, null, "Failed to delete MPP");
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
