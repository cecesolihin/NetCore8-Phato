using MediatR;
using ThePatho.Provider.ApiResponse;
using ThePatho.Features.Organization.PensionType.Service;

namespace ThePatho.Features.Organization.PensionType.Commands
{
    public class SubmitPensionTypeCommandHandler : IRequestHandler<SubmitPensionTypeCommand, ApiResponse>
    {
        private readonly IPensionTypeService Service;

        public SubmitPensionTypeCommandHandler(IPensionTypeService _Service)
        {
            Service = _Service;
        }

        public async Task<ApiResponse> Handle(SubmitPensionTypeCommand request, CancellationToken cancellationToken)
        {
            return await Service.SubmitPensionType(request);
        }
    }
}
