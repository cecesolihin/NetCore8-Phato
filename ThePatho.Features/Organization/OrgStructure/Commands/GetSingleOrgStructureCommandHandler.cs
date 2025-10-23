using MediatR;
using ThePatho.Provider.ApiResponse;
using ThePatho.Features.Organization.OrgStructure.Service;
using ThePatho.Features.Organization.OrgStructure.DTO;

namespace ThePatho.Features.Organization.OrgStructure.Commands
{
    public class GetSingleOrgStructureCommandHandler : IRequestHandler<GetSingleOrgStructureCommand, ApiResponse<OrgStructureDto>>
    {
        private readonly IOrgStructureService Service;

        public GetSingleOrgStructureCommandHandler(IOrgStructureService _Service)
        {
            Service = _Service;
        }

        public async Task<ApiResponse<OrgStructureDto>> Handle(GetSingleOrgStructureCommand request, CancellationToken cancellationToken)
        {
            return await Service.GetSingleOrgStructure(request);
        }
    }
}
