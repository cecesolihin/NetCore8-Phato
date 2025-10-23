using MediatR;
using ThePatho.Provider.ApiResponse;
using ThePatho.Features.Organization.EmploymentType.Service;
using ThePatho.Features.Organization.EmploymentType.DTO;

namespace ThePatho.Features.Organization.EmploymentType.Commands
{
    public class GetEmploymentTypeByCriteriaCommandHandler : IRequestHandler<GetEmploymentTypeByCriteriaCommand, ApiResponse<EmploymentTypeItemDto>>
    {
        private readonly IEmploymentTypeService Service;

        public GetEmploymentTypeByCriteriaCommandHandler(IEmploymentTypeService _Service)
        {
            Service = _Service;
        }

        public async Task<ApiResponse<EmploymentTypeItemDto>> Handle(GetEmploymentTypeByCriteriaCommand request, CancellationToken cancellationToken)
        {
            return await Service.GetEmploymentTypeByCriteria(request);
        }
    }
}
