using MediatR;
using ThePatho.Provider.ApiResponse;
using ThePatho.Features.Organization.HistOrgStructure.Service;
using ThePatho.Features.Organization.HistOrgStructure.DTO;

namespace ThePatho.Features.Organization.HistOrgStructure.Commands
{
    public class GetSingleHistOrgStructureCommandHandler : IRequestHandler<GetSingleHistOrgStructureCommand, ApiResponse<HistOrgStructureDto>>
    {
        private readonly IHistOrgStructureService Service;

        public GetSingleHistOrgStructureCommandHandler(IHistOrgStructureService _Service)
        {
            Service = _Service;
        }

        public async Task<ApiResponse<HistOrgStructureDto>> Handle(GetSingleHistOrgStructureCommand request, CancellationToken cancellationToken)
        {
            return await Service.GetSingleHistOrgStructure(request);
        }
    }
}
