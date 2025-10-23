using MediatR;
using ThePatho.Provider.ApiResponse;
using ThePatho.Features.Global.FamilyRelation.Service;

namespace ThePatho.Features.Global.FamilyRelation.Commands
{
    public class SubmitFamilyRelationCommandHandler : IRequestHandler<SubmitFamilyRelationCommand, ApiResponse>
    {
        private readonly IFamilyRelationService Service;

        public SubmitFamilyRelationCommandHandler(IFamilyRelationService _familyrelationService)
        {
            Service = _familyrelationService;
        }

        public async Task<ApiResponse> Handle(SubmitFamilyRelationCommand request, CancellationToken cancellationToken)
        {
            return await Service.SubmitFamilyRelation(request);
        }
    }
}

