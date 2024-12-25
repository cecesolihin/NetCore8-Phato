using MediatR;
using Microsoft.AspNetCore.Mvc;
using ThePatho.Features.ConfigurationExtensions;

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
    }
}
