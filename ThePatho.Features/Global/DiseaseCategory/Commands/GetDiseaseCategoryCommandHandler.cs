using MediatR;
using ThePatho.Provider.ApiResponse;
using ThePatho.Features.Global.DiseaseCategory.DTO;
using ThePatho.Features.Global.DiseaseCategory.Service;

namespace ThePatho.Features.Global.DiseaseCategory.Commands
{
    public class GetDiseaseCategoryCommandHandler : IRequestHandler<GetDiseaseCategoryCommand, ApiResponse<DiseaseCategoryItemDto>>
    {
        private readonly IDiseaseCategoryService Service;

        public GetDiseaseCategoryCommandHandler(IDiseaseCategoryService _diseasecategoryService)
        {
            Service = _diseasecategoryService;
        }

        public async Task<ApiResponse<DiseaseCategoryItemDto>> Handle(GetDiseaseCategoryCommand request, CancellationToken cancellationToken)
        {
            return await Service.GetDiseaseCategory(request);
        }
    }
}

