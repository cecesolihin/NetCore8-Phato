using MediatR;
using ThePatho.Provider.ApiResponse;
using ThePatho.Features.Organization.HistOrgStructure.Service;
using ThePatho.Features.Organization.HistOrgStructure.DTO;

namespace ThePatho.Features.Organization.HistOrgStructure.Commands
{
    public class GetHistOrgStructureCommandHandler : IRequestHandler<GetHistOrgStructureCommand, ApiResponse<HistOrgStructureItemDto>>
    {
        private readonly IHistOrgStructureService Service;

        public GetHistOrgStructureCommandHandler(IHistOrgStructureService _Service)
        {
            Service = _Service;
        }

        public async Task<ApiResponse<HistOrgStructureItemDto>> Handle(GetHistOrgStructureCommand request, CancellationToken cancellationToken)
        {
            return await Service.GetHistOrgStructure(request);
        }
    }
}
