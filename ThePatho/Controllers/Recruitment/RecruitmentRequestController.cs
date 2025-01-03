using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using ThePatho.Features.ConfigurationExtensions;
using ThePatho.Features.Recruitment.RecruitmentRequest.DTO;
using ThePatho.Features.Recruitment.RecruitmentRequest.Service;
using ThePatho.Features.Recruitment.RecruitmentRequest.Commands;

namespace ThePatho.Controllers
{
    [ApiController]
    [Route(ApiRoutes.RecruitmentMenu.RecruitmentRequest)]
    [ApiExplorerSettings(GroupName = "Recruitment")]
    public class RecruitmentRequestController : ControllerBase
    {
        private readonly IMediator mediator;

        public RecruitmentRequestController(IMediator _mediator)
        {
            mediator = _mediator ?? throw new ArgumentNullException(nameof(mediator)); 
        }

        [HttpPost(ApiRoutes.Methods.GetList)]
        public async Task<IActionResult> GetRecruitmentRequestList([FromBody] GetRecruitmentRequestCommand command,
            CancellationToken cancellationToken)
        {
            try
            {
                var result = await mediator.Send(command, cancellationToken);

                var response = new ApiResponse<List<RecruitmentRequestDto>>(HttpStatusCode.OK, result.RecruitmentRequestList, "Process Successed");

                return Ok(response);
            }
            catch (Exception ex)
            {
                var errorResponse = new ApiResponse<List<RecruitmentRequestDto>>(HttpStatusCode.InternalServerError, null, "Internal Server Error", ex.Message);

                return StatusCode(StatusCodes.Status500InternalServerError, errorResponse);
            }
        }

        [HttpPost(ApiRoutes.Methods.GetByCriteria)]
        public async Task<IActionResult> GetRecruitmentRequestByCriteria([FromBody] GetRecruitmentRequestByCriteriaCommand command,
            CancellationToken cancellationToken)
        {
            try
            {
                var result = await mediator.Send(command, cancellationToken);

                var response = new ApiResponse<RecruitmentRequestDto>(HttpStatusCode.OK, result, "Process Successed");

                return Ok(response);
            }
            catch (Exception ex)
            {
                var errorResponse = new ApiResponse<RecruitmentRequestDto>(HttpStatusCode.InternalServerError, null, "Internal Server Error", ex.Message);

                return StatusCode(StatusCodes.Status500InternalServerError, errorResponse);
            }
        }
    }
}
