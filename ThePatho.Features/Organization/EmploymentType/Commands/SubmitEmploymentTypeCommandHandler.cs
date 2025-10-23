using MediatR;
using ThePatho.Provider.ApiResponse;
using ThePatho.Features.Organization.EmploymentType.Service;

namespace ThePatho.Features.Organization.EmploymentType.Commands
{
    public class SubmitEmploymentTypeCommandHandler : IRequestHandler<SubmitEmploymentTypeCommand, ApiResponse>
    {
        private readonly IEmploymentTypeService Service;

        public SubmitEmploymentTypeCommandHandler(IEmploymentTypeService _Service)
        {
            Service = _Service;
        }

        public async Task<ApiResponse> Handle(SubmitEmploymentTypeCommand request, CancellationToken cancellationToken)
        {
            return await Service.SubmitEmploymentType(request);
        }
    }
}
