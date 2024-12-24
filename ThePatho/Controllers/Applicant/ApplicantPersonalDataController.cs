using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using ThePatho.Domain.Models;
using ThePatho.Features.Applicant.ApplicantPersonalData.Commands;
using ThePatho.Features.Applicant.ApplicantPersonalData.DTO;
using ThePatho.Features.Applicant.ApplicantPersonalData.Service;
using ThePatho.Features.ConfigurationExtensions;

namespace ThePatho.Controllers
{
    [ApiController]
    [Route(ApiRoutes.ApplicantMenu.ApplicantPersonalData)]
    [ApiExplorerSettings(GroupName = "Applicant")]
    public class ApplicantPersonalDataController : ControllerBase
    {
        private readonly IMediator mediator;

        public ApplicantPersonalDataController(IMediator _mediator)
        {
            mediator = _mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        [HttpPost(ApiRoutes.Methods.GetList)]
        public async Task<IActionResult> GetApplicantPersonalDataList([FromBody] GetApplicantPersonalDataCommand command,
            CancellationToken cancellationToken)
        {
            try
            {
                var result = await mediator.Send(command, cancellationToken);

                var response = new ApiResponse<List<ApplicantPersonalDataDto>>(HttpStatusCode.OK, result.ApplicantPersonalDataList, "Process Successed");

                return Ok(response);
            }
            catch (Exception ex)
            {
                var errorResponse = new ApiResponse<List<ApplicantPersonalDataDto>>(HttpStatusCode.InternalServerError, null, "Internal Server Error", ex.Message);

                return StatusCode(StatusCodes.Status500InternalServerError, errorResponse);
            }
        }

        [HttpPost(ApiRoutes.Methods.GetByCriteria)]
        public async Task<IActionResult> GetApplicantPersonalDataByCriteria([FromBody] GetApplicantPersonalDataByCriteriaCommand command,
            CancellationToken cancellationToken)
        {
            try
            {
                var result = await mediator.Send(command, cancellationToken);

                var response = new ApiResponse<ApplicantPersonalDataDto>(HttpStatusCode.OK, result, "Process Successed");

                return Ok(response);
            }
            catch (Exception ex)
            {
                var errorResponse = new ApiResponse<ApplicantPersonalDataDto>(HttpStatusCode.InternalServerError, null, "Internal Server Error", ex.Message);

                return StatusCode(StatusCodes.Status500InternalServerError, errorResponse);
            }
        }
    }
}
