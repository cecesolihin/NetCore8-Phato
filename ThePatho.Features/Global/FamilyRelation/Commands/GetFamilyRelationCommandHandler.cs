using MediatR;
using ThePatho.Provider.ApiResponse;
using ThePatho.Features.Global.FamilyRelation.DTO;
using ThePatho.Features.Global.FamilyRelation.Service;

namespace ThePatho.Features.Global.FamilyRelation.Commands
{
    public class GetFamilyRelationCommandHandler : IRequestHandler<GetFamilyRelationCommand, ApiResponse<FamilyRelationItemDto>>
    {
        private readonly IFamilyRelationService Service;

        public GetFamilyRelationCommandHandler(IFamilyRelationService _familyrelationService)
        {
            Service = _familyrelationService;
        }

        public async Task<ApiResponse<FamilyRelationItemDto>> Handle(GetFamilyRelationCommand request, CancellationToken cancellationToken)
        {
            return await Service.GetFamilyRelation(request);
        }
    }
}

