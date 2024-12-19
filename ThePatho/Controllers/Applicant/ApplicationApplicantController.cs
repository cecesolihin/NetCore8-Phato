using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using ThePatho.Domain.Models;
using ThePatho.Features.Applicant.ApplicationApplicant.Commands;
using ThePatho.Features.Applicant.ApplicationApplicant.DTO;
using ThePatho.Features.Applicant.ApplicationApplicant.Service;
using ThePatho.Features.ConfigurationExtensions;

namespace ThePatho.Controllers
{
    [ApiController]
    [Route("api/applicant/application-applicant")]
    public class ApplicationApplicantController : ControllerBase
    {
        private readonly IMediator mediator;

        public ApplicationApplicantController(IMediator _mediator)
        {
            mediator = _mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        [HttpPost("application-applicant-list")]
        public async Task<IActionResult> GetApplicationApplicantList([FromBody] GetApplicationApplicantCommand command,
            CancellationToken cancellationToken)
        {
            try
            {
                var result = await mediator.Send(command, cancellationToken);

                var response = new ApiResponse<List<ApplicationApplicantDto>>(HttpStatusCode.OK, result.ApplicationApplicantList, "Process Successed");

                return Ok(response);
            }
            catch (Exception ex)
            {
                var errorResponse = new ApiResponse<List<ApplicationApplicantDto>>(HttpStatusCode.InternalServerError, null, "Internal Server Error", ex.Message);

                return StatusCode(StatusCodes.Status500InternalServerError, errorResponse);
            }
        }

        [HttpPost("application-applicant-by-criteria")]
        public async Task<IActionResult> GetApplicationApplicantByCriteria([FromBody] GetApplicationApplicantByCriteriaCommand command,
            CancellationToken cancellationToken)
        {
            try
            {
                var result = await mediator.Send(command, cancellationToken);

                var response = new ApiResponse<ApplicationApplicantDto>(HttpStatusCode.OK, result, "Process Successed");

                return Ok(response);
            }
            catch (Exception ex)
            {
                var errorResponse = new ApiResponse<ApplicationApplicantDto>(HttpStatusCode.InternalServerError, null, "Internal Server Error", ex.Message);

                return StatusCode(StatusCodes.Status500InternalServerError, errorResponse);
            }
        }
    }
}
