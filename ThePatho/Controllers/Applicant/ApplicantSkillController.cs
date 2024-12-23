using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using ThePatho.Domain.Models;
using ThePatho.Features.Applicant.ApplicantSkill.Commands;
using ThePatho.Features.Applicant.ApplicantSkill.DTO;
using ThePatho.Features.Applicant.ApplicantSkill.Service;
using ThePatho.Features.ConfigurationExtensions;

namespace ThePatho.Controllers
{
    [ApiController]
    [Route("api/applicant/applicant-skill")]
    [ApiExplorerSettings(GroupName = "Applicant")]
    public class ApplicantSkillController : ControllerBase
    {
        private readonly IMediator mediator;

        public ApplicantSkillController(IMediator _mediator)
        {
            mediator = _mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        [HttpPost("applicant-skill-list")]
        public async Task<IActionResult> GetApplicantSkillList([FromBody] GetApplicantSkillCommand command,
            CancellationToken cancellationToken)
        {
            try
            {
                var result = await mediator.Send(command, cancellationToken);

                var response = new ApiResponse<List<ApplicantSkillDto>>(HttpStatusCode.OK, result.ApplicantSkillList, "Process Successed");

                return Ok(response);
            }
            catch (Exception ex)
            {
                var errorResponse = new ApiResponse<List<ApplicantSkillDto>>(HttpStatusCode.InternalServerError, null, "Internal Server Error", ex.Message);

                return StatusCode(StatusCodes.Status500InternalServerError, errorResponse);
            }
        }

        [HttpPost("applicant-skill-by-criteria")]
        public async Task<IActionResult> GetApplicantSkillByCriteria([FromBody] GetApplicantSkillByCriteriaCommand command,
            CancellationToken cancellationToken)
        {
            try
            {
                var result = await mediator.Send(command, cancellationToken);

                var response = new ApiResponse<ApplicantSkillDto>(HttpStatusCode.OK, result, "Process Successed");

                return Ok(response);
            }
            catch (Exception ex)
            {
                var errorResponse = new ApiResponse<ApplicantSkillDto>(HttpStatusCode.InternalServerError, null, "Internal Server Error", ex.Message);

                return StatusCode(StatusCodes.Status500InternalServerError, errorResponse);
            }
        }
    }
}
