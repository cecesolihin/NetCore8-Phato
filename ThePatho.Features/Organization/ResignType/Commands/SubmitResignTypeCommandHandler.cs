using MediatR;
using ThePatho.Provider.ApiResponse;
using ThePatho.Features.Organization.ResignType.Service;

namespace ThePatho.Features.Organization.ResignType.Commands
{
    public class SubmitResignTypeCommandHandler : IRequestHandler<SubmitResignTypeCommand, ApiResponse>
    {
        private readonly IResignTypeService Service;

        public SubmitResignTypeCommandHandler(IResignTypeService _Service)
        {
            Service = _Service;
        }

        public async Task<ApiResponse> Handle(SubmitResignTypeCommand request, CancellationToken cancellationToken)
        {
            return await Service.SubmitResignType(request);
        }
    }
}
