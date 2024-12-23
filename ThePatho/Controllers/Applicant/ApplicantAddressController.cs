using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using ThePatho.Domain.Models;
using ThePatho.Features.Applicant.ApplicantAddress.Commands;
using ThePatho.Features.Applicant.ApplicantAddress.DTO;
using ThePatho.Features.Applicant.ApplicantAddress.Service;
using ThePatho.Features.ConfigurationExtensions;

namespace ThePatho.Controllers
{
    [ApiController]
    [Route("api/applicant/applicant-address")]
    [ApiExplorerSettings(GroupName = "Applicant")]
    public class ApplicantAddressController : ControllerBase
    {
        private readonly IMediator mediator;

        public ApplicantAddressController(IMediator _mediator)
        {
            mediator = _mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        [HttpPost("applicant-address-list")]
        public async Task<IActionResult> GetApplicantAddressList([FromBody] GetApplicantAddressCommand command,
            CancellationToken cancellationToken)
        {
            try
            {
                var result = await mediator.Send(command, cancellationToken);

                var response = new ApiResponse<List<ApplicantAddressDto>>(HttpStatusCode.OK, result.ApplicantAddressList, "Process Successed");

                return Ok(response);
            }
            catch (Exception ex)
            {
                var errorResponse = new ApiResponse<List<ApplicantAddressDto>>(HttpStatusCode.InternalServerError, null, "Internal Server Error", ex.Message);

                return StatusCode(StatusCodes.Status500InternalServerError, errorResponse);
            }
        }

        [HttpPost("applicant-address-by-criteria")]
        public async Task<IActionResult> GetApplicantAddressByCriteria([FromBody] GetApplicantAddressByCriteriaCommand command,
            CancellationToken cancellationToken)
        {
            try
            {
                var result = await mediator.Send(command, cancellationToken);

                var response = new ApiResponse<ApplicantAddressDto>(HttpStatusCode.OK, result, "Process Successed");

                return Ok(response);
            }
            catch (Exception ex)
            {
                var errorResponse = new ApiResponse<ApplicantAddressDto>(HttpStatusCode.InternalServerError, null, "Internal Server Error", ex.Message);

                return StatusCode(StatusCodes.Status500InternalServerError, errorResponse);
            }
        }
    }
}
