using MediatR;
using ThePatho.Provider.ApiResponse;
using ThePatho.Features.Organization.EmploymentType.Service;
using ThePatho.Features.Organization.EmploymentType.DTO;

namespace ThePatho.Features.Organization.EmploymentType.Commands
{
    public class GetSingleEmploymentTypeCommandHandler : IRequestHandler<GetSingleEmploymentTypeCommand, ApiResponse<EmploymentTypeDto>>
    {
        private readonly IEmploymentTypeService Service;

        public GetSingleEmploymentTypeCommandHandler(IEmploymentTypeService _Service)
        {
            Service = _Service;
        }

        public async Task<ApiResponse<EmploymentTypeDto>> Handle(GetSingleEmploymentTypeCommand request, CancellationToken cancellationToken)
        {
            return await Service.GetSingleEmploymentType(request);
        }
    }
}
