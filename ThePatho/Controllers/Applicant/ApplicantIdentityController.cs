using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using ThePatho.Domain.Models;
using ThePatho.Features.Applicant.ApplicantIdentity.Commands;
using ThePatho.Features.Applicant.ApplicantIdentity.DTO;
using ThePatho.Features.Applicant.ApplicantIdentity.Service;
using ThePatho.Features.ConfigurationExtensions;

namespace ThePatho.Controllers
{
    [ApiController]
    [Route("api/applicant/applicant-identity")]
    [ApiExplorerSettings(GroupName = "Applicant")]
    public class ApplicantIdentityController : ControllerBase
    {
        private readonly IMediator mediator;

        public ApplicantIdentityController(IMediator _mediator)
        {
            mediator = _mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        [HttpPost("applicant-identity-list")]
        public async Task<IActionResult> GetApplicantIdentityList([FromBody] GetApplicantIdentityCommand command,
            CancellationToken cancellationToken)
        {
            try
            {
                var result = await mediator.Send(command, cancellationToken);

                var response = new ApiResponse<List<ApplicantIdentityDto>>(HttpStatusCode.OK, result.ApplicantIdentityList, "Process Successed");

                return Ok(response);
            }
            catch (Exception ex)
            {
                var errorResponse = new ApiResponse<List<ApplicantIdentityDto>>(HttpStatusCode.InternalServerError, null, "Internal Server Error", ex.Message);

                return StatusCode(StatusCodes.Status500InternalServerError, errorResponse);
            }
        }

        [HttpPost("applicant-identity-by-criteria")]
        public async Task<IActionResult> GetApplicantIdentityByCriteria([FromBody] GetApplicantIdentityByCriteriaCommand command,
            CancellationToken cancellationToken)
        {
            try
            {
                var result = await mediator.Send(command, cancellationToken);

                var response = new ApiResponse<ApplicantIdentityDto>(HttpStatusCode.OK, result, "Process Successed");

                return Ok(response);
            }
            catch (Exception ex)
            {
                var errorResponse = new ApiResponse<ApplicantIdentityDto>(HttpStatusCode.InternalServerError, null, "Internal Server Error", ex.Message);

                return StatusCode(StatusCodes.Status500InternalServerError, errorResponse);
            }
        }
    }
}
