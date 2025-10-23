using MediatR;
using ThePatho.Provider.ApiResponse;
using ThePatho.Features.Organization.EmploymentType.Service;
using ThePatho.Features.Organization.EmploymentType.DTO;

namespace ThePatho.Features.Organization.EmploymentType.Commands
{
    public class GetEmploymentTypeCommandHandler : IRequestHandler<GetEmploymentTypeCommand, ApiResponse<EmploymentTypeItemDto>>
    {
        private readonly IEmploymentTypeService Service;

        public GetEmploymentTypeCommandHandler(IEmploymentTypeService _Service)
        {
            Service = _Service;
        }

        public async Task<ApiResponse<EmploymentTypeItemDto>> Handle(GetEmploymentTypeCommand request, CancellationToken cancellationToken)
        {
            return await Service.GetEmploymentType(request);
        }
    }
}
