using MediatR;
using ThePatho.Provider.ApiResponse;
using ThePatho.Features.Organization.HistOrgStructure.Service;
using ThePatho.Features.Organization.HistOrgStructure.DTO;

namespace ThePatho.Features.Organization.HistOrgStructure.Commands
{
    public class GetHistOrgStructureByCriteriaCommandHandler : IRequestHandler<GetHistOrgStructureByCriteriaCommand, ApiResponse<HistOrgStructureItemDto>>
    {
        private readonly IHistOrgStructureService Service;

        public GetHistOrgStructureByCriteriaCommandHandler(IHistOrgStructureService _Service)
        {
            Service = _Service;
        }

        public async Task<ApiResponse<HistOrgStructureItemDto>> Handle(GetHistOrgStructureByCriteriaCommand request, CancellationToken cancellationToken)
        {
            return await Service.GetHistOrgStructureByCriteria(request);
        }
    }
}
