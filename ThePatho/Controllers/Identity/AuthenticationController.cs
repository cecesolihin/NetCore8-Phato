using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using ThePatho.Features.ConfigurationExtensions;
using ThePatho.Features.Identity.Authentication.Commands;

namespace ThePatho.Controllers.Identity
{
    [ApiController]
    [Route(ApiRoutes.IdentityMenu.Authentication)]
    [ApiExplorerSettings(GroupName = "Identity")]
    public class AuthenticationController : ControllerBase
    {
        private readonly IMediator mediator;

        public AuthenticationController(IMediator _mediator)
        {
            mediator = _mediator ?? throw new ArgumentNullException(nameof(mediator)); 
        }

        private static IActionResult ApiResult<TResponse>(TResponse response) where TResponse : ApiResponse
        {
            return new ApiResult<TResponse>(response);
        }
        //[HttpPost(ApiRoutes.Methods.Register)]
        //public async Task<IActionResult> Register([FromBody] RegisterCommand command,CancellationToken cancellationToken)
        //{
        //    var result = await mediator.Send(command, cancellationToken);

        //    return ApiResult(result);
        //}
       
        [HttpPost(ApiRoutes.Methods.Login)]
        public async Task<IActionResult> Login([FromBody] LoginCommand command, CancellationToken cancellationToken)
        {
            var result = await mediator.Send(command, cancellationToken);

            return ApiResult(result);
        }
    }
   
}
