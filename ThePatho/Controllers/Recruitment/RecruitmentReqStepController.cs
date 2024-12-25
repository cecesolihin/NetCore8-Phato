using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using ThePatho.Features.ConfigurationExtensions;
using ThePatho.Features.Recruitment.RecruitmentReqStep.DTO;
using ThePatho.Features.Recruitment.RecruitmentReqStep.Commands;

namespace ThePatho.Controllers
{
    [ApiController]
    [Route(ApiRoutes.RecruitmentMenu.RecruitmentReqStep)]
    [ApiExplorerSettings(GroupName = "Recruitment")]
    public class RecruitmentReqStepController : ControllerBase
    {
        private readonly IMediator mediator;

        public RecruitmentReqStepController(IMediator _mediator)
        {
            mediator = _mediator ?? throw new ArgumentNullException(nameof(mediator)); 
        }

        [HttpPost(ApiRoutes.Methods.GetList)]
        public async Task<IActionResult> GetRecruitmentReqStepList([FromBody] GetRecruitmentReqStepCommand command,
            CancellationToken cancellationToken)
        {
            try
            {
                var result = await mediator.Send(command, cancellationToken);

                var response = new ApiResponse<List<RecruitmentReqStepDto>>(HttpStatusCode.OK, result.RecruitmentReqStepList, "Process Successed");

                return Ok(response);
            }
            catch (Exception ex)
            {
                var errorResponse = new ApiResponse<List<RecruitmentReqStepDto>>(HttpStatusCode.InternalServerError, null, "Internal Server Error", ex.Message);

                return StatusCode(StatusCodes.Status500InternalServerError, errorResponse);
            }
        }

        [HttpPost(ApiRoutes.Methods.GetByCriteria)]
        public async Task<IActionResult> GetRecruitmentReqStepByCriteria([FromBody] GetRecruitmentReqStepByCriteriaCommand command,
            CancellationToken cancellationToken)
        {
            try
            {
                var result = await mediator.Send(command, cancellationToken);

                var response = new ApiResponse<List<RecruitmentReqStepDto>>(HttpStatusCode.OK, result.RecruitmentReqStepList, "Process Successed");

                return Ok(response);
            }
            catch (Exception ex)
            {
                var errorResponse = new ApiResponse<RecruitmentReqStepDto>(HttpStatusCode.InternalServerError, null, "Internal Server Error", ex.Message);

                return StatusCode(StatusCodes.Status500InternalServerError, errorResponse);
            }
        }
    }
}
