using MediatR;
using ThePatho.Provider.ApiResponse;
using ThePatho.Features.Global.FamilyRelation.Service;

namespace ThePatho.Features.Global.FamilyRelation.Commands
{
    public class DeleteFamilyRelationCommandHandler : IRequestHandler<DeleteFamilyRelationCommand, ApiResponse>
    {
        private readonly IFamilyRelationService Service;

        public DeleteFamilyRelationCommandHandler(IFamilyRelationService _familyrelationService)
        {
            Service = _familyrelationService;
        }

        public async Task<ApiResponse> Handle(DeleteFamilyRelationCommand request, CancellationToken cancellationToken)
        {
            return await Service.DeleteFamilyRelation(request);
        }
    }
}

