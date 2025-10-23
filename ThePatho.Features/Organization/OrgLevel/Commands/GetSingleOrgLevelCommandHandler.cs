using MediatR;
using ThePatho.Provider.ApiResponse;
using ThePatho.Features.Organization.OrgLevel.Service;
using ThePatho.Features.Organization.OrgLevel.DTO;

namespace ThePatho.Features.Organization.OrgLevel.Commands
{
    public class GetSingleOrgLevelCommandHandler : IRequestHandler<GetSingleOrgLevelCommand, ApiResponse<OrgLevelDto>>
    {
        private readonly IOrgLevelService Service;

        public GetSingleOrgLevelCommandHandler(IOrgLevelService _Service)
        {
            Service = _Service;
        }

        public async Task<ApiResponse<OrgLevelDto>> Handle(GetSingleOrgLevelCommand request, CancellationToken cancellationToken)
        {
            return await Service.GetSingleOrgLevel(request);
        }
    }
}
