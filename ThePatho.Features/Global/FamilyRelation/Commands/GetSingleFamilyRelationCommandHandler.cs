using MediatR;
using ThePatho.Provider.ApiResponse;
using ThePatho.Features.Global.FamilyRelation.DTO;
using ThePatho.Features.Global.FamilyRelation.Service;

namespace ThePatho.Features.Global.FamilyRelation.Commands
{
    public class GetSingleFamilyRelationCommandHandler : IRequestHandler<GetSingleFamilyRelationCommand, ApiResponse<FamilyRelationDto>>
    {
        private readonly IFamilyRelationService Service;

        public GetSingleFamilyRelationCommandHandler(IFamilyRelationService _Service)
        {
            Service = _Service;
        }

        public async Task<ApiResponse<FamilyRelationDto>> Handle(GetSingleFamilyRelationCommand request, CancellationToken cancellationToken)
        {
            return await Service.GetSingleFamilyRelation(request);
        }
    }
}
