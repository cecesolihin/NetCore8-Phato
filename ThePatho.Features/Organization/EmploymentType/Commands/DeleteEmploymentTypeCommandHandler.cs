using MediatR;
using ThePatho.Provider.ApiResponse;
using ThePatho.Features.Organization.EmploymentType.Service;

namespace ThePatho.Features.Organization.EmploymentType.Commands
{
    public class DeleteEmploymentTypeCommandHandler : IRequestHandler<DeleteEmploymentTypeCommand, ApiResponse>
    {
        private readonly IEmploymentTypeService Service;

        public DeleteEmploymentTypeCommandHandler(IEmploymentTypeService _Service)
        {
            Service = _Service;
        }

        public async Task<ApiResponse> Handle(DeleteEmploymentTypeCommand request, CancellationToken cancellationToken)
        {
            return await Service.DeleteEmploymentType(request);
        }
    }
}
