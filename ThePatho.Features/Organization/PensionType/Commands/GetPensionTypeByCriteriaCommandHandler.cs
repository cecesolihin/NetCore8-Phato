using MediatR;
using ThePatho.Provider.ApiResponse;
using ThePatho.Features.Organization.PensionType.Service;
using ThePatho.Features.Organization.PensionType.DTO;

namespace ThePatho.Features.Organization.PensionType.Commands
{
    public class GetPensionTypeByCriteriaCommandHandler : IRequestHandler<GetPensionTypeByCriteriaCommand, ApiResponse<PensionTypeItemDto>>
    {
        private readonly IPensionTypeService Service;

        public GetPensionTypeByCriteriaCommandHandler(IPensionTypeService _Service)
        {
            Service = _Service;
        }

        public async Task<ApiResponse<PensionTypeItemDto>> Handle(GetPensionTypeByCriteriaCommand request, CancellationToken cancellationToken)
        {
            return await Service.GetPensionTypeByCriteria(request);
        }
    }
}
