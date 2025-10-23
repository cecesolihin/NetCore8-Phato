using MediatR;
using ThePatho.Provider.ApiResponse;
using ThePatho.Features.Global.DiseaseCategory.DTO;
using ThePatho.Features.Global.DiseaseCategory.Service;

namespace ThePatho.Features.Global.DiseaseCategory.Commands
{
    public class GetSingleDiseaseCategoryCommandHandler : IRequestHandler<GetSingleDiseaseCategoryCommand, ApiResponse<DiseaseCategoryDto>>
    {
        private readonly IDiseaseCategoryService Service;

        public GetSingleDiseaseCategoryCommandHandler(IDiseaseCategoryService _Service)
        {
            Service = _Service;
        }

        public async Task<ApiResponse<DiseaseCategoryDto>> Handle(GetSingleDiseaseCategoryCommand request, CancellationToken cancellationToken)
        {
            return await Service.GetSingleDiseaseCategory(request);
        }
    }
}
