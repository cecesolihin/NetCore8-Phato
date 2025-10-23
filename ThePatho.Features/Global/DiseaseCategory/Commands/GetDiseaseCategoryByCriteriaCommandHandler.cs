using MediatR;
using ThePatho.Provider.ApiResponse;
using ThePatho.Features.Global.DiseaseCategory.DTO;
using ThePatho.Features.Global.DiseaseCategory.Service;

namespace ThePatho.Features.Global.DiseaseCategory.Commands
{
    public class GetDiseaseCategoryByCriteriaCommandHandler : IRequestHandler<GetDiseaseCategoryByCriteriaCommand, ApiResponse<DiseaseCategoryItemDto>>
    {
        private readonly IDiseaseCategoryService Service;

        public GetDiseaseCategoryByCriteriaCommandHandler(IDiseaseCategoryService _diseasecategoryService)
        {
            Service = _diseasecategoryService;
        }

        public async Task<ApiResponse<DiseaseCategoryItemDto>> Handle(GetDiseaseCategoryByCriteriaCommand request, CancellationToken cancellationToken)
        {
            return await Service.GetDiseaseCategoryByCriteria(request);
        }
    }
}

