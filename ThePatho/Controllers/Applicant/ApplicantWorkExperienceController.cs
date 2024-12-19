using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using ThePatho.Domain.Models;
using ThePatho.Features.Applicant.ApplicantWorkExperience.Commands;
using ThePatho.Features.Applicant.ApplicantWorkExperience.DTO;
using ThePatho.Features.Applicant.ApplicantWorkExperience.Service;
using ThePatho.Features.ConfigurationExtensions;

namespace ThePatho.Controllers
{
    [ApiController]
    [Route("api/applicant/applicant-work-experience")]
    public class ApplicantWorkExperienceController : ControllerBase
    {
        private readonly IMediator mediator;

        public ApplicantWorkExperienceController(IMediator _mediator)
        {
            mediator = _mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        [HttpPost("applicant-work-experience-list")]
        public async Task<IActionResult> GetApplicationWorkExperienceList([FromBody] GetApplicantWorkExperienceCommand command,
            CancellationToken cancellationToken)
        {
            try
            {
                var result = await mediator.Send(command, cancellationToken);

                var response = new ApiResponse<List<ApplicantWorkExperienceDto>>(HttpStatusCode.OK, result.ApplicantWorkExperienceList, "Process Successed");

                return Ok(response);
            }
            catch (Exception ex)
            {
                var errorResponse = new ApiResponse<List<ApplicantWorkExperienceDto>>(HttpStatusCode.InternalServerError, null, "Internal Server Error", ex.Message);

                return StatusCode(StatusCodes.Status500InternalServerError, errorResponse);
            }
        }

        [HttpPost("applicant-work-experience-by-criteria")]
        public async Task<IActionResult> GetApplicationWorkExperienceByCriteria([FromBody] GetApplicantWorkExperienceByCriteriaCommand command,
            CancellationToken cancellationToken)
        {
            try
            {
                var result = await mediator.Send(command, cancellationToken);

                var response = new ApiResponse<ApplicantWorkExperienceDto>(HttpStatusCode.OK, result, "Process Successed");

                return Ok(response);
            }
            catch (Exception ex)
            {
                var errorResponse = new ApiResponse<ApplicantWorkExperienceDto>(HttpStatusCode.InternalServerError, null, "Internal Server Error", ex.Message);

                return StatusCode(StatusCodes.Status500InternalServerError, errorResponse);
            }
        }
    }
}
