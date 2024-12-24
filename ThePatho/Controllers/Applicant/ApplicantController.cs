using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using ThePatho.Domain.Models;
using ThePatho.Features.Applicant.Applicant.Commands;
using ThePatho.Features.Applicant.Applicant.DTO;
using ThePatho.Features.Applicant.Applicant.Service;
using ThePatho.Features.ConfigurationExtensions;

namespace ThePatho.Controllers
{
    [ApiController]
    [Route(ApiRoutes.ApplicantMenu.Applicant)]
    [ApiExplorerSettings(GroupName = "Applicant")]
    public class ApplicantController : ControllerBase
    {
        private readonly IMediator mediator;

        public ApplicantController(IMediator _mediator)
        {
            mediator = _mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        [HttpPost(ApiRoutes.Methods.GetList)]
        public async Task<IActionResult> GetApplicantList([FromBody] GetApplicantCommand command,
            CancellationToken cancellationToken)
        {
            try
            {
                var result = await mediator.Send(command, cancellationToken);

                var response = new ApiResponse<List<ApplicantDto>>(HttpStatusCode.OK, result.ApplicantList, "Process Successed");

                return Ok(response);
            }
            catch (Exception ex)
            {
                var errorResponse = new ApiResponse<List<ApplicantDto>>(HttpStatusCode.InternalServerError, null, "Internal Server Error", ex.Message);

                return StatusCode(StatusCodes.Status500InternalServerError, errorResponse);
            }
        }

        [HttpPost(ApiRoutes.Methods.GetByCriteria)]
        public async Task<IActionResult> GetApplicantByCriteria([FromBody] GetApplicantByCriteriaCommand command,
            CancellationToken cancellationToken)
        {
            try
            {
                var result = await mediator.Send(command, cancellationToken);

                var response = new ApiResponse<ApplicantDto>(HttpStatusCode.OK, result, "Process Successed");

                return Ok(response);
            }
            catch (Exception ex)
            {
                var errorResponse = new ApiResponse<ApplicantDto>(HttpStatusCode.InternalServerError, null, "Internal Server Error", ex.Message);

                return StatusCode(StatusCodes.Status500InternalServerError, errorResponse);
            }
        }
    }
}
