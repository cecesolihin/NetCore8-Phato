using MediatR;
using ThePatho.Provider.ApiResponse;
using ThePatho.Features.Global.FamilyRelation.DTO;
using ThePatho.Features.Global.FamilyRelation.Service;

namespace ThePatho.Features.Global.FamilyRelation.Commands
{
    public class GetFamilyRelationByCriteriaCommandHandler : IRequestHandler<GetFamilyRelationByCriteriaCommand, ApiResponse<FamilyRelationItemDto>>
    {
        private readonly IFamilyRelationService Service;

        public GetFamilyRelationByCriteriaCommandHandler(IFamilyRelationService _familyrelationService)
        {
            Service = _familyrelationService;
        }

        public async Task<ApiResponse<FamilyRelationItemDto>> Handle(GetFamilyRelationByCriteriaCommand request, CancellationToken cancellationToken)
        {
            return await Service.GetFamilyRelationByCriteria(request);
        }
    }
}

